﻿// <auto-generated />
using System;
using DataDataContext.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Joint_Residential_Management.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240325191544_FirstM")]
    partial class FirstM
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ModelResidente.Residente.Residente", b =>
                {
                    b.Property<int>("Id_residente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Id_User")
                        .HasColumnType("int");

                    b.Property<string>("Nombre_residente")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Num_apartamento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Num_telefono")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id_residente");

                    b.HasIndex("Id_User");

                    b.ToTable("Residentes");
                });

            modelBuilder.Entity("ModelsEstadoAnomalia.EstadoAnomalia.EstadoAnomalia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre_Estado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("fechaEstado")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("EstadoAnomalia");
                });

            modelBuilder.Entity("ModelsReporteAnomalias.ReporteAnomalia.ReporteAnomalia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AsuntoAnomalia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DescripcionAnomalia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("FechaReporteAnomalia")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FotoAnomalia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TipoAnomalia")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("ReporteAnomalias");
                });

            modelBuilder.Entity("ModelsUser.User.User", b =>
                {
                    b.Property<int>("Id_User")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id_User");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ModelResidente.Residente.Residente", b =>
                {
                    b.HasOne("ModelsUser.User.User", "Usuario")
                        .WithMany()
                        .HasForeignKey("Id_User")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ModelsEstadoAnomalia.EstadoAnomalia.EstadoAnomalia", b =>
                {
                    b.HasOne("ModelsReporteAnomalias.ReporteAnomalia.ReporteAnomalia", null)
                        .WithMany("Estados")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ModelsReporteAnomalias.ReporteAnomalia.ReporteAnomalia", b =>
                {
                    b.Navigation("Estados");
                });
#pragma warning restore 612, 618
        }
    }
}
