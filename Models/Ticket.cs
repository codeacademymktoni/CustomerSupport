﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSupport.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public DateTime? DateClosed { get; set; }
        [Required]
        public StatusEnum Status { get; set; }
        public User Client { get; set; }
        [Required]
        public string ClientId { get; set; }
        public bool IsDeleted { get; set; }

        public List<Comment> Comments { get; set; }

    }
}
