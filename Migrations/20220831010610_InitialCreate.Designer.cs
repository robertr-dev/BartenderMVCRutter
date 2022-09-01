﻿// <auto-generated />
using System;
using BartenderMVCRutter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BartenderMVCRutter.Migrations
{
    [DbContext(typeof(BartenderMVCRutterContext))]
    [Migration("20220831010610_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BartenderMVCRutter.Models.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"), 1L, 1);

                    b.Property<string>("CustomerName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("BartenderMVCRutter.Models.Drink", b =>
                {
                    b.Property<int>("DrinkID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DrinkID"), 1L, 1);

                    b.Property<string>("DrinkDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DrinkName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("DrinkPrice")
                        .HasColumnType("real");

                    b.HasKey("DrinkID");

                    b.ToTable("Drink");
                });

            modelBuilder.Entity("BartenderMVCRutter.Models.Order", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"), 1L, 1);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("DrinkID")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderItems")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("OrderID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("DrinkID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("BartenderMVCRutter.Models.Order", b =>
                {
                    b.HasOne("BartenderMVCRutter.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BartenderMVCRutter.Models.Drink", "Drink")
                        .WithMany()
                        .HasForeignKey("DrinkID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Drink");
                });
#pragma warning restore 612, 618
        }
    }
}
