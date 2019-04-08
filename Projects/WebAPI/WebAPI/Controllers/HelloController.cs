using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Xml.Serialization;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class HelloController : ApiController
    {
        private string xmlFile = @"C:\temp\CursoWebAPI\personas.xml";
        private XmlDocument xmlDoc = new XmlDocument();
        private List<Persona> lstPersonas = new List<Persona>();

        public HelloController()
        {
        }
        public string Get()
        {
            return "Hello";
        }

        [HttpGet]
        [Route("api/Personas")]
        public List<Persona> GetPersonas()
        {
            xmlDoc = XmlHelper.CargaXml(xmlFile);
            lstPersonas = XmlHelper.CargaListaFromXml(xmlDoc);
            return lstPersonas;
        }

        public Persona Get(string id)
        {
            return lstPersonas.FirstOrDefault<Persona>(p => p.id.Equals(id));
        }

        [HttpPost]
        [Route("api/PostNewPersona")]
        public IHttpActionResult PostNewPersona(Persona p)
        {
            xmlDoc = XmlHelper.CargaXml(xmlFile);
            lstPersonas = XmlHelper.CargaListaFromXml(xmlDoc);
            if (lstPersonas.Any<Persona>(xp => xp.id.Equals(p.id)))
            {
                return NotFound();
            }
            else
            {
                lstPersonas.Add(p);
                XmlHelper.GuardaXmlFromLista(lstPersonas, xmlFile);
                return Ok();
            }
            //System.Web.Http.Results
        }
    }
}
