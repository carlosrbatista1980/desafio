using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Data
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Patrimonio> Patrimonio { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
