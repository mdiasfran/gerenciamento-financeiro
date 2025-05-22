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
        ViewBag.DataOperacao = Filtros.ValoresDataOperacao;

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

    public IActionResult AdicionarTransacao()
    {
        ViewBag.Categorias = _context.Categorias.ToList();
        ViewBag.Transacoes = _context.Transacoes.ToList();

        return View();
    }

    public IActionResult RemoverTransacao(int id)
    {
        var financa = _context.Financas.Find(id);
        _context.Remove(financa);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult AdicionarCategoria()
    {
        var categoria = new Categoria { CategoriaId = "categoria" };

        return View(categoria);
    }

    [HttpPost]
    public IActionResult Filtrar(string[] filtro)
    {
        string id = string.Join("-", filtro);
        return RedirectToAction("Index", new { ID = id });
    }

    [HttpPost]
    public IActionResult AdicionarCategoria(Categoria categoria)
    {
        if (ModelState.IsValid)
        {
            var categoriaBanco = new Categoria
            {
                CategoriaId = categoria.Nome.ToLower(),
                Nome = categoria.Nome
            };

            _context.Categorias.Add(categoriaBanco);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        else
        {
            return View(categoria);
        }
    }

    [HttpPost]
    public IActionResult AdicionarTransacao(Financeiro financeiro)
    {
        if (ModelState.IsValid)
        {
            _context.Financas.Add(financeiro);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        else
        {
            ViewBag.Categorias = _context.Categorias.ToList();
            ViewBag.Transacoes = _context.Transacoes.ToList();

            return View(financeiro);
        }
    }
}