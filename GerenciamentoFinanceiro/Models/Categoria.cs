using System.ComponentModel.DataAnnotations;

namespace GerenciamentoFinanceiro.Models;

public class Categoria
{
    [Required(ErrorMessage = "Campo obrigatório")]
    public string CategoriaId { get; set; }

    public string Nome { get; set; }
}