using MayBlog.Application.Abstrakctions;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MayBlog.Application.UseCases.Post.Commands
{
    public class UpdatePostCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }

    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IApplictionDbContext _context;

        public UpdatePostCommandHandler(IApplictionDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Posts.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Post with ID {request.Id} not found.");
            }

            entity.Title = request.Title;
            entity.Content = request.Content;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }


    }
}


