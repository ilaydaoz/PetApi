namespace Pet.Core.Application.Services.Commands.Insert.Category
{
    public class CategoryInsertCommandResponse 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
    }
}
