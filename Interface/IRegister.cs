using iStartWeb.Models;
using iStartWebAPI.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace iStartWebAPI.Interface
{
   public interface IRegister
    { 
        IEnumerable<UserRegistration> GetRegisteredUsers();
        HttpResponseMessage AddRegistration(UserRegistration userRegister);
        UserRegisterViewModel EditRegistration(int userId, UserRegisterViewModel usereditValues);
       

    }
}
