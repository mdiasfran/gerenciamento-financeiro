using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoFinanceiro.Models;

namespace GerenciamentoFinanceiro.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}