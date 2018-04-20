using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Tecwi1.Repositories
{
    public static class Helpers
    {
       public static IOrderedQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, string propertyName, string direction)
        {
            var entityType = typeof(TSource);

            string methodName = query.Expression.Type == typeof(IOrderedQueryable<TSource>) ? "ThenBy" : "OrderBy"; //Determine OrderBy or ThenBy
            methodName += (direction == "desc" ? "Descending" : string.Empty); //Set direction: OrderBy + Descending = OrderByDescending

            //Create x=>x.PropName
            var propertyInfo = entityType.GetProperty(propertyName);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, propertyName);
            var selector = Expression.Lambda(property, new ParameterExpression[] { arg });

            //Get System.Linq.Queryable.OrderBy() method.
            var enumarableType = typeof(Queryable);
            var method = enumarableType.GetMethods()
                 .Where(m => m.Name == methodName && m.IsGenericMethodDefinition)
                 .Where(m => m.GetParameters().Length == 2)
                 .Single();

            //The linq's OrderBy<TSource, TKey> has two generic types, which provided here
            MethodInfo genericMethod = method
                 .MakeGenericMethod(entityType, propertyInfo.PropertyType);

            /*Call query.OrderBy(selector), with query and selector: x=> x.PropName
              Note that we pass the selector as Expression to the method and we don't compile it.
              By doing so EF can extract "order by" columns and generate SQL for it.*/
            var newQuery = (IOrderedQueryable<TSource>)genericMethod
                 .Invoke(genericMethod, new object[] { query, selector });

            return newQuery;
        }

        public static IQueryable<TSource> Order<TSource>(this IQueryable<TSource> query, IEnumerable<(string fieldName, string direction)> sortFields)
        {
            foreach (var sortColumn in sortFields)
                query = query.OrderBy(sortColumn.fieldName, sortColumn.direction);

            return query;
        }
    }
}