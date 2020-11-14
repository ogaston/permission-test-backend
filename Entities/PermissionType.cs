using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.Entities
{
    public class PermissionType
    {
        public int permissionTypeID { get; set; }
        public string description { get; set; }
    }
}
