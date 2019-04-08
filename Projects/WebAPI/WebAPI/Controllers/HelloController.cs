using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Xml.Serialization;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HelloController : ApiController
    {
        private string xmlFile = @"C:\temp\CursoWebAPI\personas.xml";
        private XmlDocument xmlDoc = new XmlDocument();
        private List<Persona> lstPersonas = new List<Persona>();
        private XmlSerializer serializer = new XmlSerializer(typeof(List<Persona>));

        public HelloController()
        {
            xmlDoc.Load(xmlFile);
            Persona p = new Persona();
            foreach(XmlNode n in xmlDoc.SelectNodes("/Personas/Persona"))
            {
                p = new Persona();
                p.id = n.SelectSingleNode("id").InnerText;
                p.nombre = n.SelectSingleNode("nombre").InnerText;
                p.email = n.SelectSingleNode("email").InnerText;
                lstPersonas.Add(p);
            }
        }
        public string Get()
        {
            return "Hello";
        }

        [HttpGet]
        [Route("api/Personas")]
        public List<Persona> GetPersonas()
        {
            return lstPersonas;
        }

        public Persona Get(string id)
        {
            return lstPersonas.FirstOrDefault<Persona>(p => p.id.Equals(id));
        }
    }
}
