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

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_categories");
            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(30).IsRequired();
        });
        
        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_ingredients");
            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(30).IsRequired();
        });
    
        modelBuilder.Entity<Illustration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_illustrations");
            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Path).HasMaxLength(1000).IsRequired();
            entity.HasOne(e => e.Recipe)
                .WithMany(e => e.Illustrations)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("illustrations_recipe_fk");
        });
        
        modelBuilder.Entity<CategoryToRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_category_to_recipe");
            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.HasOne(e => e.Category)
                .WithMany(e => e.CategoriesToRecipes)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("category_to_recipe_category_fk");
            entity.HasOne(e => e.Recipe)
                .WithMany(e => e.CategoriesToRecipes)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("category_to_recipe_recipe_fk");
        });
        
        modelBuilder.Entity<IngridientToRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_ingridient_to_recipe");
            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.AmountIngredients).HasMaxLength(30).IsRequired();
            entity.HasOne(e => e.Ingredient)
                .WithMany(e => e.IngridientsToRecipes)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ingridient_to_recipe_ingredient_fk");
            entity.HasOne(e => e.Recipe).WithMany(e => e.IngridientsToRecipes)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ingridient_to_recipe_recipe_fk");
        });
        
        modelBuilder.Entity<Favourite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_favourites");
            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.HasOne(e => e.User)
                .WithMany(e => e.Favourites)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("favourites_user_fk");
            entity.HasOne(e => e.Recipe)
                .WithMany(e => e.Favourites)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("favourites_recipe_fk");
        });
    }
    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}