using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlazorAthena.Models
{
    public class Product
    {

        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public bool Available { get; set; } = true;
        [ForeignKey("SubCategory")]
        public int SubCategory {  get; set; }



    }
}
