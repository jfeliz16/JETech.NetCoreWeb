using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

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
                //var nullCheck2 = GetNotNullBinaryExpression<T>(propertyName,propertyValue);



                //condition = Expression.Lambda<Func<T, bool>>(
                //                Expression.AndAlso(
                //                    condition.Body,
                //                    Expression.Invoke(nullCheck2, condition.Parameters[0])), condition.Parameters[0]);

                condition = Expression.Lambda<Func<T, bool>>(
                               Expression.AndAlso(nullCheck2, condition.Body), condition.Parameters[0]);
            }

            return condition;
        }

        public static BinaryExpression GetNotNullBinaryExpression<T>(string propertyName, string propertyValue)
        {
            var parameterExp = Expression.Parameter(typeof(T), "type");
            var propertyExp = Expression.Property(parameterExp, propertyName);
            var condiction = Expression.NotEqual(propertyExp, Expression.Constant(null, typeof(string)));
            

            return condiction;
        }

        public static Expression<Func<T, bool>> GetStartsWithExpression<T>(string propertyName, string propertyValue)
        {
            var condition = GetExpressionFromMethod<T>(propertyName, propertyValue, "StartsWith");

            return condition;
        }
    }
}
