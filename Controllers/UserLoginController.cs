
using iStartWeb.Models;
using iStartWebAPI.Interface;
using iStartWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;


namespace iStartWebAPI.Controllers
{
    public class UserLoginController : ApiController
    {
        private readonly ILogin _ILogin;

       
        
        public UserLoginController(ILogin ILogin)
        {
            _ILogin = ILogin;
        }


        public HttpResponseMessage LoginCheck(UserRegisterViewModel user)
        {
            var resultLogin = _ILogin.UserLoginCheck(user);
            return resultLogin;
        }





    }



}

