using System.Xml.Serialization;

namespace BlazorPunchOutTest.Controllers
{

    [XmlRoot("cXML")]
    public class CXML
    {
        [XmlAttribute("payloadID")]
        public string PayloadID { get; set; }

        [XmlAttribute("timestamp")]
        public string Timestamp { get; set; }

        [XmlElement("Header")]
        public Header Header { get; set; }

        [XmlElement("Request")]
        public Request Request { get; set; }
    }

    public class Header
    {
        [XmlElement("From")]
        public From From { get; set; }

        [XmlElement("To")]
        public To To { get; set; }

        [XmlElement("Sender")]
        public Sender Sender { get; set; }
    }

    public class From
    {
        [XmlElement("Credential")]
        public Credential Credential { get; set; }
    }

    public class To
    {
        [XmlElement("Credential")]
        public Credential Credential { get; set; }
    }

    public class Sender
    {
        [XmlElement("Credential")]
        public Credential Credential { get; set; }

        [XmlElement("UserAgent")]
        public string UserAgent { get; set; }
    }

    public class Credential
    {
        [XmlAttribute("domain")]
        public string Domain { get; set; }

        [XmlElement("Identity")]
        public string Identity { get; set; }

        [XmlElement("SharedSecret")]
        public string SharedSecret { get; set; }
    }

    public class Request
    {
        [XmlAttribute("deploymentMode")]
        public string DeploymentMode { get; set; }

        [XmlElement("PunchOutSetupRequest")]
        public PunchOutSetupRequest PunchOutSetupRequest { get; set; }
    }

    public class PunchOutSetupRequest
    {
        [XmlAttribute("operation")]
        public string Operation { get; set; }

        [XmlElement("BuyerCookie")]
        public string BuyerCookie { get; set; }

        [XmlElement("BrowserFormPost")]
        public BrowserFormPost BrowserFormPost { get; set; }

        [XmlIgnore]
        public Dictionary<string, string> Extrinsics { get; private set; } = new Dictionary<string, string>();

        [XmlElement("Extrinsic")]
        public List<Extrinsic> ExtrinsicList
        {
            get => new List<Extrinsic>(Extrinsics.Select(kvp => new Extrinsic { Name = kvp.Key, Value = kvp.Value }));
            set
            {
                Extrinsics.Clear();
                if (value != null)
                {
                    foreach (var extrinsic in value)
                    {
                        Extrinsics[extrinsic.Name] = extrinsic.Value;
                    }
                }
            }
        }
    }

    public class Extrinsic
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlText]
        public string Value { get; set; }
    }

    public class BrowserFormPost
    {
        [XmlElement("URL")]
        public string URL { get; set; }
    }

}
