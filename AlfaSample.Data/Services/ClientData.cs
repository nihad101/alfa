using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlfaSample.Data.Models;

namespace AlfaSample.Data.Services
{
    public class ClientData : IClientData
    {
        private readonly AlfaDbContext db;

        public ClientData(AlfaDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Client> GetAll()
        {
            return from c in db.Client
                orderby c.CompanyName
                select c;
        }

        public Client GetClient(string companyName)
        {
            return db.Client.FirstOrDefault(c => c.CompanyName == companyName);
        }

        public void Add(Client client)
        {
            db.Client.Add(client);
            db.SaveChanges();
        }

        public void Update(Client client)
        {
            var entry = db.Entry(client);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(string companyName)
        {
            var client  = db.Client.Find(companyName);
            db.Client.Remove(client);
            db.SaveChanges();
        }
    }
}
