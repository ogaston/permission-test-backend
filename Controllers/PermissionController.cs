using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Permissions.Entities;
using Permissions.Repositories;

namespace Permissions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        private ILogger<PermissionController> _logger;
        private PermissionRepository _permissionRepository;

        public PermissionController(ILogger<PermissionController> logger, PermissionRepository permissionRepository)
        {
            _logger = logger;
            _permissionRepository = permissionRepository;
        }

        [HttpGet]
        public async Task<List<Permission>> Get()
        {
            return await _permissionRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Permission> GetBy(int id)
        {
            return await _permissionRepository.GetById(id);
        }


        [HttpPost]
        public async Task<Permission> Create([FromBody] Permission model)
        {
            return await _permissionRepository.Add(model);
        }

        [HttpPut("{id}")]
        public async Task<Permission> Edit(int id, [FromBody] Permission model)
        {   bool exists = await _permissionRepository.Exists(id);
            if (!exists)
            {
                throw new Exception("Entity doesn't exists");
            }
            model.permissionID = id;
            return await _permissionRepository.Update(model);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var exist = await _permissionRepository.GetById(id);
            var succeded = await _permissionRepository.Delete(exist);
            if (succeded) return NoContent();
            return BadRequest();

        }

    }
}
