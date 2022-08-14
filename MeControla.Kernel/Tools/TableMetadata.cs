using MeControla.Core.Extensions.DataStorage;
using System;
using System.Linq.Expressions;

namespace MeControla.Kernel.Tools
{
    public class TableMetadata<TEntity>
        where TEntity : class
    {
        private readonly string prefixTable;
        private readonly string prefixColumn;

        public TableMetadata(string prefixTable, string prefixColumn)
        {
            this.prefixTable = prefixTable;
            this.prefixColumn = prefixColumn;
        }

        public string GetTableName()
            => typeof(TEntity).Name
                              .GetColumnName(prefixTable);

        public string GetColumnName<TProperty>(Expression<Func<TEntity, TProperty>> propertyExpression)
            => ((MemberExpression)propertyExpression.Body).Member
                                                          .Name
                                                          .GetColumnName(prefixColumn);
    }
}