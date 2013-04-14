using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;
using System.Net.Http;
using System.Configuration;

namespace ETMS.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            ViewBag.smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
            return View();
            
        }
        public ActionResult AddInfo()
        {
            return View();
        }

        public ActionResult EmployeeSearchResults()
        {
            return View();
        }

        public ActionResult SupplierSearchResults()
        {
            return View();
        }
        public ActionResult ProvideObservation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ProvideObservation(FormCollection f)
        {
            string devid = f["devID"];  
            string BrowserAPIKey = "AIzaSyAO8_8doQ4xXoWWrTDhmZXdrgjylfMD1EM";
            Console.WriteLine("enterd");
            string message = f["message"]; 
            string tickerText = f["name"];
            
            string contentTitle = f["title"];
            string postData = "{ \"registration_ids\": [ \"" + devid + "\" ], \"data\": {\"tickerText\":\"" + tickerText + "\", \"contentTitle\":\"" + contentTitle + "\", \"message\": \"" + message + "\"}}";
            Console.WriteLine(message);
            Console.WriteLine(devid);
            string response= SendGCMNotification(BrowserAPIKey,postData);
            ViewBag.message = response;
            return View();
        }

        public string SendGCMNotification(string apiKey, string postData, string postDataContentType = "application/json")
        { 
         // http://www.codeproject.com/Articles/339162/Android-push-notification-implementation-using-ASP

            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);
            Console.WriteLine(postData);
            
            //
            //  MESSAGE CONTENT
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            //
            //  CREATE REQUEST
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
            Request.Method = "POST";
            Request.KeepAlive = false;
            Request.ContentType = postDataContentType;
            Request.Headers.Add(string.Format("Authorization: key={0}", apiKey));
            Request.ContentLength = byteArray.Length;
            
            Stream dataStream = Request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
                        
            //
            //  SEND MESSAGE
            try
            {
                WebResponse Response = Request.GetResponse();
                HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                {
                    var text = "Unauthorized - need new token";

                }
                else if (!ResponseCode.Equals(HttpStatusCode.OK))
                {
                    var text = "Response from web service isn't OK";
                }

                StreamReader Reader = new StreamReader(Response.GetResponseStream());
                string responseLine = Reader.ReadToEnd();
                Reader.Close();

                return responseLine;
            }
            catch (Exception)
            {

            }
            return "error";
        }


        public static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors)
            {
            return true;
            }      
        
        public ActionResult ReceiverDetails()
        {
            return View();
        }

        public ActionResult ReceiverInfo()
        {
            return View();
        }

        public ActionResult SearchHR()
        {
            return View();
        }

        public ActionResult SearchLocation()
        {
            return View();
        }

        public ActionResult Map()
        {
            return View();
        }
        public ActionResult LocationDisplay(string location)
        {

            ViewBag.jga = location;
            return View();
        }

        
    }
}
