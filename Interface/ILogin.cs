using iStartWeb.Models;
using System.Net.Http;


namespace iStartWebAPI.Interface
{
    public interface ILogin
    {
        HttpResponseMessage UserLoginCheck(UserRegisterViewModel userlogin);
    }
}
