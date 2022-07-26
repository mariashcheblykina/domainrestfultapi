using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainTestWebApi.Models;
using DomainTestWebApi.Services.Response;

namespace DomainTestWebApi.Services
{
    public interface IMainEntityService
    {
        Task<IEnumerable<MainEntity>> ListAsync();
        Task<MainEntityResponse> GetByIdAsync(Guid id);
        Task<MainEntityResponse> SaveAsync(MainEntity mainEntity);
        Task<MainEntityResponse> UpdateAsync(Guid id, MainEntity mainEntity);
        Task<MainEntityResponse> DeleteAsync(Guid id);
    }
}