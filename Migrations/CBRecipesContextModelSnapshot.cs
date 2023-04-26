﻿// <auto-generated />
using System;
using CBRecipes.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CBRecipes.API.Migrations
{
    [DbContext(typeof(CBRecipesContext))]
    partial class CBRecipesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("CBRecipes.API.Entities.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ingredients")
                        .HasColumnType("TEXT");

                    b.Property<string>("Instructions")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("CBRecipes.API.Entities.RecipeCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("RecipeCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Leves"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Főétel"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Köret, főzelék"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Desszert"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Torta"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Saláta"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Befőzés"
                        });
                });

            modelBuilder.Entity("CBRecipes.API.Entities.Recipe", b =>
                {
                    b.HasOne("CBRecipes.API.Entities.RecipeCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
