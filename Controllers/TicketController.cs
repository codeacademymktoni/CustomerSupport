using CustomerSupport.Helpers;
using CustomerSupport.Models;
using CustomerSupport.Services.Interfaces;
using CustomerSupport.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CustomerSupport.Controllers
{
    [Authorize]
    public class TicketController : Controller
    {
        private readonly ITicketService ticketService;
        private readonly UserManager<User> userManager;

        public TicketController(ITicketService ticketService, UserManager<User> userManager)
        {
            this.ticketService = ticketService;
            this.userManager = userManager;
        }
        public IActionResult Home()
        {
            var dbTickets = new List<Ticket>();
            var viewModelList = new List<TicketViewModel>();
            if (User.IsInRole("Employee"))
            {
                dbTickets = ticketService.GetAll();
            }
            else
            {
                var userId = userManager.GetUserId(User);
                dbTickets = ticketService.GetAllForUser(userId);
            }
            viewModelList = dbTickets.Select(x => x.ToViewModel()).ToList();
            return View(viewModelList);
        }

        public IActionResult Details(int id)
        {
            var dbTicket = ticketService.GetById(id);
            var ticket = dbTicket.ToViewModel();
            return View(ticket);
        }

        public IActionResult Create()
        {
            var ticket = new CreateTicketViewModel();
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Create(CreateTicketViewModel ticketModel)
        {
            if (ModelState.IsValid)
            {
                var userId = userManager.GetUserId(User);
                ticketService.Create(ticketModel.Title, ticketModel.Message, userId);
                return RedirectToAction("Home");
            }
            return View(ticketModel);
        }

        public IActionResult Delete(int id)
        {
            ticketService.Delete(id);
            return RedirectToAction("Home");
        }
        [Authorize(Roles = "Employee")]
        public IActionResult SetStatus(int id, string status)
        {
            ticketService.SetStatus(id, status);
            return RedirectToAction("Home");
        }
    }
}
