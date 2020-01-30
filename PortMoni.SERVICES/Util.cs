using System.IO;
using System.Xml.Serialization;

namespace PortMoni.SERVICES
{
    public class Util
    {
        public static T Deserialize<T>(string xmlString, string xmlRootAttribute) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));

            using (StringReader sr = new StringReader(xmlString))
            {
                return (T)ser.Deserialize(sr);
            }
        }
    }
}
