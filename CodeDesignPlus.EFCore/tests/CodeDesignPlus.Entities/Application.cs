namespace CodeDesignPlus.Entities
{
    public class Application
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool State { get; set; }
        public int IdUserCreator { get; set; }
        public DateTime DateCreated { get; set; }
        public List<AppPermission> AppPermissions = new List<AppPermission>();
        public List<RolePermission> RolePermissions = new List<RolePermission>();
    }
}
