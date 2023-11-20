using System.ComponentModel.DataAnnotations;

namespace BlazorAthena.Models
{
    public class SubCategory
    {
        [Key]
        public int ID { get; set; } 
        [Required]
        public string Name { get; set; }

    }
}
