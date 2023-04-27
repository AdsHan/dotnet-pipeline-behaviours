using Microsoft.EntityFrameworkCore;
using PipelineBehaviours.API.Data.Entities;
using System.Reflection;

namespace PipelineBehaviours.API.Data;

public class CatalogDbContext : DbContext
{
    public CatalogDbContext()
    {

    }

    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {

    }

    public DbSet<ProductModel> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

}

