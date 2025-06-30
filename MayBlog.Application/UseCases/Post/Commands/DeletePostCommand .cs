using MayBlog.Application.Abstrakctions;
using MediatR;


namespace MyBlog.Application.UseCases.Post.Commands
{
    public class DeletePostCommand : IRequest
    {
        public int Id { get; set; }

        public DeletePostCommand(int id)
        {
            Id = id;
        }
    }

    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
    {
        private readonly IApplictionDbContext _context;

        public DeletePostCommandHandler(IApplictionDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Posts.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Post with ID {request.Id} not found.");
            }

            _context.Posts.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
