using System.IO;
using System.Xml.Serialization;

namespace PortMoni.UTIL
{
    public class Util
    {
        public static T DeserializeXml<T>(string xmlString, string xmlRootAttribute) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));

            using (StringReader sr = new StringReader(xmlString))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        public static T DeserializeXml<T>(string xmlPath)
        {
            T response = default(T);

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StreamReader reader = new StreamReader(xmlPath);
            response = (T)serializer.Deserialize(reader);
            reader.Close();

            return response;
        }

        public static string SerializeXml<T>(T myObject)
        {
            StringWriter stringWriter = new StringWriter();
            XmlSerializer writer = new XmlSerializer(typeof(T));
            writer.Serialize(stringWriter, myObject);
            string response = stringWriter.ToString();

            return response;
        }
    }
}
