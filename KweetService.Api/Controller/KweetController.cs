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
    [Route("/api/v1/kweets")]
    [Authorize]
    public class KweetController : ControllerBase
    {
        private readonly IMediator mediator;

        public KweetController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateKweet([FromBody] CreateKweetRequest request)
        {
            var authorId = this.User.FindFirst("sub")?.Value;
            var result = await this.mediator.Send(new CreateKweet(request.Text, Guid.Parse(authorId)));
            return this.Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKweetById([FromRoute] string id)
        {
            var result = id;
            return this.Ok(result);
        }
    }
}