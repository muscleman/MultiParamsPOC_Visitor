using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiParamsPOC.Filtering
{
    public interface IFilter<T>
    {
        string AsSql { get; set; }
        Func<T, bool> AsPredicate();
    }
}
