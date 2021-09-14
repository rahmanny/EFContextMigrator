using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFContextMigrator.Extensions
{
    /// <summary>
    /// IQueryable Extension Methods
    /// </summary>
    public static class QueryableExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context">Entity Framework context</param>
        /// <param name="t">Data type</param>
        /// <returns></returns>
        public static IQueryable<object> Set(this DbContext context, Type t)
        {
            return (IQueryable<object>)context.GetType().GetMethods().FirstOrDefault(m => m.Name.Contains("Set"))?.MakeGenericMethod(t)
                .Invoke(context, null);
        }
    }
}