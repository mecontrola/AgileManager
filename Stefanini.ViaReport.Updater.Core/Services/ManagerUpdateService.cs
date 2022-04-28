using Stefanini.ViaReport.Updater.Core.Helpers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Updater.Core.Services
{
    public class ManagerUpdateService : IManagerUpdateService
    {
        private readonly IStep01Helper step01Helper;
        private readonly IStep02Helper step02Helper;
        private readonly IStep03Helper step03Helper;
        private readonly IStep04Helper step04Helper;

        public ManagerUpdateService(IStep01Helper step01Helper,
                                    IStep02Helper step02Helper,
                                    IStep03Helper step03Helper,
                                    IStep04Helper step04Helper)
        {
            this.step01Helper = step01Helper;
            this.step02Helper = step02Helper;
            this.step03Helper = step03Helper;
            this.step04Helper = step04Helper;
        }

        public async Task CheckAndDownloadUpdate(Action<string> fncUpdateStatus, Action<bool, long> fncUpdateProgress, CancellationToken cancellationToken)
        {
            try
            {
                fncUpdateStatus("Verificando se existe uma versão mais recente.");
                fncUpdateProgress(false, 0);

                await step01Helper.Run(cancellationToken);

                fncUpdateStatus("Finalizando a aplicação aberta.");
                fncUpdateProgress(false, 0);

                step02Helper.Run();

                fncUpdateStatus("Baixando a nova versão.");
                fncUpdateProgress(false, 0);

                await step03Helper.Run(fncUpdateProgress, cancellationToken);

                fncUpdateStatus("Instalando a nova versão.");
                fncUpdateProgress(false, 0);

                step04Helper.Run();

                fncUpdateStatus("Atualização concluída.");
                fncUpdateProgress(false, 0);
            }
            catch { }
        }
    }
}