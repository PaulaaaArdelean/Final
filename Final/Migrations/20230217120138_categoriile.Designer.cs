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
    [Migration("20230217120138_categoriile")]
    partial class categoriile
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

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

            modelBuilder.Entity("Final.Models.Categorie", b =>
                {
                    b.Navigation("Rochii");
                });

            modelBuilder.Entity("Final.Models.Designer", b =>
                {
                    b.Navigation("Rochii");
                });

            modelBuilder.Entity("Final.Models.Marime", b =>
                {
                    b.Navigation("Rochii");
                });
#pragma warning restore 612, 618
        }
    }
}
