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
    public class PermissionTypeController : ControllerBase
    {
        
        private readonly ILogger<PermissionTypeController> _logger;
        private readonly PermissionTypeRepository _permissionTypeRepository;

        public PermissionTypeController(ILogger<PermissionTypeController> logger, PermissionTypeRepository permissionTypeRepository)
        {
            _logger = logger;
            _permissionTypeRepository = permissionTypeRepository;
        }

        [HttpGet]
        public async Task<List<PermissionType>> Get()
        {
            return await _permissionTypeRepository.GetAll();
        }


        [HttpPost]
        public async Task<PermissionType> Create([FromBody]PermissionType model)
        {
            return await _permissionTypeRepository.Add(model);
        }

    }
}
