using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KweetService.Data;
using KweetService.Domain.Models;
using MediatR;

namespace KweetService.Service.UseCases
{
    public record ListKweets : IRequest<IEnumerable<Kweet>>;
    
    public class ListKweetsHandler : IRequestHandler<ListKweets, IEnumerable<Kweet>>
    {
        private readonly IUnitOfWork unitOfWork;

        public ListKweetsHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Kweet>> Handle(ListKweets request, CancellationToken cancellationToken)
        {
            return await this.unitOfWork.Kweets.FindAll();
        }
    }
}