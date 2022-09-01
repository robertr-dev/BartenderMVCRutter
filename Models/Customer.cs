using System.ComponentModel.DataAnnotations;

namespace BartenderMVCRutter.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }

    }
}
