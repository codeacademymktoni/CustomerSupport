using CustomerSupport.Models;
using CustomerSupport.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CustomerSupport.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly UserManager<User> userManager;

        public CommentController(ICommentService commentService, UserManager<User> userManager)
        {
            this.commentService = commentService;
            this.userManager = userManager;
        }
        [HttpPost]
        public IActionResult Add(string message, int ticketId)
        {
            if (!String.IsNullOrEmpty(message))
            {
                string userId = userManager.GetUserId(User);
                commentService.Add(message, ticketId, userId);
            }
            return RedirectToAction("Details", "Ticket", new { Id = ticketId });
        }
    }
}