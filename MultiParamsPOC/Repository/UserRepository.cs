using MultiParamsPOC.Entities;
using MultiParamsPOC.Filtering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiParamsPOC.Repository
{
    public class UserRepository : IUserRepository
    {
        protected IList<User> Users = new List<User>() { new User() {first_name="Sponge", last_name="Bob" }, new User() { first_name = "Bart", last_name = "Simpson" } };
        public IList<User> GetUsers(IFilter<User> filter)
        {
            return Users.Where(filter.AsPredicate()).ToList();
        }
    }
}
