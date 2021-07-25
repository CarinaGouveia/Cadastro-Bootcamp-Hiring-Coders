using System.ComponentModel.DataAnnotations;

namespace Hiring_Crud.Models
{
    public class Produtos
    {
        [Key]

        public int Id { get; set; }
        public string Produto { get; set; }
        public string Marca { get; set; }
        
   
    }
}