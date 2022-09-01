using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BartenderMVCRutter.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }

        public String? Customer { get; set; }

        public String? OrderItems { get; set; }
    }
}
