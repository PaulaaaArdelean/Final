﻿// <auto-generated />
using System;
using Final.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Final.Migrations
{
    [DbContext(typeof(FinalContext))]
    [Migration("20230217134036_clientesiimprumuturi")]
    partial class clientesiimprumuturi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Final.Models.Accesoriu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Accesoriul")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Accesoriu");
                });

            modelBuilder.Entity("Final.Models.AccesoriuRochie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AccesoriuID")
                        .HasColumnType("int");

                    b.Property<int>("RochieID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccesoriuID");

                    b.HasIndex("RochieID");

                    b.ToTable("AccesoriuRochie");
                });

            modelBuilder.Entity("Final.Models.Categorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("Final.Models.Clienta", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adresa")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeClienta")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("PrenumeClienta")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Clienta");
                });

            modelBuilder.Entity("Final.Models.Designer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("NumeDesigner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Designer");
                });

            modelBuilder.Entity("Final.Models.Imprumut", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("ClientaID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataImpumutare")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataReturnare")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RochieID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientaID");

                    b.HasIndex("RochieID");

                    b.ToTable("Imprumut");
                });

            modelBuilder.Entity("Final.Models.Marime", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Marimea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Marime");
                });

            modelBuilder.Entity("Final.Models.Rochie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CategorieID")
                        .HasColumnType("int");

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DesignerID")
                        .HasColumnType("int");

                    b.Property<int?>("MarimeID")
                        .HasColumnType("int");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("DesignerID");

                    b.HasIndex("MarimeID");

                    b.ToTable("Rochie");
                });

            modelBuilder.Entity("Final.Models.AccesoriuRochie", b =>
                {
                    b.HasOne("Final.Models.Accesoriu", "Accesoriu")
                        .WithMany("AccesoriiRochii")
                        .HasForeignKey("AccesoriuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Final.Models.Rochie", "Rochie")
                        .WithMany("AccesoriiRochii")
                        .HasForeignKey("RochieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accesoriu");

                    b.Navigation("Rochie");
                });

            modelBuilder.Entity("Final.Models.Imprumut", b =>
                {
                    b.HasOne("Final.Models.Clienta", "Clienta")
                        .WithMany("Imprumuturi")
                        .HasForeignKey("ClientaID");

                    b.HasOne("Final.Models.Rochie", "Rochie")
                        .WithMany()
                        .HasForeignKey("RochieID");

                    b.Navigation("Clienta");

                    b.Navigation("Rochie");
                });

            modelBuilder.Entity("Final.Models.Rochie", b =>
                {
                    b.HasOne("Final.Models.Categorie", "Categorie")
                        .WithMany("Rochii")
                        .HasForeignKey("CategorieID");

                    b.HasOne("Final.Models.Designer", "Designer")
                        .WithMany("Rochii")
                        .HasForeignKey("DesignerID");

                    b.HasOne("Final.Models.Marime", "Marime")
                        .WithMany("Rochii")
                        .HasForeignKey("MarimeID");

                    b.Navigation("Categorie");

                    b.Navigation("Designer");

                    b.Navigation("Marime");
                });

            modelBuilder.Entity("Final.Models.Accesoriu", b =>
                {
                    b.Navigation("AccesoriiRochii");
                });

            modelBuilder.Entity("Final.Models.Categorie", b =>
                {
                    b.Navigation("Rochii");
                });

            modelBuilder.Entity("Final.Models.Clienta", b =>
                {
                    b.Navigation("Imprumuturi");
                });

            modelBuilder.Entity("Final.Models.Designer", b =>
                {
                    b.Navigation("Rochii");
                });

            modelBuilder.Entity("Final.Models.Marime", b =>
                {
                    b.Navigation("Rochii");
                });

            modelBuilder.Entity("Final.Models.Rochie", b =>
                {
                    b.Navigation("AccesoriiRochii");
                });
#pragma warning restore 612, 618
        }
    }
}
