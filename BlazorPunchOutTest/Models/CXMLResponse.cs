using System.Xml.Serialization;

namespace BlazorPunchOutTest.Controllers
{

    [XmlRoot("cXML")]
    public class CXMLResponse
    {
        [XmlAttribute("version")]
        public string Version { get; set; }

        [XmlAttribute("payloadID")]
        public string PayloadID { get; set; }

        [XmlAttribute("timestamp")]
        public string Timestamp { get; set; }

        [XmlElement("Response")]
        public Response Response { get; set; }
    }

    public class Response
    {
        [XmlElement("Status")]
        public Status Status { get; set; }

        [XmlElement("PunchOutSetupResponse")]
        public PunchOutSetupResponse PunchOutSetupResponse { get; set; }
    }

    public class Status
    {
        [XmlAttribute("code")]
        public string Code { get; set; }

        [XmlAttribute("text")]
        public string Text { get; set; }
    }

    public class PunchOutSetupResponse
    {
        [XmlElement("StartPage")]
        public StartPage StartPage { get; set; }
    }

    public class StartPage
    {
        [XmlElement("URL")]
        public string URL { get; set; }
    }
}
