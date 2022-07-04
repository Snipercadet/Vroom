using System.ComponentModel.DataAnnotations;
using Vroom.Data;

namespace Vroom.Models
{
    public class Model
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required")]
        [StringLength(255)]
        public string Name { get; set; }
        public Make Make { get; set; }
        public int MakeId { get; set; }
    }
}
