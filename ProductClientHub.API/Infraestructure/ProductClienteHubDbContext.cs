﻿using Microsoft.EntityFrameworkCore;
using ProductClientHub.API.Entities;

namespace ProductClientHub.API.Infraestructure;

public class ProductClienteHubDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; } = default!;
    public DbSet<Product> Products { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\gabriel.strapasson\\Documents\\Cursos\\C#\\ProductClientHubDB.db");
    }
}
