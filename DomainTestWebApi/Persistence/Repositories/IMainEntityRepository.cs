using System.Collections.Generic;
using System.Threading.Tasks;
using DomainTestWebApi.Models;

namespace DomainTestWebApi.Repositories
{
    public interface IMainEntityRepository
    {
        Task<IEnumerable<MainEntity>> ListAsync();
    }
}