using MeControla.AgileManager.Core.Mappers.EntityToDto;
using MeControla.AgileManager.Data.Dtos;
using MeControla.AgileManager.DataStorage.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MeControla.AgileManager.Core.Services
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