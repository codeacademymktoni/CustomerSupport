using CustomerSupport.Models;
using CustomerSupport.Repositories.Interfaces;
using CustomerSupport.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace CustomerSupport.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            this.ticketRepository = ticketRepository;
        }

        public void Create(string title, string message, string userId)
        {
            var newTicket = new Ticket()
            {
               Title = title,
               Message = message,
               ClientId = userId,
               DateCreated = DateTime.Now,
            };
            ticketRepository.Add(newTicket);
        }

        public void Delete(int id)
        {
            var ticket = GetById(id);
            ticket.IsDeleted = true;
            ticket.Status = StatusEnum.Done;
            ticket.DateClosed = DateTime.Now;
            ticketRepository.Update(ticket);
        }

        public List<Ticket> GetAll()
        {
            return ticketRepository.GetAll();
        }

        public List<Ticket> GetAllForUser(string userId)
        {
            return ticketRepository.GetAllForUser(userId);
        }

        public Ticket GetById(int id)
        {
            return ticketRepository.GetById(id);
        }

        public void SetStatus(int id, string status)
        {
            StatusEnum result = (StatusEnum)Enum.Parse(typeof(StatusEnum), status);

            var ticket = ticketRepository.GetById(id);
            if (status == "Done")
            {
                ticket.DateClosed = DateTime.Now;
            }
            ticket.Status = result;

            ticketRepository.Update(ticket);
        }
    }
}
