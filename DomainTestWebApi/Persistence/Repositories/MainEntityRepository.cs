using System.Collections.Generic;
using System.Threading.Tasks;
using DomainTestWebApi.Models;
using DomainTestWebApi.Persistence.Contexts;
using DomainTestWebApi.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DomainTestWebApi.Repositories
{
    public class MainEntityRepository : BaseRepository, IMainEntityRepository
    {
  

        public MainEntityRepository(DomainDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<MainEntity>> ListAsync()
        {
            return await _context.MainEntities.ToListAsync();
        }
    }
}