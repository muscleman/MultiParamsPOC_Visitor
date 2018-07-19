using MultiParamsPOC.Entities;
using MultiParamsPOC.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiParamsPOC.Repository
{
    public class UserRepository : IUserRepository
    {
        protected IList<User> Users = new List<User>() { new User() {id = 1, first_name="Sponge", last_name="Bob" }, new User() {id = 2, first_name = "Bart", last_name = "Simpson" }, new User() { id = 3, first_name = "Sponge", last_name = "Bo" } };
        public IList<User> GetUsers(IFilter<User> filter)
        {
            if (filter.SqlFunc == null) return Users;

            //return Users.Where(x => x.last_name.Contains("B") && x.first_name.Contains("Sponge")).ToList();
            return Users.Where(filter.SqlFunc.Compile()).ToList();
        }
    }
}
