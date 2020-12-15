using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using JETech.NetCoreWeb.Extensions;


namespace JETech.NetCoreWeb.Helper
{
    public class ConverterExpression
    {
        private static Expression<Func<T, bool>> GetExpressionFromMethod<T>(string propertyName, string propertyValue, string pMethod)
        {
            var parameterExp = Expression.Parameter(typeof(T), "type");
            var propertyExp = Expression.Property(parameterExp, propertyName);
            MethodInfo method = typeof(string).GetMethod(pMethod, new[] { typeof(string) });
            var someValue = Expression.Constant(propertyValue, typeof(string));
            var containsMethodExp = Expression.Call(propertyExp, method, someValue);

            var condition = Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);

            return condition;
        }

        public static Expression<Func<T, bool>> GetContainsExpression<T>(string propertyName, string propertyValue) 
        {
            return GetContainsExpression<T>(propertyName, propertyValue, false);
        }
        public static Expression<Func<T, bool>> GetContainsExpression<T>(string propertyName, string propertyValue, bool validateNull)
        {         
            var condition = GetExpressionFromMethod<T>(propertyName, propertyValue, "Contains"); 
            if (validateNull)
            {
                var nullCheck2 = GetNotNullExpression<T>(propertyName,propertyValue);

                condition = nullCheck2.AndAlso<T>(condition);
            }
            return condition;
        }

        public static Expression<Func<T, bool>> GetNotNullExpression<T>(string propertyName, string propertyValue)
        {
            var parameterExp = Expression.Parameter(typeof(T), "type");
            var propertyExp = Expression.Property(parameterExp, propertyName);            

            var condiction = Expression.Lambda<Func<T, bool>>(
                Expression.NotEqual(propertyExp, Expression.Constant(null, typeof(string))),
                parameterExp);

            return condiction;
        }

        public static Expression<Func<T, bool>> GetStartsWithExpression<T>(string propertyName, string propertyValue)
        {
            var condition = GetExpressionFromMethod<T>(propertyName, propertyValue, "StartsWith");

            return condition;
        }
    }
}
