namespace GerenciamentoFinanceiro.Models;

public class Filtros
{
    public Filtros(string filtroString)
    {
        FiltroString = filtroString ?? "todos-todos-todos";
        string[] filtros = FiltroString.Split('-');

        CategoriaId = filtros[0];
        DataOperacao = filtros[1];
        TransacaoId = filtros[2];
    }

    public string FiltroString { get; set; }
    public string CategoriaId { get; set; }
    public string TransacaoId { get; set; }
    public string DataOperacao { get; set; }

    public bool TemCategoria => CategoriaId != "todos";
    public bool TemTransacao => TransacaoId != "todos";
    public bool TemDataOperacao => DataOperacao != "todos";

    public static Dictionary<string, string> ValoresDataOperacao => new Dictionary<string, string>
    {
        { "passado", "Passado" },
        { "futuro", "Futuro" },
        { "hoje", "Hoje" }
    };
    
    
    public bool EPassado => DataOperacao.ToLower() == "passado";
    public bool EFuturo => DataOperacao.ToLower() == "futuro";
    public bool EHoje => DataOperacao.ToLower() == "hoje";
}