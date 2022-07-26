using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainTestWebApi.Models;

namespace DomainTestWebApi.Persistence.Repositories
{
    public interface IMainEntityRepository
    {
        Task<IEnumerable<MainEntity>> ListAsync();
        Task<MainEntity> GetByIdAsync(Guid id);
        Task AddAsync(MainEntity mainEntity);
        void Update(MainEntity mainEntity);
        void Delete(MainEntity mainEntity);
        bool IsUniqueProperty(string property);
    }
}