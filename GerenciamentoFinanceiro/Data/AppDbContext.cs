﻿using GerenciamentoFinanceiro.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoFinanceiro.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Transacao> Transacoes { get; set; }
    public DbSet<Financeiro> Financas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { CategoriaId = "educacao", Nome = "Educação" },
            new Categoria { CategoriaId = "salario", Nome = "Salário" },
            new Categoria { CategoriaId = "alimentacao", Nome = "Alimentação" },
            new Categoria { CategoriaId = "comissao", Nome = "Comissão" }
        );

        modelBuilder.Entity<Transacao>().HasData(
            new Transacao { TransacaoId = "ganho", Nome = "Ganho" },
            new Transacao { TransacaoId = "despesa", Nome = "Despesa" }
        );

        base.OnModelCreating(modelBuilder);
    }
}