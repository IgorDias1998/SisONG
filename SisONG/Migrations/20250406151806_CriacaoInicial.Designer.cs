﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SisONG.Context;

#nullable disable

namespace SisONG.Migrations
{
    [DbContext(typeof(SisONGContext))]
    [Migration("20250406151806_CriacaoInicial")]
    partial class CriacaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SisONG.Models.Doacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DoadorId")
                        .HasColumnType("int");

                    b.Property<string>("Item")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal?>("Valor")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.HasIndex("DoadorId");

                    b.ToTable("Doacoes");
                });

            modelBuilder.Entity("SisONG.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Local")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("SisONG.Models.HistoricoUso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataUso")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<int>("ProdutoInsumoId")
                        .HasColumnType("int");

                    b.Property<int>("QuantidadeUtilizada")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProdutoInsumoId");

                    b.ToTable("HistoricoUso");
                });

            modelBuilder.Entity("SisONG.Models.Notificacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataEnvio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Notificacoes");
                });

            modelBuilder.Entity("SisONG.Models.PontoColeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("NomeLocal")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("PontosDeColeta");
                });

            modelBuilder.Entity("SisONG.Models.ProdutoInsumo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("QuantidadeDisponivel")
                        .HasColumnType("int");

                    b.Property<string>("UnidadeMedida")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("ProdutosInsumos");
                });

            modelBuilder.Entity("SisONG.Models.Relatorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conteudo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataGeracao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Relatorios");
                });

            modelBuilder.Entity("SisONG.Models.TransacaoFinanceira", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Destino")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MetodoPagamento")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("TransacoesFinanceiras");
                });

            modelBuilder.Entity("SisONG.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("varchar(13)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SenhaHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("SisONG.Models.Administrador", b =>
                {
                    b.HasBaseType("SisONG.Models.Usuario");

                    b.Property<string>("AreaAtuacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Permissoes")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Administrador");
                });

            modelBuilder.Entity("SisONG.Models.Doador", b =>
                {
                    b.HasBaseType("SisONG.Models.Usuario");

                    b.Property<bool>("DoacaoAnonima")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TipoDoador")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasDiscriminator().HasValue("Doador");
                });

            modelBuilder.Entity("SisONG.Models.Voluntario", b =>
                {
                    b.HasBaseType("SisONG.Models.Usuario");

                    b.Property<string>("Disponibilidade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("EventoId")
                        .HasColumnType("int");

                    b.Property<string>("Habilidades")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasIndex("EventoId");

                    b.HasDiscriminator().HasValue("Voluntario");
                });

            modelBuilder.Entity("SisONG.Models.Doacao", b =>
                {
                    b.HasOne("SisONG.Models.Doador", "Doador")
                        .WithMany()
                        .HasForeignKey("DoadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doador");
                });

            modelBuilder.Entity("SisONG.Models.HistoricoUso", b =>
                {
                    b.HasOne("SisONG.Models.ProdutoInsumo", "ProdutoInsumo")
                        .WithMany("HistoricoDeUso")
                        .HasForeignKey("ProdutoInsumoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProdutoInsumo");
                });

            modelBuilder.Entity("SisONG.Models.Notificacao", b =>
                {
                    b.HasOne("SisONG.Models.Usuario", "UsuarioDestinatario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioDestinatario");
                });

            modelBuilder.Entity("SisONG.Models.Voluntario", b =>
                {
                    b.HasOne("SisONG.Models.Evento", null)
                        .WithMany("VoluntariosInscritos")
                        .HasForeignKey("EventoId");
                });

            modelBuilder.Entity("SisONG.Models.Evento", b =>
                {
                    b.Navigation("VoluntariosInscritos");
                });

            modelBuilder.Entity("SisONG.Models.ProdutoInsumo", b =>
                {
                    b.Navigation("HistoricoDeUso");
                });
#pragma warning restore 612, 618
        }
    }
}
