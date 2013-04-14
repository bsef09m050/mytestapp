using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ETMS.Services;
using ETMS.Models;


namespace ETMS.Controllers
{
    public class EmployeeLocationController : ApiController
    {
        private EmployeeRepository erepo = new EmployeeRepository();
        public HttpResponseMessage  Get(string location)
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.RedirectMethod);            
            responseMessage.Headers.Location = new Uri("http://localhost:4000/Home/LocationDisplay?location="+location);
            return responseMessage;
        }
        public HttpResponseMessage GetTrackCall(string no,string type,string duration,string datetime)
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.RedirectMethod);
            responseMessage.Headers.Location = new Uri("http://localhost:4000/Employee/InsertCall?no=" + no +"&type="+type + "&duration="+duration+"&datetime="+datetime);
            return responseMessage;
           // erepo.SaveCallData(no,type,duration,datetime);
        }
        public HttpResponseMessage GetTrackSMS(string no,string type,string datetime)
        {
            var responseMessage = new HttpResponseMessage(HttpStatusCode.RedirectMethod);
            responseMessage.Headers.Location = new Uri("http://localhost:4000/Employee/InsertSMS?no=" + no + "&type=" + type + "&datetime=" + datetime);
            return responseMessage;
            // erepo.SaveCallData(no,type,duration,datetime);
        }   
    }
}
