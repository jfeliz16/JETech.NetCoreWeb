using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace JETech.NetCoreWeb.Helper
{
    public class ConverterExpression
    {
        public static Expression<Func<T, bool>> GetContainsExpression<T>(string propertyName, string propertyValue) 
        {
            return GetContainsExpression<T>(propertyName, propertyValue, false);
        }

        public static Expression<Func<T, bool>> GetContainsExpression<T>(string propertyName, string propertyValue,bool validateNull)
        {
            var parameterExp = Expression.Parameter(typeof(T), "type");
            var propertyExp = Expression.Property(parameterExp, propertyName);
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var someValue = Expression.Constant(propertyValue, typeof(string));
            var containsMethodExp = Expression.Call(propertyExp, method, someValue);

            var condition = Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);

            if (validateNull)
            {
                var nullCheck2 = Expression.NotEqual(propertyExp, Expression.Constant(null, typeof(string)));

                condition = Expression.Lambda<Func<T, bool>>(
                               Expression.AndAlso(nullCheck2, condition.Body ), condition.Parameters[0]);
            }
            
            return condition;
        }

        public static Expression<Func<T, bool>> GetStartsWithExpression<T>(string propertyName, string propertyValue)
        {
            var parameterExp = Expression.Parameter(typeof(T), "type");
            var propertyExp = Expression.Property(parameterExp, propertyName);
            MethodInfo method = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
            var someValue = Expression.Constant(propertyValue, typeof(string));
            var containsMethodExp = Expression.Call(propertyExp, method, someValue);
        
            var condition = Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);

            return condition;
        }
    }
}
