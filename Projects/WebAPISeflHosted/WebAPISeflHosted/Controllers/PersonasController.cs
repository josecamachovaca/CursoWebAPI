using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml;
using WebAPISeflHosted.Helpers;
using WebAPISeflHosted.Models;

namespace WebAPISeflHosted.Controllers
{
    public class PersonasController:ApiController
    {
        private string xmlFile = @"C:\temp\CursoWebAPI\personas.xml";
        private XmlDocument xmlDoc = new XmlDocument();
        private List<Persona> lstPersonas = new List<Persona>();

        public IHttpActionResult GetPersonas()
        {
            xmlDoc = XmlHelper.CargaXml(xmlFile);
            List<Persona> lstPersonas = XmlHelper.CargaListaFromXml(xmlDoc);
            if(lstPersonas.Count.Equals(0))
            {
                return NotFound();
            }
            return Ok(lstPersonas);
        }

        public IHttpActionResult Get(string id)
        {
            xmlDoc = XmlHelper.CargaXml(xmlFile);
            List<Persona> lstPersonas = XmlHelper.CargaListaFromXml(xmlDoc);
            Persona pers = lstPersonas.FirstOrDefault<Persona>(p => p.id.Equals(id));
            if(pers != null)
            {
                return Ok(pers);
            }
            else
            {
                return NotFound();
            }
        }
        public IHttpActionResult Post(Persona p)
        {
            xmlDoc = XmlHelper.CargaXml(xmlFile);
            List<Persona> lstPersonas = XmlHelper.CargaListaFromXml(xmlDoc);
            if(lstPersonas.Any<Persona>(x => x.id.Equals(p.id)))
            {
                return NotFound();
            }
            else
            {
                lstPersonas.Add(p);
                XmlHelper.GuardaXmlFromLista(lstPersonas, xmlFile);
                return Ok();
            }
        }
        public IHttpActionResult Put(Persona p)
        {
            xmlDoc = XmlHelper.CargaXml(xmlFile);
            List<Persona> lstPersonas = XmlHelper.CargaListaFromXml(xmlDoc);
            Persona pers = lstPersonas.FirstOrDefault(x => x.id.Equals(p.id));
            if (pers == null)
            {
                return NotFound();
            }
            else
            {
                pers.nombre = p.nombre;
                pers.email = p.email;
                XmlHelper.GuardaXmlFromLista(lstPersonas, xmlFile);
                return Ok();
            }
        }
        public IHttpActionResult Delete(string id)
        {
            xmlDoc = XmlHelper.CargaXml(xmlFile);
            List<Persona> lstPersonas = XmlHelper.CargaListaFromXml(xmlDoc);
            Persona p = lstPersonas.FirstOrDefault(x => x.id.Equals(id));
            if(p != null)
            {
                lstPersonas.Remove(p);
                XmlHelper.GuardaXmlFromLista(lstPersonas, xmlFile);
                return Ok();
            }
            return NotFound();
        }
    }
}
