using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GerenciamentoFinanceiro.Models;

public class Financeiro
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório")]
    public string Descricao { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório")]
    public double Valor { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório")]
    public DateTime DataOperacao { get; set; }
    
    [ValidateNever]
    public Categoria Categoria { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório")]
    public string CategoriaId { get; set; }
    
    [ValidateNever]
    public Transacao Transacao { get; set; }
    
    [Required(ErrorMessage = "Campo obrigatório")]
    public string TransacaoId { get; set; }
}