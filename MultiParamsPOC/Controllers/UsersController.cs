using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
            

        //public ActionResult<string> GetUsersBy([FromQuery]User user)
        //{
            
        //    var result = service.Getusers(user);
        //    return JsonConvert.SerializeObject(result);
        //}

        [Route("{id?}")]
        public ActionResult<string> GetStuff([FromQuery]User user)
        {
            var id = RouteData.Values["id"];
            var result = service.Getusers(user);
            return JsonConvert.SerializeObject(result);
        }
    }


}
