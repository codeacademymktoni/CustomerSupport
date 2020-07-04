using CustomerSupport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSupport.Repositories.Interfaces
{
    public interface ITicketRepository
    {
        List<Ticket> GetAll();
        Ticket GetById(int id);
        void Add(Ticket newTicket);
        List<Ticket> GetAllForUser(string userId);
        void Update(Ticket ticket);
    }
}
