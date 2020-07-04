using CustomerSupport.Models;
using CustomerSupport.Repositories.Interfaces;

namespace CustomerSupport.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CustomerSupportDbContext context;

        public CommentRepository(CustomerSupportDbContext context)
        {
            this.context = context;
        }

        public void Add(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
        }
    }
}
