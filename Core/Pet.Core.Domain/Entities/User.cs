using Shared.Pet.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pet.Core.Domain.Entities
{
   // [Table("User", Schema = "Pet")]
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
