using System.Collections;
using System.Collections.Generic;
using AlfaSample.Data.Models;

namespace AlfaSample.Data.Services
{
    public interface IClientData
    {
        IEnumerable<Client> GetAll();
        Client GetClient(string companyName);
        void Add(Client client);
        void Update(Client client);
        void Delete(string companyName);
    }
}