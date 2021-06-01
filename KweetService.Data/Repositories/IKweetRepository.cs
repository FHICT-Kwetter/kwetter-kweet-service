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

        Task<IEnumerable<Kweet>> FindAll();
    }

    public class KweetRepository : IKweetRepository
    {
        private static IList<Kweet> kweets = new List<Kweet>();

        public async Task<Kweet> Add(Kweet kweet)
        {
            kweets.Add(kweet);
            return kweet;
        }

        public async Task<IEnumerable<Kweet>> FindAll()
        {
            return kweets;
        }
    }
}