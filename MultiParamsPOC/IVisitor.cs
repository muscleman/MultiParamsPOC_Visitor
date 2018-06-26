using MultiParamsPOC.Entities;
using MultiParamsPOC.Filtering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiParamsPOC
{
    public interface IVisitor<T>
    {
        void visit(string key, string value);
        void visit(string key, int value);
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
            ConstantExpression constant = Expression.Constant(value, typeof(string));
            BinaryExpression where = Expression.Equal(property, constant);

            if (filter.SqlFunc == null)
                filter.SqlFunc = Expression.Lambda<Func<T, bool>>(where, param);
            else
                filter.SqlFunc = Expression.Lambda<Func<T, bool>>(Expression.And(filter.SqlFunc,
                                                        Expression.Lambda<Func<T, bool>>(where, param)));
        }

        public void visit(string key, int value)
        {
            ParameterExpression param = Expression.Parameter(typeof(T), key);
            MemberExpression property = Expression.Property(param, key);
            ConstantExpression constant = Expression.Constant(value, typeof(int));
            BinaryExpression where = Expression.Equal(property, constant);
            filter.SqlFunc = Expression.Lambda<Func<T, bool>>(where, param);
        }

    }
}
