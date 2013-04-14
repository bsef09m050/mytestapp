using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ETMS.Models;
using System.Data;
namespace ETMS.Services
{
    public class ProjectRepository 
    {
        DatabaseEntities1 db = new DatabaseEntities1();
        
        public ProjectRepository()
        { 
        
        }

        public void saveProject(Project p)
        {
            db.Projects.Add(p);
            db.SaveChanges();
        }

        public IEnumerable<Project> AllProjects()
        {
            List<Project> list = db.Projects.ToList();
            return list;
        }

        public Project getProject(int id)
        {
            Project p = db.Projects.Find(id);
            return p;
        }

        public void DeleteProject(Project e)
        {
            db.Projects.Remove(e);
            db.SaveChanges();
        }
        public void UpdateProject(Project p)
        {
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
