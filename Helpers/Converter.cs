using CustomerSupport.Models;
using CustomerSupport.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSupport.Helpers
{
    public static class Converter
    {
        internal static TicketViewModel ToViewModel(this Ticket ticket)
        {
            return new TicketViewModel
            {
                Id = ticket.Id,
                Title = ticket.Title,
                Message = ticket.Message,
                Status = ticket.Status,
                DateClosed = ticket.DateClosed,
                DateCreated = ticket.DateCreated,
                ClientId = ticket.ClientId,
                UserEmail = ticket.Client?.Email,
                Comments = ticket.Comments?
                .Select(x => x.ToViewModel())
                .ToList(),
            };
        }
        public static CommentViewModel ToViewModel(this Comment comment)
        {
            return new CommentViewModel
            {
                Message = comment.Message,
                DateCreated = comment.DateCreated,
                Email = comment.User.Email,
            };
        }
    }
}
