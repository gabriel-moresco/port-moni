using System.IO;
using System.Xml.Serialization;

namespace PortMoni.SERVICES
{
    public class Util
    {
        public static T Deserialize<T>(string input) where T : class
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }
    }
}
