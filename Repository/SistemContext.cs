using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class SistemContext : DbContext
    {
        public SistemContext()
        {
        }

        public SistemContext(DbContextOptions<SistemContext> options) : base(options)
        {
            
        }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Contato> Contatos { get; set; }

        public DbSet<Computador> Computadores { get; set; }

        public DbSet<Peca> Pecas { get; set; }

        public DbSet<ComputadorPeca> ComputadoresPecas { get; set; }
    }
}
