using App.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; } = default!;


        //Her entity için ApplyConfiguration çağırmana gerek kalmaz
        //EF Core’da Fluent API konfigürasyonlarını otomatize etmek için kullanılır.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Aynı repository içerisindeki IEnttityConfiguration<T> implementasyonlarını otomatik olarak alır.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
