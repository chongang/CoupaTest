using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using System.Text;
using System.Xml.Linq;


namespace BlazorPunchOutTest.Controllers
{

    [Route("Mock-Supplier-API")]
    [ApiController]
    public partial class MockSupplierAPIController : Controller
    {
        private static string _cxmlContent;
        // Example GET endpoint
        //        [HttpGet]
        //        public IActionResult Get()
        //        {

        //            string cxmlContent = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
        //<!DOCTYPE cXML SYSTEM 'http://xml.cxml.org/schemas/cXML/1.2.051/cXML.dtd'>
        //<cXML version=""1.2.008"" payloadID=""7bf18106-2dc7-443f-b18d-153a4724b7damatthewchardin.ang.ca@mhi.com"" timestamp=""2024-10-25T08:38:37+00:00"">
        //	<Response>
        //		<Status code=""200"" text=""OK""/>
        //		<PunchOutSetupResponse>
        //			<StartPage>
        //				<URL>https://www.lyreco.com/webshop/openHomePage.do?dcToken=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzZXNzaW9uSWQiOiJCM0VBOUQ0RjNGNTk2RTNDQkUxRTU1QzY4MjQzOURFNi53c2x0ZmExNHh6MzYzd3R5IiwibGFuZ3VhZ2VDb3VudHJ5IjoiRU5TRyJ9._rccrGhFlUliUfAHWg9tQ0gPunSzUaz6rXcwFWzlE-o&amp;lc=ENSG</URL>
        //			</StartPage>
        //		</PunchOutSetupResponse>
        //	</Response>
        //</cXML>";
        //            if (string.IsNullOrEmpty(cxmlContent))
        //            {
        //                return NotFound("No CXML content available.");
        //            }


        //            if (string.IsNullOrEmpty(cxmlContent))
        //            {
        //                return BadRequest("CXML content cannot be empty.");
        //            }

        //            return Content(cxmlContent, "application/xml"); // Echo back the received content
        //        }


        [HttpGet]
        public async Task<IActionResult> CheckCookie()
        {
            if (Request.Cookies.TryGetValue("userEmail", out var userEmail))
            {
                return Ok($"Cookie found! User email: {userEmail}");
            }
            else
            {
                return NotFound("Cookie not found.");
            }
        }

  


        private int x = 0;
        [HttpPost]
        public async Task<IActionResult> ReceiveXml()
        {



            CXML cxml;
            string url = "";
            string payloadID = "";
            string timeStamp = "";
            string xmlContent = "";

            using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                xmlContent = await reader.ReadToEndAsync();
            }


            // Read the raw XML content from the request body
            //using (var reader = new StreamReader(Request.Body, Encoding.UTF8))
            //{
            //    var xmlContent = await reader.ReadToEndAsync();
            //    XElement xml = XElement.Parse(xmlContent);
            //    payloadID = xml.Attribute("payloadID")?.Value;
            //    timeStamp = xml.Attribute("timestamp")?.Value;
            //    url = xml.Descendants("URL").FirstOrDefault()?.Value;
            //    string userEmail = xml.Descendants("Extrinsic")
            //                    .FirstOrDefault(e => (string)e.Attribute("name") == "UserEmail")?
            //                    .Value;

            //    var options = new CookieOptions
            //    {
            //        Expires = DateTimeOffset.UtcNow.AddDays(7), // Set expiration
            //        HttpOnly = true, // Prevents JavaScript access
            //        Secure = false, // Set to true if using HTTPS
            //        SameSite = SameSiteMode.Lax // Set SameSite to Lax
            //    };
            //    Response.Cookies.Append("userEmail", userEmail, options);
            //}

            //CheckCookie();


            //var requestContent = await Request.res.ReadAsStringAsync();
            //    System.Diagnostics.Debug.Print(x++.ToString());

            //    string cxmlContent = $@"<?xml version=""1.0"" encoding=""UTF-8""?>
            //<!DOCTYPE cXML SYSTEM 'http://xml.cxml.org/schemas/cXML/1.2.051/cXML.dtd'>
            //<cXML version=""1.2.008"" payloadID=""{payloadID}"" timestamp=""{timeStamp}"">
            //	<Response>
            //		<Status code=""200"" text=""OK""/>
            //		<PunchOutSetupResponse>
            //			<StartPage>
            //				<URL>https://localhost:7154/mock-supplier-home-page</URL>
            //			</StartPage>
            //		</PunchOutSetupResponse>
            //	</Response>
            //</cXML>";

          


            return Ok(xmlContent);
            }
        }
}

