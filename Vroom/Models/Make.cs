using System.ComponentModel.DataAnnotations;

namespace Vroom.Models
{
    public class Make
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        //[Display(Name = "Bike Name")]
        public string Name { get; set; }

      
    }
}
