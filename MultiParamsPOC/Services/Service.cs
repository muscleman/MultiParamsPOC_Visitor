using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MultiParamsPOC.Entities;
using MultiParamsPOC.Filtering;
using MultiParamsPOC.Repository;
using Newtonsoft.Json;

namespace MultiParamsPOC.Services
{
    public class Service : IService
    {
        IUserRepository repository;
        IFilter<User> filter = new UserFilter();
        public Service(IUserRepository repository)
        {
            this.repository = repository;
        }
        public IList<User> Getusers(User user)
        {
            var userAsDictionary = ObjectToDictionaryHelper.ToDictionary(user) as Dictionary<string, dynamic>;

            IVisitor<User> v = new EvalVisitor<User>(filter);

            var iterator = userAsDictionary.GetEnumerator();
            while (iterator.MoveNext())
            {
                v.visit(iterator.Current.Key, iterator.Current.Value);
            }
            return repository.GetUsers(filter);
        }
    }


}
