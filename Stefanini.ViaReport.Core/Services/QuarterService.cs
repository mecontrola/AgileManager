using Stefanini.ViaReport.Core.Helpers;
using Stefanini.ViaReport.Data.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Stefanini.ViaReport.Core.Services
{
    public class QuarterService : IQuarterService
    {
        private readonly IQuarterGenerateListHelper quarterGenerateListHelper;

        public QuarterService(IQuarterGenerateListHelper quarterGenerateListHelper)
        {
            this.quarterGenerateListHelper = quarterGenerateListHelper;
        }

        public async Task<IList<QuarterDto>> LoadAllAsync(CancellationToken cancellationToken)
            => await Task.FromResult(GenerateList());

        private IList<QuarterDto> GenerateList()
            => quarterGenerateListHelper.Create(DateTime.Now)
                                        .Select((value, index) => new QuarterDto
                                        {
                                            Id = index + 1,
                                            Name = value
                                        })
                                        .ToList();
    }
}