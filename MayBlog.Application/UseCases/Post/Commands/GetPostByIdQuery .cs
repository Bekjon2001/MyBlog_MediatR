using MayBlog.Application.Abstrakctions;
using MediatR;
using PostEntity = MyBlog.Domain.Entities.Post;


namespace MyBlog.Application.UseCases.Querys
{
    public class GetPostByIdQuery : IRequest<PostEntity>
    {
        public int Id { get; set; }

        public GetPostByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, PostEntity>
    {
        private readonly IApplictionDbContext _context;

        public GetPostByIdQueryHandler(IApplictionDbContext context)
        {
            _context = context;
        }

        public async Task<PostEntity> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Posts.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
                throw new KeyNotFoundException($"Post with ID {request.Id} not found.");

            return entity;
        }
    }
}

