namespace KweetService.Api.Controller
{
    using System;
    using System.Net.Mime;
    using System.Threading.Tasks;
    using KweetService.Api.Contracts.Requests;
    using KweetService.Service.UseCases;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Route("/")]
    [Authorize]
    public class KweetController : ControllerBase
    {
        private readonly IMediator mediator;

        public KweetController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKweets()
        {
            var result = await this.mediator.Send(new ListKweets());
            return this.Ok(result);
        }

        [HttpGet("authors/{id}")]
        public async Task<IActionResult> GetKweetsByAuthorId([FromRoute] string id)
        {
            var results = await this.mediator.Send(new GetKweetsByUserId(Guid.Parse(id)));
            return this.Ok(results);
        }

        [HttpPost]
        public async Task<IActionResult> CreateKweet([FromBody] CreateKweetRequest request)
        {
            var authorId = Guid.Parse(this.User.FindFirst("sub")?.Value);
            var result = await this.mediator.Send(new CreateKweet(request.Text, authorId));
            return this.Ok(result);
        }
    }
}