using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ExceptionHandlerMiddleware.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _business;
        public UserController(IUserBusiness business)
        {
            _business = business;
        }
        [HttpPost]
        [Route("login")]
        public UserLoginOutput Login(UserLoginInput userLoginInput)
        {
            return _business.Login(userLoginInput);
        }
     }
}
