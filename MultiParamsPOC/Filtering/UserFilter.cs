using MultiParamsPOC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MultiParamsPOC.Filtering
{
    public class UserFilter : IFilter<User>
    {
        User user;



        public UserFilter(User user)
        {
            this.user = user;

 
        }
        public string AsSql { get; set; }
        public Func<User, bool> AsPredicate()
        {
            IDictionary<string, Func<User, bool>> availableFilters = new Dictionary<string, Func<User, bool>>()
            {
                { "first_name", (u) => u.first_name == user.first_name},
                { "last_name", (u) => u.last_name == user.last_name},
            };            
            
            //const string exp = @"first_name == {user.first_name}";
            //var x = Expression.Parameter(typeof(User), "x");
            //var e = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { x }, null, exp);

            //Func<User, bool> f = (x => x.first_name == user.first_name);
            Func<User, bool> f = availableFilters["first_name"];
            f += availableFilters["last_name"];
            return f;
            //Expression<Func<User, bool>> exp = x => f(user);

            //return exp.Compile();


            //return x =>( x.first_name == user.first_name);
        }
    }
}
