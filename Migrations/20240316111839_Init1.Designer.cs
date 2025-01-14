﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderSystem.Models;

#nullable disable

namespace OrderSystem.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240316111839_Init1")]
    partial class Init1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OrderSystem.Models.Client", b =>
                {
                    b.Property<int>("id_Client")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_Client"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("card_number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_Client");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("OrderSystem.Models.Employees", b =>
                {
                    b.Property<int>("Id_employee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_employee"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_employee");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("OrderSystem.Models.Nakladnaya", b =>
                {
                    b.Property<int>("Id_nakladnaya")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_nakladnaya"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Order")
                        .HasColumnType("int");

                    b.Property<int>("Id_product")
                        .HasColumnType("int");

                    b.Property<decimal>("Summa")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id_nakladnaya");

                    b.HasIndex("Id_Order");

                    b.HasIndex("Id_product");

                    b.ToTable("Nakladnaya");
                });

            modelBuilder.Entity("OrderSystem.Models.Order", b =>
                {
                    b.Property<int>("Id_Order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Order"));

                    b.Property<DateTime>("Date_order")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id_Client")
                        .HasColumnType("int");

                    b.Property<int>("Id_employee")
                        .HasColumnType("int");

                    b.HasKey("Id_Order");

                    b.HasIndex("Id_Client");

                    b.HasIndex("Id_employee");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("OrderSystem.Models.Product", b =>
                {
                    b.Property<int>("Id_product")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_product"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id_PC")
                        .HasColumnType("int");

                    b.Property<string>("Nazvanie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id_product");

                    b.HasIndex("Id_PC");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("OrderSystem.Models.Product_category", b =>
                {
                    b.Property<int>("Id_PC")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_PC"));

                    b.Property<string>("Nazvanie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_PC");

                    b.ToTable("Product_category");
                });

            modelBuilder.Entity("OrderSystem.Models.Nakladnaya", b =>
                {
                    b.HasOne("OrderSystem.Models.Order", "order")
                        .WithMany("Nakladnayas")
                        .HasForeignKey("Id_Order")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderSystem.Models.Product", "product")
                        .WithMany("Nakladnayas")
                        .HasForeignKey("Id_product")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("OrderSystem.Models.Order", b =>
                {
                    b.HasOne("OrderSystem.Models.Client", "client")
                        .WithMany("Orders")
                        .HasForeignKey("Id_Client")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OrderSystem.Models.Employees", "employee")
                        .WithMany("Orders")
                        .HasForeignKey("Id_employee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");

                    b.Navigation("employee");
                });

            modelBuilder.Entity("OrderSystem.Models.Product", b =>
                {
                    b.HasOne("OrderSystem.Models.Product_category", "category")
                        .WithMany("Products")
                        .HasForeignKey("Id_PC")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("OrderSystem.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OrderSystem.Models.Employees", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("OrderSystem.Models.Order", b =>
                {
                    b.Navigation("Nakladnayas");
                });

            modelBuilder.Entity("OrderSystem.Models.Product", b =>
                {
                    b.Navigation("Nakladnayas");
                });

            modelBuilder.Entity("OrderSystem.Models.Product_category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
