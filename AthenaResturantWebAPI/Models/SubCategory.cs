using System.ComponentModel.DataAnnotations;

namespace BlazorAthena.Models
{
    public class SubCategory
    {
        [Key]
        public int ID { get; set; } 
        [Required]
        string Name { get; set; }

    }
}
