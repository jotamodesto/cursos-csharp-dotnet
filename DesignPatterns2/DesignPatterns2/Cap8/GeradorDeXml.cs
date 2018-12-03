using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace DesignPatterns2.Cap8
{
    class GeradorDeXml
    {
        public string GeraXml(object o)
        {
            XmlSerializer serializer = new XmlSerializer(o.GetType());
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, o);
            string xml = writer.ToString();
            writer.Close();

            return xml;
        }
    }
}
