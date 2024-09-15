using System.Xml.Serialization;

namespace EDM_SITEK
{
    [XmlRoot(ElementName = "OBJECT")]
    public class OBJECT
    {

        [XmlAttribute(AttributeName = "ID")]
        public int ID { get; set; }

        [XmlAttribute(AttributeName = "OBJECTID")]
        public int OBJECTID { get; set; }

        [XmlAttribute(AttributeName = "OBJECTGUID")]
        public string OBJECTGUID { get; set; }

        [XmlAttribute(AttributeName = "CHANGEID")]
        public int CHANGEID { get; set; }

        [XmlAttribute(AttributeName = "NAME")]
        public string NAME { get; set; }

        [XmlAttribute(AttributeName = "TYPENAME")]
        public string TYPENAME { get; set; }

        [XmlAttribute(AttributeName = "LEVEL")]
        public int LEVEL { get; set; }

        [XmlAttribute(AttributeName = "OPERTYPEID")]
        public int OPERTYPEID { get; set; }

        [XmlAttribute(AttributeName = "PREVID")]
        public int PREVID { get; set; }

        [XmlAttribute(AttributeName = "NEXTID")]
        public int NEXTID { get; set; }

        [XmlAttribute(AttributeName = "UPDATEDATE")]
        public DateTime UPDATEDATE { get; set; }

        [XmlAttribute(AttributeName = "STARTDATE")]
        public DateTime STARTDATE { get; set; }

        [XmlAttribute(AttributeName = "ENDDATE")]
        public DateTime ENDDATE { get; set; }

        [XmlAttribute(AttributeName = "ISACTUAL")]
        public int ISACTUAL { get; set; }

        [XmlAttribute(AttributeName = "ISACTIVE")]
        public int ISACTIVE { get; set; }
    }

    [XmlRoot(ElementName = "ADDRESSOBJECTS")]
    public class ADDRESSOBJECTS
    {

        [XmlElement(ElementName = "OBJECT")]
        public List<OBJECT> OBJECT { get; set; }
    }
}
