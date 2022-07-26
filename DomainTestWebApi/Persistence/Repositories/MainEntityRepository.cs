using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainTestWebApi.Models;
using DomainTestWebApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DomainTestWebApi.Persistence.Repositories
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

        public async Task<MainEntity> GetByIdAsync(Guid id)
        {
            return await _context.MainEntities.FindAsync(id);
        }

        public async Task AddAsync(MainEntity mainEntity)
        {
            await _context.MainEntities.AddAsync(mainEntity);
            await _context.SaveChangesAsync();
        }

        public void Update(MainEntity mainEntity)
        {
            _context.MainEntities.Update(mainEntity);
            _context.SaveChanges();
        }

        public void Delete(MainEntity mainEntity)
        {
            _context.MainEntities.Remove(mainEntity);
            _context.SaveChanges();
        }

        public bool IsUniqueProperty(string property)
        {
            return _context.MainEntities.Any(e => e.FirstMainProperty.Equals(property));
        }
    }
}