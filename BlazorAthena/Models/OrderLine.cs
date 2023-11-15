using System.ComponentModel.DataAnnotations;

namespace BlazorAthena.Models
{
    public class OrderLine
    {

        [Key]
        public int OrderLineID { get; set; }
        public int ProductID { get; set; }

        public int Quantity { get; set; } = 0;
    }
}
