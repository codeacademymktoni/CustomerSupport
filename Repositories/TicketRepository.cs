using CustomerSupport.Models;
using CustomerSupport.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSupport.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly CustomerSupportDbContext context;

        public TicketRepository(CustomerSupportDbContext context)
        {
            this.context = context;
        }

        public void Add(Ticket newTicket)
        {
            context.Tickets.Add(newTicket);
            context.SaveChanges();
        }

        public List<Ticket> GetAll()
        {
            return context.Tickets.Include(x => x.Client).ToList();
        }

        public List<Ticket> GetAllForUser(string userId)
        {
            return context.Tickets.Where(x => x.ClientId == userId && x.IsDeleted == false).ToList();
        }

        public Ticket GetById(int id)
        {
            return context.Tickets
                .Include(x => x.Comments)
                .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Ticket ticket)
        {
            context.Tickets.Update(ticket);
            context.SaveChanges();
        }
    }
}
