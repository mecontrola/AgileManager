using System;

namespace Stefanini.Core.Data.Entities
{
    public interface IEntity
    {
        long Id { get; }
        Guid Uuid { get; }
    }
}