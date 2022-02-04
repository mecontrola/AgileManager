using System.Collections.Generic;
using System.Linq;

namespace Stefanini.ViaReport.Core.Mappers
{
    public abstract class BaseMapper<TParam, TResult>
        where TParam : class
        where TResult : class
    {
        public abstract TResult ToMap(TParam obj);

        public IList<TResult> ToMapList<T>(T list)
            where T : IEnumerable<TParam>
            => list.Select(itm => ToMap(itm)).ToList();
    }
}