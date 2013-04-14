using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETMS.Models;
using System.Data;
using ETMS.Controllers;
namespace ETMS.Services
{
    public class EmployeeRepository
    {
        DatabaseEntities1 db = new DatabaseEntities1();
        HomeController e;
        public EmployeeRepository()
        {
            this.e = new HomeController(); 
        }

        public void saveEmployee(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
        }

        public IEnumerable<Employee> AllEmployees()
        {
            List<Employee> list = db.Employees.ToList();
            return list;
        }

        public Employee getEmployee(int id)
        {
            Employee e = db.Employees.Find(id);
            return e;
        }

        public void DeleteEmployee(Employee e)
        {
            db.Employees.Remove(e);
            db.SaveChanges();
        }
        public void UpdateEmployee(Employee emp)
        {
            db.Entry(emp).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void SaveCallData(string no,string type,string duration,string datetime)
        {
            Track track = new Track();
            track.TContactNo = no;
            track.TCallType = type;
            track.TCallDuration = duration;
            track.TDateTime = datetime;
            db.Tracks.Add(track);
            db.SaveChanges();
        }

        public void SaveSMSData(string no, string type,string datetime)
        {
            SM sms = new SM();           
            sms.MContactNo = no;
            sms.MType = type;            
            sms.MDateTime = datetime;
            db.SMS.Add(sms);
            db.SaveChanges();
        }

        public List<Employee> getMatchedEmployees(string name)
        {
            List<Employee> ed = db.Employees.Where(od => od.FirstName.Contains(name)).ToList();
            return ed;
        }
    }
}