namespace KweetService.Service.UseCases
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using KweetService.Data;
    using KweetService.Domain.Models;
    using KweetService.Domain.Text.Parsers;
    using MediatR;

    public record CreateKweet(string Text, Guid UserId) : IRequest<Kweet>;

    public class CreateKweetHandler : IRequestHandler<CreateKweet, Kweet>
    {
        private readonly IUnitOfWork unitOfWork;

        public CreateKweetHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Kweet> Handle(CreateKweet request, CancellationToken cancellationToken)
        {
            var kweet = new Kweet
            {
                Id = Guid.NewGuid(),
                AuthorId = request.UserId,
                CreatedAt = DateTime.Now,
                Text = KweetTextParser.Parse(request.Text),
            };

            await this.unitOfWork.Kweets.Add(kweet);

            return kweet;
        }
    }
}