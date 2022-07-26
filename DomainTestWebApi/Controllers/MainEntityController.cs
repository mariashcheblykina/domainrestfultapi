using System;
using System.Collections.Generic;
using DomainTestWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DomainTestWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DomainController : ControllerBase
    {
        private readonly ILogger<DomainController> _logger;
        
        public DomainController(ILogger<DomainController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<MainEntity> Get()
        {
            return new List<MainEntity>();
        }
        
        [HttpPost]
        public IEnumerable<MainEntity> Post([FromBody] MainEntity mainEntity)
        {
            return new List<MainEntity>();
        }
        
        [HttpPut]
        public IEnumerable<MainEntity> Put(Guid id)
        {
            return new List<MainEntity>();
        }
        
        [HttpDelete]
        public IEnumerable<MainEntity> Delete(Guid id)
        {
            return new List<MainEntity>();
        }
        
        
        
        

    }
}