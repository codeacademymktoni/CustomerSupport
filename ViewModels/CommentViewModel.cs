using System;

namespace CustomerSupport.ViewModels
{
    public class CommentViewModel
    {
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public string Email { get; set; }
    }
}
