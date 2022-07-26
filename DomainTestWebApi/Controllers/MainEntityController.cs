using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DomainTestWebApi.Models;
using DomainTestWebApi.Resources;
using DomainTestWebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DomainTestWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainEntityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMainEntityService _mainEntityService;
        
        public MainEntityController(ILogger<MainEntityController> logger, IMainEntityService mainEntityService, IMapper mapper)
        {
            _mainEntityService = mainEntityService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MainEntityResource>> GetAllAsync()
        {
            var mainEntities = await _mainEntityService.ListAsync();
            var resources = _mapper.Map<IEnumerable<MainEntity>, IEnumerable<MainEntityResource>>(mainEntities);
            
            return resources;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mainEntityService.GetByIdAsync(id);
            
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            
            return Ok(_mapper.Map<MainEntity, MainEntityResource>(result.MainEntity));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUpdateMainEntityResource mainEntityResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var mainEntity = _mapper.Map<CreateUpdateMainEntityResource, MainEntity>(mainEntityResource);

            mainEntity.Id = Guid.NewGuid();
            mainEntity.DateTimeMainProperty = DateTime.UtcNow;

            var result = await _mainEntityService.SaveAsync(mainEntity);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(_mapper.Map<MainEntity, MainEntityResource>(result.MainEntity));

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] CreateUpdateMainEntityResource mainEntityResource)
        {
            var mainEntity = _mapper.Map<CreateUpdateMainEntityResource, MainEntity>(mainEntityResource);

            var result = await  _mainEntityService.UpdateAsync(id, mainEntity);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(_mapper.Map<MainEntity, MainEntityResource>(result.MainEntity));
          
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        
        {
            var result = await  _mainEntityService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            
            return NoContent();
        }
    }
}