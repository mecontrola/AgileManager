using Stefanini.ViaReport.Core.Mappers.EntityToDto;
using Stefanini.ViaReport.Data.Dtos;
using Stefanini.ViaReport.DataStorage.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public class QuarterService : IQuarterService
    {
        private readonly IQuarterRepository quarterRepository;

        private readonly IQuarterEntityToDtoMapper quarterEntityToDtoMapper;

        public QuarterService(IQuarterRepository quarterRepository,
                              IQuarterEntityToDtoMapper quarterEntityToDtoMapper)
        {
            this.quarterRepository = quarterRepository;
            this.quarterEntityToDtoMapper = quarterEntityToDtoMapper;
        }

        public async Task<IList<QuarterDto>> LoadAllAsync(CancellationToken cancellationToken)
        {
            var list = await quarterRepository.Get5LastListAsync(cancellationToken);

            return quarterEntityToDtoMapper.ToMapList(list);
        }
    }
}