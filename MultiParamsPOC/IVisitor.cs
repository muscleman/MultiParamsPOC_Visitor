using MultiParamsPOC.Entities;
using MultiParamsPOC.Filtering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace MultiParamsPOC
{
    public interface IVisitor<T>
    {
        void visit(string key, string value);
        void visit(string key, int? value);
    }

    public class EvalVisitor<T> : IVisitor<T> where T : User
    {
        public IFilter<T> filter;

        public EvalVisitor(IFilter<T> filter)
        {
            this.filter = filter;
        }

        public void visit(string key, string value)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), "x");
            MemberExpression property = Expression.Property(param, key);
            Expression<Func<T, bool>> result;

            if (value.Contains('*'))
            {
                value = value.Replace("*", "");
                ConstantExpression constant = Expression.Constant(value, typeof(string));
                MethodInfo method = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
                var someValue = Expression.Constant(value, typeof(string));
                var containsMethodExp = Expression.Call(property, method, constant);
                result = Expression.Lambda<Func<T, bool>>(containsMethodExp, param);

            }
            else
            {
                ConstantExpression constant = Expression.Constant(value, typeof(string));
                BinaryExpression where = Expression.Equal(property, constant);
                result = Expression.Lambda<Func<T, bool>>(where, param);
            }

            if (filter.SqlFunc != null)
            {
                result = Expression.Lambda<Func<T, bool>>(Expression.AndAlso(Expression.Invoke(filter.SqlFunc, param), result.Body),  param );
            }
            filter.SqlFunc = result;
        }

        public void visit(string key, int? value)
        {
            if (value.HasValue)
            {
                ParameterExpression param = Expression.Parameter(typeof(T), key);
                MemberExpression property = Expression.Property(param, key);
                ConstantExpression constant = Expression.Constant(value, typeof(int?));
                BinaryExpression where = Expression.Equal(property, constant);

                Expression<Func<T, bool>> result = Expression.Lambda<Func<T, bool>>(where, param);

                if (filter.SqlFunc != null)
                {
                    result = Expression.Lambda<Func<T, bool>>(Expression.AndAlso(Expression.Invoke(filter.SqlFunc, param), result.Body), param);
                }
                filter.SqlFunc = result;
            }
        }

    }
}
