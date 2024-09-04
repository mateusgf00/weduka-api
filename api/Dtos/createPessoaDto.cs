using System.ComponentModel.DataAnnotations;

public class CreatePessoaDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }
    public List<ContatoDto> Contatos { get; set; } = new List<ContatoDto>();
}

public class ContatoDto
{
    public string Tipo { get; set; }
    public string Valor { get; set; }
}