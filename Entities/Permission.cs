using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Permissions.Entities
{
    public class Permission
    {
        public int permissionID { get; set; }
        [Required]
        public string employeeName { get; set; }
        [Required]
        public string employeeLastName{ get; set; }
        [Required]
        public PermissionType permissionType { get; set; }
        [Required]
        public DateTime createdAt { get; set; }
    }
}
