using KweetService.Data.Context;
using KweetService.Data.Entities;
using KweetService.Domain.Text.Parsers;
using Microsoft.EntityFrameworkCore;

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

        Task<IEnumerable<Kweet>> FindByUserId(Guid userId);
    }

    public class KweetRepository : IKweetRepository
    {
        private readonly IDataContext context;

        public KweetRepository(IDataContext context)
        {
            this.context = context;
        }
        
        public async Task<Kweet> Add(Kweet kweet)
        {
            var kweetEntity = new KweetEntity
            {
                Id = kweet.Id,
                AuthorId = kweet.AuthorId,
                CreatedAt = kweet.CreatedAt,
                Text = kweet.Text.Content,
            };
            
            await context.Kweets.AddAsync(kweetEntity);
            await context.SaveChangesAsync();

            return kweet;
        }

        public async Task<IEnumerable<Kweet>> FindAll()
        {
            var foundKweets = await context.Kweets.ToListAsync();

            var kweets = foundKweets.Select(x => new Kweet()
            {
                Id = x.Id,
                AuthorId = x.AuthorId,
                CreatedAt = x.CreatedAt,
                Text = KweetTextParser.Parse(x.Text),
            });
            
            return kweets;
        }

        public async Task<IEnumerable<Kweet>> FindByUserId(Guid userId)
        {
            var foundKweets = await context.Kweets.Where(x => x.AuthorId == userId).ToListAsync();
            
            var kweets = foundKweets.Select(x => new Kweet()
            {
                Id = x.Id,
                AuthorId = x.AuthorId,
                CreatedAt = x.CreatedAt,
                Text = KweetTextParser.Parse(x.Text),
            });
            
            return kweets;
        }
    }
}
