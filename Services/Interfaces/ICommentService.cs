namespace CustomerSupport.Services
{
    public interface ICommentService
    {
        void Add(string message, int ticketId, string userId);
    }
}