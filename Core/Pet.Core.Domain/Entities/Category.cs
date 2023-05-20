using Shared.Pet.Entity;

namespace Pet.Core.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public Category Parent { get; set; }//üst kategorisi
        public List<Category> Children { get; set; } // alt kategorisi 

    }
}
