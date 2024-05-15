using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookyWeb.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Category Name")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Range should not be between 0 and 100")]
        public int DisplayOrder { get; set; }
       


    }
}
