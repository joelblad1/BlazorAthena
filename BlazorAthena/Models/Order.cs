using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAthena.Models
{
    public class Order
    {
        // känns klar
        [Key]
        public int OrderID { get; set; }
        [ForeignKey("OrderLine")]
        public int OrderLineID { get; set; }
        public string? Comment { get; set; } 
        public bool Accepted { get; set; } = false;
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public string? KitchenComment { get; set; }
        public bool Delivered { get; set; } = false;

    }
}
