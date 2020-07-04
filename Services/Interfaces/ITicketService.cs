using CustomerSupport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSupport.Services.Interfaces
{
    public interface ITicketService
    {
        List<Ticket> GetAll();
        Ticket GetById(int id);
        void Create(string title, string message, string userId);
        List<Ticket> GetAllForUser(string userId);
        void Delete(int id);
        void SetStatus(int id, string status);
    }
}
