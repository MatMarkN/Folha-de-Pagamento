﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace FolhaPagamento.Migrations
{
    [DbContext(typeof(AppDataContext))]
    partial class AppDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.21");

            modelBuilder.Entity("api.Models.Folha", b =>
                {
                    b.Property<int>("folhaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ano")
                        .HasColumnType("INTEGER");

                    b.Property<int>("funcionarioId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("impostoInss")
                        .HasColumnType("REAL");

                    b.Property<float>("impostoIrrf")
                        .HasColumnType("REAL");

                    b.Property<int>("mes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("quantidade")
                        .HasColumnType("INTEGER");

                    b.Property<float>("salarioBruto")
                        .HasColumnType("REAL");

                    b.Property<float>("salarioFgts")
                        .HasColumnType("REAL");

                    b.Property<float>("salarioLiquido")
                        .HasColumnType("REAL");

                    b.Property<float>("valor")
                        .HasColumnType("REAL");

                    b.HasKey("folhaId");

                    b.HasIndex("funcionarioId");

                    b.ToTable("Folhas");
                });

            modelBuilder.Entity("api.Models.Funcionario", b =>
                {
                    b.Property<int>("funcionarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("funcionarioId");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("api.Models.Folha", b =>
                {
                    b.HasOne("api.Models.Funcionario", "funcionario")
                        .WithMany()
                        .HasForeignKey("funcionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("funcionario");
                });
#pragma warning restore 612, 618
        }
    }
}