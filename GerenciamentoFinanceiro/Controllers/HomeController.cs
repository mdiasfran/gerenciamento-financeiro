using System.Diagnostics;
using GerenciamentoFinanceiro.Data;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoFinanceiro.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoFinanceiro.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(string id)
    {
        var filtros = new Filtros(id);

        ViewBag.Filtros = filtros;
        ViewBag.Categorias = _context.Categorias.ToList();
        ViewBag.Transacoes = _context.Transacoes.ToList();

        IQueryable<Financeiro> consulta = _context.Financas
            .Include(x => x.Transacao)
            .Include(x => x.Categoria);

        if (filtros.TemCategoria)
        {
            consulta = consulta.Where(c => c.CategoriaId == filtros.CategoriaId);
        }

        if (filtros.TemTransacao)
        {
            consulta = consulta.Where(c => c.TransacaoId == filtros.TransacaoId);
        }

        if (filtros.TemDataOperacao)
        {
            var hoje = DateTime.Today;

            if (filtros.EHoje)
            {
                consulta = consulta.Where(c => c.DataOperacao == hoje);
            }

            if (filtros.EFuturo)
            {
                consulta = consulta.Where(c => c.DataOperacao > hoje);
            }

            if (filtros.EPassado)
            {
                consulta = consulta.Where(c => c.DataOperacao < hoje);
            }
        }

        var financas = consulta.OrderBy(d => d.DataOperacao).ToList();


        return View(financas);
    }
}