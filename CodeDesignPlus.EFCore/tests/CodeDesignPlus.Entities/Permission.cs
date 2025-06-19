using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDesignPlus.Entities
{
    public class Permission
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public bool State { get; set; }
        public int IdUserCreator { get; set; }
        public DateTime DateCreated { get; set; }
        public List<AppPermission> AppPermissions = new List<AppPermission>();
        public List<RolePermission> RolePermissions = new List<RolePermission>();
    }

}
