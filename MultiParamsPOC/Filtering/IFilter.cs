using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiParamsPOC.Filtering
{
    public interface IFilter<T>
    {
        Expression<Func<T, bool>> SqlFunc { get; set; }
        string AsSql { get; set; }
    }
}
