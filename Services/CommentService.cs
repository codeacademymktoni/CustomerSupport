using CustomerSupport.Models;
using CustomerSupport.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSupport.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public void Add(string message, int ticketId, string userId)
        {
            Comment comment = new Comment() 
            {
                Message = message,
                TicketId = ticketId,
                UserId = userId,
                DateCreated = DateTime.Now,
            };
            commentRepository.Add(comment);
        }
    }
}
