using Shared.Pet.Entity;

namespace Pet.Core.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public Category? ParentCategory { get; set;}

    }
}
