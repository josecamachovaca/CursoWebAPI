using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace WebAPISeflHosted
{
    class Program
    {
        // comment lesson2.1
        static void Main(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:8000");
            config.Routes.MapHttpRoute("default",
                "api/{controller}/{id}",
                new {controller="Home", id=RouteParameter.Optional}
                );

            var server = new HttpSelfHostServer(config);
            var task = server.OpenAsync();
            task.Wait();
            Console.WriteLine("Web API iniciada en http://localhost:8000");
            Console.ReadLine();
        }
    }
}
