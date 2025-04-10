﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaSetorTecnico.Data;

#nullable disable

namespace SistemaSetorTecnico.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaSetorTecnico.Models.Localidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Localidades");
                });

            modelBuilder.Entity("SistemaSetorTecnico.Models.Motivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Motivos");
                });

            modelBuilder.Entity("SistemaSetorTecnico.Models.Recoleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BioquimicoResponsavel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ColetaConcluida")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DataContato")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataRecoleta")
                        .HasColumnType("datetime2");

                    b.Property<string>("Empresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Exame")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LaboratorioApoio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocalidadesId")
                        .HasColumnType("int");

                    b.Property<int?>("MotivosId")
                        .HasColumnType("int");

                    b.Property<string>("NomePaciente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroOS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Serie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("TecnicoResponsavel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocalidadesId");

                    b.HasIndex("MotivosId");

                    b.HasIndex("StatusId");

                    b.ToTable("Recoletas");
                });

            modelBuilder.Entity("SistemaSetorTecnico.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("SistemaSetorTecnico.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsBioquimico")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SistemaSetorTecnico.Models.Recoleta", b =>
                {
                    b.HasOne("SistemaSetorTecnico.Models.Localidade", "Localidades")
                        .WithMany("Recoleta")
                        .HasForeignKey("LocalidadesId");

                    b.HasOne("SistemaSetorTecnico.Models.Motivo", "Motivos")
                        .WithMany("Recoleta")
                        .HasForeignKey("MotivosId");

                    b.HasOne("SistemaSetorTecnico.Models.Status", "Status")
                        .WithMany("Recoleta")
                        .HasForeignKey("StatusId");

                    b.Navigation("Localidades");

                    b.Navigation("Motivos");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("SistemaSetorTecnico.Models.Localidade", b =>
                {
                    b.Navigation("Recoleta");
                });

            modelBuilder.Entity("SistemaSetorTecnico.Models.Motivo", b =>
                {
                    b.Navigation("Recoleta");
                });

            modelBuilder.Entity("SistemaSetorTecnico.Models.Status", b =>
                {
                    b.Navigation("Recoleta");
                });
#pragma warning restore 612, 618
        }
    }
}
