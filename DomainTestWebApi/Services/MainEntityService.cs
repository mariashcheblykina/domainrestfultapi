using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DomainTestWebApi.Models;
using DomainTestWebApi.Persistence.Repositories;
using DomainTestWebApi.Services.Response;

namespace DomainTestWebApi.Services
{
    public class MainEntityService : IMainEntityService
    {
        private readonly IMainEntityRepository _mainEntityRepository;
        public MainEntityService(IMainEntityRepository mainEntityRepository)
        {
            _mainEntityRepository = mainEntityRepository;

        }
        public async Task<IEnumerable<MainEntity>> ListAsync()
        {
            return await _mainEntityRepository.ListAsync();
        }

        public async Task<MainEntityResponse> GetByIdAsync(Guid id)
        {
            var existingMainEntity = await _mainEntityRepository.GetByIdAsync(id);

            if (existingMainEntity == null)
            {
                return new MainEntityResponse("[MainEntity] MainEntity doesn't found");
            }

            return new MainEntityResponse(existingMainEntity);
        }

        public async Task<MainEntityResponse> SaveAsync(MainEntity mainEntity)
        {
            if (_mainEntityRepository.IsUniqueProperty(mainEntity.FirstMainProperty))
            {
                return new MainEntityResponse($"[MainEntity] MainEntity with such property {mainEntity.FirstMainProperty} is already exists");
            }
            
            try
            {
                await _mainEntityRepository.AddAsync(mainEntity);
                return new MainEntityResponse(mainEntity);
            }
            catch (Exception e)
            {
                return new MainEntityResponse($"[MainEntity] Unable to create main entity: {e.Message}");
            }
        }

        public async Task<MainEntityResponse> UpdateAsync(Guid id, MainEntity mainEntity)
        {
            var existingMainEntity = await _mainEntityRepository.GetByIdAsync(id);

            if (existingMainEntity == null)
            {
                return new MainEntityResponse("[MainEntity] MainEntity doesn't found");
            }
            
            if (_mainEntityRepository.IsUniqueProperty(mainEntity.FirstMainProperty))
            {
                return new MainEntityResponse($"[MainEntity] MainEntity with such property {mainEntity.FirstMainProperty} is already exists");
            }
            
            try
            {
                _mainEntityRepository.Update(existingMainEntity);
                return new MainEntityResponse(existingMainEntity);
            }
            catch (Exception e)
            {
                return new MainEntityResponse($"[MainEntity] Unable to update MainEntity: {e.Message}");
            }
        }

        public async Task<MainEntityResponse> DeleteAsync(Guid id)
        {
            //todo: 
            var existingMainEntity = await _mainEntityRepository.GetByIdAsync(id);

            if (existingMainEntity == null)
            {
                return new MainEntityResponse("[MainEntity] MainEntity doesn't found");
            }
            
            try
            {
                _mainEntityRepository.Delete(existingMainEntity);
                return new MainEntityResponse(existingMainEntity);
            }
            catch (Exception e)
            {
                return new MainEntityResponse($"[MainEntity] Unable to delete MainEntity: {e.Message}");
            }
        }
    }
}