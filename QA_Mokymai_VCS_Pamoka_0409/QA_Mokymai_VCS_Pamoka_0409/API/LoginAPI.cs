using QA_Mokymai_VCS_Pamoka_0409.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA_Mokymai_VCS_Pamoka_0409.API
{
    public class LoginAPI
    {

        public static IList<RestResponseCookie> Login(User user)
        {
            var client = new RestClient("https://www.kika.lt/");
            var request = new RestRequest("?login&display=content_types/customers/authorize", Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            request.AddParameter($"state=login&email={user.Username}&password={user.Password}", ParameterType.RequestBody);
            var response = client.Execute(request);
            Console.WriteLine(response.Cookies[0].Value);
            return response.Cookies;
        }

    }
}
