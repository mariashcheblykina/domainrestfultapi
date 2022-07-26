using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DomainTestWebApi.Models;
using DomainTestWebApi.Resources;
using DomainTestWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DomainTestWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MainEntityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMainEntityService _mainEntityService;
        
        //todo: add authentication
        //todo: add more related models
        //todo: add some db
        //todo: add unit tests
        
        public MainEntityController(IMainEntityService mainEntityService, IMapper mapper)
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

            return Created("MainEntity created",_mapper.Map<MainEntity, MainEntityResource>(result.MainEntity));

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(Guid id, [FromBody] CreateUpdateMainEntityResource mainEntityResource)
        {
            var mainEntity = _mapper.Map<CreateUpdateMainEntityResource, MainEntity>(mainEntityResource);

            var result = await  _mainEntityService.UpdateAsync(id, mainEntity);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Accepted(_mapper.Map<MainEntity, MainEntityResource>(result.MainEntity));
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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