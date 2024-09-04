using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
	public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        public ICollection<Contato> Contatos { get; set; } = new List<Contato>();
    }
}

