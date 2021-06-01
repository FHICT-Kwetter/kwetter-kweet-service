namespace KweetService.Service.UseCases
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using KweetService.Data;
    using KweetService.Domain.Models;
    using MediatR;

    public record ReadKweet(Guid KweetId) : IRequest<Kweet>;

    public class ReadKweetHandler : IRequestHandler<ReadKweet, Kweet>
    {
        private readonly IUnitOfWork unitOfWork;

        public ReadKweetHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Kweet> Handle(ReadKweet request, CancellationToken cancellationToken)
        {
            return await this.unitOfWork.Kweets.FindById(request.KweetId);
        }
    }
}