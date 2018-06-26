using MultiParamsPOC.Entities;
using MultiParamsPOC.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiParamsPOC.Services
{
    public interface IService
    {
        IList<User> Getusers(IFilter<User> filter);
    }
}
