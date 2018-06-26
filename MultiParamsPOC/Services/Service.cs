using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MultiParamsPOC.Entities;
using MultiParamsPOC.Filtering;
using MultiParamsPOC.Repository;

namespace MultiParamsPOC.Services
{
    public class Service : IService
    {
        IUserRepository repository;
        public Service(IUserRepository repository)
        {
            this.repository = repository;
        }
        public IList<User> Getusers(IFilter<User> filter)
        {
            return repository.GetUsers(filter);
        }
    }
}
