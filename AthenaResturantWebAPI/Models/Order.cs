using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorAthena.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("OrderLine")]
        public int OrderLineID { get; set; }
        public OrderLine OrderLine { get; set; }
        public string? Comment { get; set; } 
        public bool Accepted { get; set; } = false;
        public DateTime TimeStamp { get; set; } = DateTime.Now;
        public string? KitchenComment { get; set; }
        public bool Delivered { get; set; } = false;
        public decimal? SaleAmount { get; set; } = decimal.Zero;
    }
}
