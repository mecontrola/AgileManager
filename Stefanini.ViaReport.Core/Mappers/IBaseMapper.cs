using System.Collections.Generic;

namespace Stefanini.ViaReport.Core.Mappers
{
    public interface IBaseMapper<TParam, TResult>
        where TParam : class
        where TResult : class
    {
        TResult ToMap(TParam obj);
        IList<TResult> ToMapList<T>(T list)
           where T : IEnumerable<TParam>;
    }
}