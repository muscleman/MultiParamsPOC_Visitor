using MultiParamsPOC.Entities;
using MultiParamsPOC.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiParamsPOC.Repository
{
    public interface IUserRepository
    {
        IList<User> GetUsers(IFilter<User> filter); 
    }
}
