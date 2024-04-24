using Microsoft.EntityFrameworkCore;
using TasteRecipe.Models;

namespace TasteRecipe.Data.Context;

public partial class DataContext : DbContext
{
    public DataContext()
    { }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=localhost;port=6543;user id=postgres;password=toor;database=TasteRecipe;");

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Recipe> Recipes { get; set; }
    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Ingredient> Ingredients { get; set; }
    public virtual DbSet<Illustration> Illustrations { get; set; }
    public virtual DbSet<CategoryToRecipe> CategoryToRecipes { get; set; }
    public virtual DbSet<IngridientToRecipe> IngridientToRecipes { get; set; }
    public virtual DbSet<Favourite> Favourites { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_users");
            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Login).HasMaxLength(30).IsRequired();
            entity.Property(e => e.Password).HasMaxLength(30).IsRequired();
            entity.Property(e => e.Nickname).HasMaxLength(30).IsRequired();
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_recipes");
            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(30).IsRequired();
            
            entity.HasOne(e => e.Author)
                .WithMany(e => e.Recipes)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("recipes_author_fk");
        });
    }
}