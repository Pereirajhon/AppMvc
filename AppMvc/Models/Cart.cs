using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMvc.Models
{
    public class Cart
    {
        [Key]
        public int CartId {get; set;}
        public Store? Store {get; set;}
        public List<Store>? CartItems { get; set; }
        public double TotalValue {get; set;}
    }
}
