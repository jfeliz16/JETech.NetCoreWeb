using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace JETech.NetCoreWeb.Extensions
{
    public static class ExpressionExtension
    {
        public static Expression<Func<T, bool>> AndAlso<T>(
            this Expression<Func<T, bool>> leftExp,
            Expression<Func<T, bool>> rightExp)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(leftExp.Parameters[0], parameter);
            var left = leftVisitor.Visit(leftExp.Body);

            var rightVisitor = new ReplaceExpressionVisitor(rightExp.Parameters[0], parameter);
            var right = rightVisitor.Visit(rightExp.Body);

            return Expression.Lambda<Func<T, bool>>(
                Expression.AndAlso(left, right), parameter);
        }

        private class ReplaceExpressionVisitor
            : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression Visit(Expression node)
            {
                if (node == _oldValue)
                    return _newValue;
                return base.Visit(node);
            }
        }
    }
}
