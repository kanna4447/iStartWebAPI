using iStartWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iStartWebAPI.InterfaceClass
{
    public interface iUserLogin
    {

        List<UserLogin> GetLoginUsers();

        UserLogin GetLoginUserById(int loginuserId);
    }
}
