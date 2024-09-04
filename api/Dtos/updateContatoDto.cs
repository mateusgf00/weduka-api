using System.ComponentModel.DataAnnotations;

public class UpdatePessoaDto
{
    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }
}