using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETMS.Services;
using ETMS.Models;
namespace ETMS.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/

        private  ProjectRepository pRepo;        
        public ProjectController()
        {
            this.pRepo = new ProjectRepository();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewProjects()
        {
            IEnumerable<Project> c = pRepo.AllProjects();
            return View(c);
        }
        public ActionResult ViewProject(int id=0)
        {
            Project c = pRepo.getProject(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);            
        }
        [HttpPost]
        public ActionResult UpdateProjectInfo(Project p)
        {
            if (ModelState.IsValid)
            {
                pRepo.UpdateProject(p);
            }
            return RedirectToAction("ViewProjects");            
        }

        public ActionResult UpdateProjectInfo(int id = 0)
        {
            Project c = pRepo.getProject(id);
            if (c == null)
            {
                return HttpNotFound();
            }
            return View(c);
        }
        [HttpPost, ActionName("DeleteProject")]
        public ActionResult DeleteP()
        {
            int Id = Convert.ToInt32(Request["PId"]);
            Project proj = pRepo.getProject(Id);
            pRepo.DeleteProject(proj);
            return RedirectToAction("ViewProjects");
        }

        [HttpGet]
        public ActionResult DeleteProject(int id = 0)
        {
            Project p = pRepo.getProject(id);
            return View(p);
        }

        public ActionResult AddProjectInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProjectInfo(Project e)
        {
            pRepo.saveProject(e);
            return RedirectToAction("ViewProjects");            
        }
        
    }

}
