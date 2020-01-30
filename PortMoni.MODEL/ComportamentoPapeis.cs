using System.Collections.Generic;
using System.Xml.Serialization;

namespace PortMoni.MODEL
{
    [XmlRootAttribute("ComportamentoPapeis")]
    public class ComportamentoPapeis
    {
        [XmlElement("Papel")]
        public Papel[] Papeis { get; set; }
    }
}
