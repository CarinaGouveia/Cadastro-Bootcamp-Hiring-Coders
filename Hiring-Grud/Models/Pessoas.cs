using System.ComponentModel.DataAnnotations;

namespace Hiring_Crud.Models
{
    public class Pessoas
    {
        [Key]
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public int Telefone { get; set; }


    }
}