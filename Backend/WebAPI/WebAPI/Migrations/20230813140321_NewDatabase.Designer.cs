﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Config;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20230813140321_NewDatabase")]
    partial class NewDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI.Entities.Departamento", b =>
                {
                    b.Property<int>("IdDepartamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdDepartamento");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDepartamento"));

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAtualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCriacao");

                    b.Property<int>("IdResponsavel")
                        .HasColumnType("int")
                        .HasColumnName("IdResponsavel");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("IdDepartamento");

                    b.HasIndex("IdResponsavel");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("WebAPI.Entities.Pessoa", b =>
                {
                    b.Property<int>("IdPessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdPessoa");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPessoa"));

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Apelido");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAtualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCriacao");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Documento");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Endereco");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Tipo");

                    b.HasKey("IdPessoa");

                    b.HasIndex("Documento")
                        .IsUnique();

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("WebAPI.Entities.Departamento", b =>
                {
                    b.HasOne("WebAPI.Entities.Pessoa", "Responsavel")
                        .WithMany()
                        .HasForeignKey("IdResponsavel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Responsavel");
                });
#pragma warning restore 612, 618
        }
    }
}