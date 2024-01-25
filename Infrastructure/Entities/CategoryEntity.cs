using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities
{
    public class CategoryEntity
    {
        [Key] 
        public int Id { get; set; }

        [Required]
        public string CategoryName { get; set; } = null!;
    }
}
