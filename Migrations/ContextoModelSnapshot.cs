﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SegundoP_Ap2.DAL;

namespace SegundoP_Ap2.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("SegundoP_Ap2.Models.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");

                    b.HasData(
                        new
                        {
                            ClienteId = 1,
                            Nombres = "FERRETERIA GAMA"
                        },
                        new
                        {
                            ClienteId = 2,
                            Nombres = "AVALON DISCO"
                        },
                        new
                        {
                            ClienteId = 3,
                            Nombres = "PRESTAMOS CEFIPROD"
                        });
                });

            modelBuilder.Entity("SegundoP_Ap2.Models.Cobros", b =>
                {
                    b.Property<int>("CobroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<string>("Observaciones")
                        .HasColumnType("TEXT");

                    b.HasKey("CobroId");

                    b.ToTable("Cobros");
                });

            modelBuilder.Entity("SegundoP_Ap2.Models.CobrosDetalle", b =>
                {
                    b.Property<int>("CobroDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CobroId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<int>("VentaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CobroDetalleId");

                    b.HasIndex("CobroId");

                    b.ToTable("CobrosDetalle");
                });

            modelBuilder.Entity("SegundoP_Ap2.Models.Ventas", b =>
                {
                    b.Property<int>("VentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.HasKey("VentaId");

                    b.ToTable("Ventas");

                    b.HasData(
                        new
                        {
                            VentaId = 1,
                            Balance = 1000m,
                            ClienteId = 1,
                            Fecha = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 1000m
                        },
                        new
                        {
                            VentaId = 2,
                            Balance = 800m,
                            ClienteId = 1,
                            Fecha = new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 900m
                        },
                        new
                        {
                            VentaId = 3,
                            Balance = 2000m,
                            ClienteId = 2,
                            Fecha = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 2000m
                        },
                        new
                        {
                            VentaId = 4,
                            Balance = 1800m,
                            ClienteId = 2,
                            Fecha = new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 1900m
                        },
                        new
                        {
                            VentaId = 5,
                            Balance = 3000m,
                            ClienteId = 3,
                            Fecha = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 3000m
                        },
                        new
                        {
                            VentaId = 6,
                            Balance = 1900m,
                            ClienteId = 3,
                            Fecha = new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Monto = 2900m
                        });
                });

            modelBuilder.Entity("SegundoP_Ap2.Models.CobrosDetalle", b =>
                {
                    b.HasOne("SegundoP_Ap2.Models.Cobros", null)
                        .WithMany("Detalle")
                        .HasForeignKey("CobroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SegundoP_Ap2.Models.Cobros", b =>
                {
                    b.Navigation("Detalle");
                });
#pragma warning restore 612, 618
        }
    }
}
