using System.Xml.Serialization;

namespace PortMoni.MODEL
{
    public class Papel
    {
        [XmlAttribute]
        public string Codigo { get; set; }
        [XmlAttribute]
        public string Nome { get; set; }
        [XmlAttribute]
        public string Ibovespa { get; set; }
        [XmlAttribute]
        public string Data { get; set; }
        [XmlAttribute]
        public string Abertura { get; set; }
        [XmlAttribute]
        public string Minimo { get; set; }
        [XmlAttribute]
        public string Maximo { get; set; }
        [XmlAttribute]
        public string Medio { get; set; }
        [XmlAttribute]
        public string Ultimo { get; set; }
        [XmlAttribute]
        public string Oscilacao { get; set; }
    }
}
