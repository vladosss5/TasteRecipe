﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TasteRecipes.Data.Context;

#nullable disable

namespace TasteRecipes.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TasteRecipes.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id")
                        .HasName("pk_categories");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("TasteRecipes.Models.CategoryToRecipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("RecipeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("pk_category_to_recipe");

                    b.HasIndex(new[] { "CategoryId" }, "IX_CategoryToRecipes_CategoryId");

                    b.HasIndex(new[] { "RecipeId" }, "IX_CategoryToRecipes_RecipeId");

                    b.ToTable("CategoryToRecipes");
                });

            modelBuilder.Entity("TasteRecipes.Models.Favourite", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<long>("RecipeId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("pk_favourites");

                    b.HasIndex(new[] { "RecipeId" }, "IX_Favourites_RecipeId");

                    b.HasIndex(new[] { "UserId" }, "IX_Favourites_UserId");

                    b.ToTable("Favourites");
                });

            modelBuilder.Entity("TasteRecipes.Models.Illustration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<long>("RecipeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("pk_illustrations");

                    b.HasIndex(new[] { "RecipeId" }, "IX_Illustrations_RecipeId");

                    b.ToTable("Illustrations");
                });

            modelBuilder.Entity("TasteRecipes.Models.Ingredient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id")
                        .HasName("pk_ingredients");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("TasteRecipes.Models.IngridientToRecipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<string>("AmountIngredients")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<long>("IngredientId")
                        .HasColumnType("bigint");

                    b.Property<long>("RecipeId")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("pk_ingridient_to_recipe");

                    b.HasIndex(new[] { "IngredientId" }, "IX_IngridientToRecipes_IngredientId");

                    b.HasIndex(new[] { "RecipeId" }, "IX_IngridientToRecipes_RecipeId");

                    b.ToTable("IngridientToRecipes");
                });

            modelBuilder.Entity("TasteRecipes.Models.Recipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<long>("AuthorId")
                        .HasColumnType("bigint");

                    b.Property<string>("Instruction")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<int?>("Time")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("pk_recipes");

                    b.HasIndex(new[] { "AuthorId" }, "IX_Recipes_AuthorId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("TasteRecipes.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<long>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TasteRecipes.Models.CategoryToRecipe", b =>
                {
                    b.HasOne("TasteRecipes.Models.Category", "Category")
                        .WithMany("CategoryToRecipes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("category_to_recipe_category_fk");

                    b.HasOne("TasteRecipes.Models.Recipe", "Recipe")
                        .WithMany("CategoryToRecipes")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("category_to_recipe_recipe_fk");

                    b.Navigation("Category");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("TasteRecipes.Models.Favourite", b =>
                {
                    b.HasOne("TasteRecipes.Models.Recipe", "Recipe")
                        .WithMany("Favourites")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("favourites_recipe_fk");

                    b.HasOne("TasteRecipes.Models.User", "User")
                        .WithMany("Favourites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("favourites_user_fk");

                    b.Navigation("Recipe");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TasteRecipes.Models.Illustration", b =>
                {
                    b.HasOne("TasteRecipes.Models.Recipe", "Recipe")
                        .WithMany("Illustrations")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("illustrations_recipe_fk");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("TasteRecipes.Models.IngridientToRecipe", b =>
                {
                    b.HasOne("TasteRecipes.Models.Ingredient", "Ingredient")
                        .WithMany("IngridientToRecipes")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ingridient_to_recipe_ingredient_fk");

                    b.HasOne("TasteRecipes.Models.Recipe", "Recipe")
                        .WithMany("IngridientToRecipes")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("ingridient_to_recipe_recipe_fk");

                    b.Navigation("Ingredient");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("TasteRecipes.Models.Recipe", b =>
                {
                    b.HasOne("TasteRecipes.Models.User", "Author")
                        .WithMany("Recipes")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("recipes_author_fk");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("TasteRecipes.Models.Category", b =>
                {
                    b.Navigation("CategoryToRecipes");
                });

            modelBuilder.Entity("TasteRecipes.Models.Ingredient", b =>
                {
                    b.Navigation("IngridientToRecipes");
                });

            modelBuilder.Entity("TasteRecipes.Models.Recipe", b =>
                {
                    b.Navigation("CategoryToRecipes");

                    b.Navigation("Favourites");

                    b.Navigation("Illustrations");

                    b.Navigation("IngridientToRecipes");
                });

            modelBuilder.Entity("TasteRecipes.Models.User", b =>
                {
                    b.Navigation("Favourites");

                    b.Navigation("Recipes");
                });
#pragma warning restore 612, 618
        }
    }
}
