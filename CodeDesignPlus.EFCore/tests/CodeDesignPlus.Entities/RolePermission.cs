using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeDesignPlus.Entities
{
    public class RolePermission
    {
        public int Id { get; set; }
        public int IdApplication { get; set; }
        public int IdPermission { get; set; }
        public string? NameRole { get; set; }
        public bool State { get; set; }
        public int IdUserCreator { get; set; }
        public DateTime DateCreated { get; set; }

        public Application Application = new Application();
        public Permission Permission = new Permission();
    }
}
