using CasaDoCodigo.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo
{   
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().HasKey(p => p.Id);

            modelBuilder.Entity<Pedido>().HasKey(p => p.Id);
            modelBuilder.Entity<Pedido>().HasMany(p => p.Itens).WithOne(p => p.Pedido);
            modelBuilder.Entity<Pedido>().HasOne(p => p.Cadastro).WithOne(c => c.Pedido)
                .HasForeignKey<Cadastro>(c => c.Id).IsRequired();

            modelBuilder.Entity<ItemPedido>().HasKey(i => i.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(i => i.Pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(i => i.Produto);

            modelBuilder.Entity<Cadastro>().HasKey(c => c.Id);
            modelBuilder.Entity<Cadastro>().HasOne(c => c.Pedido);
        }
    }
}
/*
 * Microsoft.AsNetCore.All-2.0.9
 * Microsoft.EntityFrameworkCore-2.2.6
 * Microsoft.EntityFrameworkCore.Tools-2.2.6
 * MySql.Data-8.0.18
 * Pomelo.EntityFrameworkCore.Mysql-2.2.6
 * 
 * Add-migration<nome>
 * Update Database
 */
