using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TesteEngloba.Models;
using TesteEngloba.ViewModels;

namespace TesteEngloba.Data
{
    public class TesteEnglobaContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=VITOR\SQLEXPRESS;Initial Catalog=TesteEnglobaBD;User id=sa;Password=123");
        }


        public TesteEnglobaContext(DbContextOptions<TesteEnglobaContext> options) : base(options) { }

        public TesteEnglobaContext()
        {
        }

        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<FuncEnderecoViewModel> FuncEnderecoViewModel { get; set; }
    }

}



