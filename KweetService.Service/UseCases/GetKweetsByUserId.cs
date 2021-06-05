using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KweetService.Data;
using KweetService.Domain.Models;
using MediatR;

namespace KweetService.Service.UseCases
{
    public record GetKweetsByUserId(Guid UserId) : IRequest<IEnumerable<Kweet>>;

    public class GetKweetsByUserIdHandler : IRequestHandler<GetKweetsByUserId, IEnumerable<Kweet>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetKweetsByUserIdHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        public async Task<IEnumerable<Kweet>> Handle(GetKweetsByUserId request, CancellationToken cancellationToken)
        {
            return await this.unitOfWork.Kweets.FindByUserId(request.UserId);
        }
    }
}