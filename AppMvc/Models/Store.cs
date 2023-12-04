using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMvc.Models
{
    public class Store
    {
        [Key]
        public int StoreId {get; set;}
        [Required(ErrorMessage = "Campo obrigatório")]
        public string? Name {get; set;}
        [Required(ErrorMessage = "Campo obrigatório")]
        public string? CNPJ {get; set;}
   
        [Required(ErrorMessage = "Campo obrigatório")]
        public string? Telefone {get; set;}
        [Required(ErrorMessage = "Campo obrigatório")]
        public List<Iphone>? IphoneList { get; set; } 

        public Iphone? Iphone { get; set; }
        
    }
}
