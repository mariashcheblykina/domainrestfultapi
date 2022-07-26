using System.Threading.Tasks;
using DomainTestWebApi.Persistence.Contexts;

namespace DomainTestWebApi.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DomainDbContext _context;

        protected BaseRepository(DomainDbContext context)
        {
            _context = context;
        }
        
     
    }
}