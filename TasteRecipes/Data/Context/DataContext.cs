using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TasteRecipes.Models;

namespace TasteRecipes.Data.Context;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryToRecipe> CategoryToRecipes { get; set; }

    public virtual DbSet<Favourite> Favourites { get; set; }

    public virtual DbSet<Illustration> Illustrations { get; set; }

    public virtual DbSet<Ingredient> Ingredients { get; set; }

    public virtual DbSet<IngridientToRecipe> IngridientToRecipes { get; set; }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=localhost;port=6543;user id=postgres;password=toor;database=TasteRecipe");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_categories");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<CategoryToRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_category_to_recipe");

            entity.HasIndex(e => e.CategoryId, "IX_CategoryToRecipes_CategoryId");

            entity.HasIndex(e => e.RecipeId, "IX_CategoryToRecipes_RecipeId");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Category).WithMany(p => p.CategoryToRecipes)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("category_to_recipe_category_fk");

            entity.HasOne(d => d.Recipe).WithMany(p => p.CategoryToRecipes)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("category_to_recipe_recipe_fk");
        });

        modelBuilder.Entity<Favourite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_favourites");

            entity.HasIndex(e => e.RecipeId, "IX_Favourites_RecipeId");

            entity.HasIndex(e => e.UserId, "IX_Favourites_UserId");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.Recipe).WithMany(p => p.Favourites)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("favourites_recipe_fk");

            entity.HasOne(d => d.User).WithMany(p => p.Favourites)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("favourites_user_fk");
        });

        modelBuilder.Entity<Illustration>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_illustrations");

            entity.HasIndex(e => e.RecipeId, "IX_Illustrations_RecipeId");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Path).HasMaxLength(1000);

            entity.HasOne(d => d.Recipe).WithMany(p => p.Illustrations)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("illustrations_recipe_fk");
        });

        modelBuilder.Entity<Ingredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_ingredients");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<IngridientToRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_ingridient_to_recipe");

            entity.HasIndex(e => e.IngredientId, "IX_IngridientToRecipes_IngredientId");

            entity.HasIndex(e => e.RecipeId, "IX_IngridientToRecipes_RecipeId");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.AmountIngredients).HasMaxLength(30);

            entity.HasOne(d => d.Ingredient).WithMany(p => p.IngridientToRecipes)
                .HasForeignKey(d => d.IngredientId)
                .HasConstraintName("ingridient_to_recipe_ingredient_fk");

            entity.HasOne(d => d.Recipe).WithMany(p => p.IngridientToRecipes)
                .HasForeignKey(d => d.RecipeId)
                .HasConstraintName("ingridient_to_recipe_recipe_fk");
        });

        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_recipes");

            entity.HasIndex(e => e.AuthorId, "IX_Recipes_AuthorId");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(30);

            entity.HasOne(d => d.Author).WithMany(p => p.Recipes)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("recipes_author_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_users");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Login).HasMaxLength(30);
            entity.Property(e => e.Nickname).HasMaxLength(30);
            entity.Property(e => e.Password).HasMaxLength(30);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
