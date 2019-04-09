using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPISeflHosted.Controllers
{
    public class HomeController:ApiController
    {
        public string Get()
        {
            return "Hola Web API";
        }
        public string Get(string nombre)
        {
            return "Hola " + nombre;
        }
    }
}
