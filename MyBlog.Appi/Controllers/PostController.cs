using MayBlog.Application.UseCases.Post.Commands;
using MayBlog.Application.UseCases.Post.Querys;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.UseCases.Post.Commands;
using MyBlog.Application.UseCases.Querys;


namespace MyBlog.Appi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IMediator _middleware;

        public PostController(IMediator middleware)
        {
            _middleware=middleware;
        }

        [HttpPost]

        public async Task<IActionResult>CreatePost(CreatePostCommand command)
        {
            await _middleware.Send(command);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _middleware.Send(new GetPostsQuery());
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePostCommand command)
        {
            try
            {
                command.Id = id;
                await _middleware.Send(command);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Post with ID {id} not found.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            try
            {
                await _middleware.Send(new DeletePostCommand(id));
                return NoContent(); 
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Post with ID {id} not found.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _middleware.Send(new GetPostByIdQuery(id));
                return Ok(result);
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Post with ID {id} not found.");
            }
        }

    }
}
