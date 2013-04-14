using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ETMS.Models;
using ETMS.Services;
namespace ETMS.Controllers
{
    public class GetProjectsController : ApiController
    {
        private ProjectRepository sRepo;        
        public GetProjectsController()
        {
            this.sRepo = new ProjectRepository();
        }

        public IEnumerable<Project> GetP()
        {
            return sRepo.AllProjects();
        }       
    }
}
