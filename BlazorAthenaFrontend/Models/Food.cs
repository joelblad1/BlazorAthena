using BlazorAthena.Models;

namespace BlazorAthenaFrontend.Models
{
    public class Food : Product
    {
        bool Lactose { get; set; } = false;
        bool Nuts { get; set; } = false;
    }
}
