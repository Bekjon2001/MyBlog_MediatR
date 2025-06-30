using MayBlog.Application.UseCases.Post.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MayBlog.Application.Abstrakctions; 

namespace MayBlog.Application.UseCases.Post.Querys
{
    public class GetPostsQuery : IRequest<List<PostDto>>
    {
    }

    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<PostDto>>
    {
        private readonly IApplictionDbContext _dbcontext;

        public GetPostsQueryHandler(IApplictionDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

       
        public async Task<List<PostDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _dbcontext.Posts
                .Select(x => new PostDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                })
                .ToListAsync(cancellationToken);

            return posts;
        }
    }
}

