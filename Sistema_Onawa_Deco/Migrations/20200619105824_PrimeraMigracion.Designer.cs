﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema_Onawa_Deco.Models;

namespace Sistema_Onawa_Deco.Migrations
{
    [DbContext(typeof(OnawaDecoDbContext))]
    [Migration("20200619105824_PrimeraMigracion")]
    partial class PrimeraMigracion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sistema_Onawa_Deco.Models.Profesor", b =>
                {
                    b.Property<int>("Dni")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("Dni");

                    b.ToTable("Profesores");
                });

            modelBuilder.Entity("Sistema_Onawa_Deco.Models.ProfesorSeminario", b =>
                {
                    b.Property<int>("ProfesorDni")
                        .HasColumnType("int");

                    b.Property<int>("SeminarioId")
                        .HasColumnType("int");

                    b.HasKey("ProfesorDni", "SeminarioId");

                    b.HasIndex("SeminarioId");

                    b.ToTable("ProfesorSeminarios");
                });

            modelBuilder.Entity("Sistema_Onawa_Deco.Models.Seminario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Seminarios");
                });

            modelBuilder.Entity("Sistema_Onawa_Deco.Models.SeminarioSocio", b =>
                {
                    b.Property<int>("SocioId")
                        .HasColumnType("int");

                    b.Property<int>("SeminarioId")
                        .HasColumnType("int");

                    b.HasKey("SocioId", "SeminarioId");

                    b.HasIndex("SeminarioId");

                    b.ToTable("SocioSeminario");
                });

            modelBuilder.Entity("Sistema_Onawa_Deco.Models.Socio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TelefonoContacto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Socios");
                });

            modelBuilder.Entity("Sistema_Onawa_Deco.Models.ProfesorSeminario", b =>
                {
                    b.HasOne("Sistema_Onawa_Deco.Models.Profesor", "Profesor")
                        .WithMany("ProfesorSeminarios")
                        .HasForeignKey("ProfesorDni")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_Onawa_Deco.Models.Seminario", "Seminario")
                        .WithMany("ProfesorSeminarios")
                        .HasForeignKey("SeminarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sistema_Onawa_Deco.Models.SeminarioSocio", b =>
                {
                    b.HasOne("Sistema_Onawa_Deco.Models.Seminario", "Seminario")
                        .WithMany("SocioSeminarios")
                        .HasForeignKey("SeminarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema_Onawa_Deco.Models.Socio", "Socio")
                        .WithMany("SocioSeminarios")
                        .HasForeignKey("SocioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
