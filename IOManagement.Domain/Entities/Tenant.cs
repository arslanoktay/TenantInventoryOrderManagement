namespace IOManagement.Domain.Entities
{
    public class Tenant : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
