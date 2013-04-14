using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ETMS.Models;
using System.Data;
using System.Data.Objects;
using System.Data.Entity;


namespace ETMS.Services
{
    public class ClientRepository
    {
        DatabaseEntities1 db = new DatabaseEntities1();
        
        public ClientRepository()
        { 
        
        }

        public void saveClient(Client c)
        {
            db.Clients.Add(c);
            db.SaveChanges();
        }

        public IEnumerable<Client> AllClients()
        {
            List<Client> list = db.Clients.ToList();
            return list;
        }

        public Client getClient(int id)
        {
            Client c = db.Clients.Find(id);
            return c;
        }

        public void DeleteCleint(Client c)
        {
            db.Clients.Remove(c);
            db.SaveChanges();
        }
        public void UpdateClient(Client c)
        {
            db.Entry(c).State = EntityState.Modified;
            db.SaveChanges();
            try
            {
                
            }
            catch (OptimisticConcurrencyException)
            {
                
               // db.Refresh(RefreshMode.ClientWins, db.Articles);
                //context.SaveChanges();
            }
        }
    }
}