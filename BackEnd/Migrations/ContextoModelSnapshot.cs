﻿// <auto-generated />
using System;
using MeAluga.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeAluga.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846");

            modelBuilder.Entity("MeAluga.Models.Aluguel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContratoId");

                    b.Property<DateTime?>("DataDePagamento");

                    b.Property<string>("Observacao")
                        .HasMaxLength(500);

                    b.Property<decimal>("Valor");

                    b.Property<decimal?>("ValorPago");

                    b.Property<DateTime>("Vencimento");

                    b.HasKey("Id");

                    b.HasIndex("ContratoId");

                    b.ToTable("Aluguel");
                });

            modelBuilder.Entity("MeAluga.Models.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataDeInicio");

                    b.Property<DateTime>("DataDeRegistro");

                    b.Property<DateTime>("DataDeTermino");

                    b.Property<int>("ImovelId");

                    b.Property<int>("LocatarioId");

                    b.Property<string>("Observacao")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("ImovelId");

                    b.HasIndex("LocatarioId");

                    b.ToTable("Contratos");
                });

            modelBuilder.Entity("MeAluga.Models.Fiador", b =>
                {
                    b.Property<int>("GarantiaId");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<DateTime>("DataDeRegistro");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("RG")
                        .HasMaxLength(20);

                    b.HasKey("GarantiaId");

                    b.ToTable("Fiador");
                });

            modelBuilder.Entity("MeAluga.Models.Garantia", b =>
                {
                    b.Property<int>("ContratoId");

                    b.Property<DateTime>("DataDeRegistro");

                    b.Property<decimal?>("valorCaucao");

                    b.HasKey("ContratoId");

                    b.ToTable("Garantia");
                });

            modelBuilder.Entity("MeAluga.Models.Imovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataDeRegistro");

                    b.HasKey("Id");

                    b.ToTable("Imoveis");
                });

            modelBuilder.Entity("MeAluga.Models.Locatario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11);

                    b.Property<DateTime>("DataDeRegistro");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Locatarios");
                });

            modelBuilder.Entity("MeAluga.Models.Aluguel", b =>
                {
                    b.HasOne("MeAluga.Models.Contrato", "Contrato")
                        .WithMany("Alugueis")
                        .HasForeignKey("ContratoId");
                });

            modelBuilder.Entity("MeAluga.Models.Contrato", b =>
                {
                    b.HasOne("MeAluga.Models.Imovel", "Imovel")
                        .WithMany("Contratos")
                        .HasForeignKey("ImovelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MeAluga.Models.Locatario", "Locatario")
                        .WithMany("Contratos")
                        .HasForeignKey("LocatarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MeAluga.Models.Fiador", b =>
                {
                    b.HasOne("MeAluga.Models.Garantia", "Garantia")
                        .WithOne("Fiador")
                        .HasForeignKey("MeAluga.Models.Fiador", "GarantiaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("MeAluga.Models.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("FiadorGarantiaId");

                            b1.Property<string>("Bairro")
                                .HasMaxLength(50);

                            b1.Property<string>("CEP")
                                .HasMaxLength(10);

                            b1.Property<string>("Cidade")
                                .HasMaxLength(50);

                            b1.Property<string>("Complemento")
                                .HasMaxLength(100);

                            b1.Property<string>("Estado")
                                .HasMaxLength(50);

                            b1.Property<string>("Numero")
                                .HasMaxLength(10);

                            b1.Property<string>("Rua")
                                .HasMaxLength(50);

                            b1.ToTable("Fiador");

                            b1.HasOne("MeAluga.Models.Fiador")
                                .WithOne("Endereco")
                                .HasForeignKey("MeAluga.Models.Endereco", "FiadorGarantiaId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("MeAluga.Models.Garantia", b =>
                {
                    b.HasOne("MeAluga.Models.Contrato", "Contrato")
                        .WithOne("Garantia")
                        .HasForeignKey("MeAluga.Models.Garantia", "ContratoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MeAluga.Models.Imovel", b =>
                {
                    b.OwnsOne("MeAluga.Models.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("ImovelId");

                            b1.Property<string>("Bairro")
                                .HasMaxLength(50);

                            b1.Property<string>("CEP")
                                .HasMaxLength(10);

                            b1.Property<string>("Cidade")
                                .HasMaxLength(50);

                            b1.Property<string>("Complemento")
                                .HasMaxLength(100);

                            b1.Property<string>("Estado")
                                .HasMaxLength(50);

                            b1.Property<string>("Numero")
                                .HasMaxLength(10);

                            b1.Property<string>("Rua")
                                .HasMaxLength(50);

                            b1.ToTable("Imoveis");

                            b1.HasOne("MeAluga.Models.Imovel")
                                .WithOne("Endereco")
                                .HasForeignKey("MeAluga.Models.Endereco", "ImovelId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
