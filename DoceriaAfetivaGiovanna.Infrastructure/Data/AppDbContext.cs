using DoceriaAfetivaGiovanna.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoceriaAfetivaGiovanna.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<RecipeIngredient> RecipeIngredients => Set<RecipeIngredient>();
    public DbSet<AdditionalCost> AdditionalCosts => Set<AdditionalCost>();
    public DbSet<ProductPrice> ProductPrices => Set<ProductPrice>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>()
            .HasOne(r => r.ProductPrice)
            .WithOne(p => p.Recipe)
            .HasForeignKey<ProductPrice>(p => p.RecipeId);

        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Recipe)
            .WithMany(r => r.RecipeIngredients)
            .HasForeignKey(ri => ri.RecipeId);

        modelBuilder.Entity<RecipeIngredient>()
            .HasOne(ri => ri.Ingredient)
            .WithMany(i => i.RecipeIngredients)
            .HasForeignKey(ri => ri.IngredientId);

        modelBuilder.Entity<AdditionalCost>()
            .HasOne(c => c.Recipe)
            .WithMany(r => r.AdditionalCosts)
            .HasForeignKey(c => c.RecipeId);

        base.OnModelCreating(modelBuilder);
    }
}