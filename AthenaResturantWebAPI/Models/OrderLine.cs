using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAthena.Models
{
    public class OrderLine
    {

        [Key]
        public int ID { get; set; }

        [ForeignKey ("Product")]
        public int ProductID { get; set; }
        public Product product { get; set; }

        public int Quantity { get; set; } = 0;
    }
}
