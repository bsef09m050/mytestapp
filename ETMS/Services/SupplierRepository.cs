using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETMS.Models;
using System.Data;
namespace ETMS.Services
{
    public class SupplierRepository
    {
        DatabaseEntities1 db = new DatabaseEntities1();
        
        public SupplierRepository()
        { 
        
        }

        public void saveSupplier(Supplier s)
        {
            db.Suppliers.Add(s);
            db.SaveChanges();
        }

        public IEnumerable<Supplier> AllSuppliers()
        {
            List<Supplier> list = db.Suppliers.ToList();
            return list;
        }

        public Supplier getSupplier(int id)
        {
            Supplier c = db.Suppliers.Find(id);
            return c;
        }

        public void DeleteSupplier(Supplier s)
        {
            db.Suppliers.Remove(s);
            db.SaveChanges();
        }
        public void UpdateSupplier(Supplier s)
        {
            db.Entry(s).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}