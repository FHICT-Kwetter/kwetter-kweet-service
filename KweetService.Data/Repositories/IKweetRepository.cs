namespace KweetService.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using KweetService.Domain.Models;

    public interface IKweetRepository
    {
        Task<Kweet> Add(Kweet kweet);

        Task<Kweet> FindById(Guid kweetId);
    }

    public class KweetRepository : IKweetRepository
    {
        private static IList<Kweet> kweets = new List<Kweet>();

        public async Task<Kweet> Add(Kweet kweet)
        {
            kweets.Add(kweet);
            return kweet;
        }

        public async Task<Kweet> FindById(Guid kweetId)
        {
            return kweets.FirstOrDefault(x => x.Id == kweetId);
        }
    }
}