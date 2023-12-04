using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMvc.Models
{
    public class Iphone
    {
        [Key]
        public int Id {get; set;}

        [Required(ErrorMessage = "Campo obrigatório")]
        public string? Model {get; set;}

        [Required(ErrorMessage = "Campo obrigatório")]
        [NotMapped]
        [DisplayName("ImagemProduto")]
        public IFormFile? ImagemUpload {get; set;}

        public string? Imagem {get; set;}
        
        [Required(ErrorMessage = "Campo obrigatório")]
        public double? Price {get; set;}
    }
}
