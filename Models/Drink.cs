using System.ComponentModel.DataAnnotations;

namespace BartenderMVCRutter.Models
{
    public class Drink
    {
        [Key]
        public int DrinkID { get; set; }
        public string? DrinkName { get; set; }
        public string? DrinkDesc { get; set; }
        public float DrinkPrice { get; set; }

    }
}
