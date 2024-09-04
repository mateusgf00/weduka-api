using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Contato
    {
        [Key]
        public int Id { get; set; }

        public string Tipo { get; set; }

        public string Valor { get; set; }

        public int PessoaId { get; set; }

        public Pessoa Pessoa { get; set; }
    }
}

