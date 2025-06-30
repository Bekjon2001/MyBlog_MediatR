using MayBlog.Application.Abstrakctions;
using MayBlog.Application.Notifications;
using MediatR;
using MyBlog.Domain.Entities;


namespace MyBlog.Application.UseCases.Post.Commands
{
	public class CreatePostCommand : IRequest
	{
		public string Title { get; set; }
		public string Content { get; set; }
	}

	public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand>
	{
		private readonly IApplictionDbContext _context;
		private readonly IMediator _mediator;

		public CreatePostCommandHandler(IApplictionDbContext context, IMediator mediator)
		{
			_context = context;
			_mediator=mediator;
		}

		public async Task<Unit> Handle(CreatePostCommand request, CancellationToken cancellationToken)
		{
			var entity = new Domain.Entities.Post
			{
				Title = request.Title,
				Content = request.Content
			};

			var entry = await _context.Posts.AddAsync(entity,cancellationToken);
			await _context.SaveChangesAsync(cancellationToken);

			await _mediator.Publish(new PostCreateNotification()
			{
				Id = entity.Id,

			},cancellationToken);

			return Unit.Value;
		}
	}
}
