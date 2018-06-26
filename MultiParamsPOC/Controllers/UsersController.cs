using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MultiParamsPOC.Entities;
using MultiParamsPOC.Filtering;
using MultiParamsPOC.Services;
using Newtonsoft.Json;

namespace MultiParamsPOC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IService service;
        public UsersController(IService service)
        {
            this.service = service;
        }

        [HttpGet()]
        //public ActionResult<string> GetUsersBy([FromQuery]string user_guid,
        //                                       [FromQuery]string username,
        //                                       [FromQuery]string legacy_username,
        //                                       [FromQuery]string first_name,
        //                                       [FromQuery]string last_name)
        public ActionResult<string> GetUsersBy()
        {
            var values = Request.Query;
            IFilter<User> filter = new UserFilter();

            IVisitor<User> v = new EvalVisitor<User>(filter);

            var it = values.GetEnumerator();
            while (it.MoveNext())
                v.visit(it.Current.Key, it.Current.Value);


            var result = service.Getusers(filter);
            return JsonConvert.SerializeObject(result);
        }

        //[HttpGet()]
        //public ActionResult<string> GetUsersBy([FromQuery]User user)
        //{
        //    Dictionary<string, dynamic> d = new Dictionary<string, dynamic>();
        //    d.Add("first_name", 32);
        //    d.Add("last_name", "abc");

        //    IVisitor<User> v = new EvalVisitor<User>();
        //    var it = d.GetEnumerator();
        //    while (it.MoveNext())
        //        v.visit(it.Current.Key, it.Current.Value);


        //    var result = service.Getusers(user);
        //    return JsonConvert.SerializeObject( result);

        //}

    }
}
