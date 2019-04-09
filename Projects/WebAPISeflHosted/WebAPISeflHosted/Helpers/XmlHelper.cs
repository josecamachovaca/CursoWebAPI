using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using WebAPISeflHosted.Models;

namespace WebAPISeflHosted.Helpers
{
    public static class XmlHelper
    {
        public static XmlDocument CargaXml(string ruta)
        {
            XmlDocument xmlRegresa = new XmlDocument();
            xmlRegresa.Load(ruta);
            return xmlRegresa;
        }

        public static List<Persona> CargaListaFromXml(XmlDocument xdoc)
        {
            List<Persona> lstRegresa = new List<Models.Persona>();
            Persona p = new Persona();
            foreach (XmlNode n in xdoc.SelectNodes("/Personas/Persona"))
            {
                p = new Persona();
                p.id = n.SelectSingleNode("id").InnerText;
                p.nombre = n.SelectSingleNode("nombre").InnerText;
                p.email = n.SelectSingleNode("email").InnerText;
                lstRegresa.Add(p);
            }
            return lstRegresa;
        }

        public static void GuardaXmlFromLista(List<Persona> lstPersonas, string ruta)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.AppendChild(xDoc.CreateElement("Personas"));
            foreach(Persona p in lstPersonas)
            {
                XmlElement elem = xDoc.CreateElement("Persona");
                elem.AppendChild(xDoc.CreateElement("id")).InnerText = p.id;
                elem.AppendChild(xDoc.CreateElement("nombre")).InnerText = p.nombre;
                elem.AppendChild(xDoc.CreateElement("email")).InnerText = p.email;
                xDoc.DocumentElement.AppendChild(elem);
            }
            xDoc.Save(ruta);
        }
    }
}