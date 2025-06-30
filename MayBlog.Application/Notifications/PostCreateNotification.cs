using MediatR;
using System.Diagnostics;

namespace MayBlog.Application.Notifications
{
    public class PostCreateNotification : INotification
    {
        public int Id { get; set; }
    }
    
    public class PostCreateNotificationHandler1 : INotificationHandler<PostCreateNotification>
    {
        public async Task Handle(PostCreateNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Handle Javob1 {notification.Id}");
        }
    }
    public class PostCreateNotificationHandler2 : INotificationHandler<PostCreateNotification>
    {
        public async Task Handle(PostCreateNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Handle Javob2 {notification.Id}");
        }
    }
}
