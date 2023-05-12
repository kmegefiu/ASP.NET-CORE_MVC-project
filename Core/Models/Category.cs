using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the display order")]
        [DisplayName("Display Order")]

        [Range(1,100,ErrorMessage ="Display Order must be between 1 and 100 only!")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
