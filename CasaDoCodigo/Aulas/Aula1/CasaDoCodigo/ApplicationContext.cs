using CasaDoCodigo.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
   // [DbConfigurationType(typeof(MySqlConfiguration))]
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().HasKey(p => p.Id);
        }
    }
}
/*
 *implementacao do entity com mysql
 *https://www.c-sharpcorner.com/article/code-first-migration-asp-net-mvc-5-with-entityframework-mysql/
 * Enable-Migration
 * Add-migration<nome>
 * Update Database
 */
