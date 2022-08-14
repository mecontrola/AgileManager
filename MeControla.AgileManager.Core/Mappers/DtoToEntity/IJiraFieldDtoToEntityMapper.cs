using MeControla.AgileManager.Data.Dtos.Jira;
using MeControla.AgileManager.Data.Entities;
using MeControla.Core.Mappers;

namespace MeControla.AgileManager.Core.Mappers.DtoToEntity
{
    public interface IJiraFieldDtoToEntityMapper : IMapper<FieldDto, Customfield>
    { }
}