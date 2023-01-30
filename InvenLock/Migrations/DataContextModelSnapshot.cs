﻿// <auto-generated />
using System;
using InvenLock.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InvenLock.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InvenLock.Models.ConsertoEquip", b =>
                {
                    b.Property<int>("ConsertoEquipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConsertoEquipId"));

                    b.Property<string>("EquipamentoId")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("OcorrenciaId")
                        .HasColumnType("varchar(40)");

                    b.Property<string>("Procedimentos")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("SituacaoConserto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("ConsertoEquipId");

                    b.HasIndex("EquipamentoId");

                    b.HasIndex("OcorrenciaId")
                        .IsUnique()
                        .HasFilter("[OcorrenciaId] IS NOT NULL");

                    b.ToTable("ConsertoEquip");
                });

            modelBuilder.Entity("InvenLock.Models.Equipamento", b =>
                {
                    b.Property<string>("EquipamentoId")
                        .HasColumnType("varchar(40)");

                    b.Property<DateTime>("DataEntrega")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smalldatetime")
                        .HasDefaultValue(new DateTime(2023, 1, 29, 23, 35, 4, 364, DateTimeKind.Local).AddTicks(7513));

                    b.Property<string>("DescEquipamento")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("SituacaoEquip")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("TipoEquip")
                        .HasColumnType("int");

                    b.HasKey("EquipamentoId");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("InvenLock.Models.Ocorrencia", b =>
                {
                    b.Property<string>("OcorrenciaId")
                        .HasColumnType("varchar(40)");

                    b.Property<DateTime>("DataFimOcorrencia")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime>("DataOcorrencia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smalldatetime")
                        .HasDefaultValue(new DateTime(2023, 1, 29, 23, 35, 4, 364, DateTimeKind.Local).AddTicks(7898));

                    b.Property<string>("DescOcorrencia")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("FuncionarioCPF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuncionarioId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SituacaoConserto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("OcorrenciaId");

                    b.ToTable("Ocorrencias");
                });

            modelBuilder.Entity("InvenLock.Models.SucataEquip", b =>
                {
                    b.Property<int>("SucataEquipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SucataEquipId"));

                    b.Property<int>("ConsertoEquipId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataDescarte")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smalldatetime")
                        .HasDefaultValue(new DateTime(2023, 1, 29, 23, 35, 4, 364, DateTimeKind.Local).AddTicks(8131));

                    b.Property<string>("DescMotivo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("SucataEquipId");

                    b.HasIndex("ConsertoEquipId")
                        .IsUnique();

                    b.ToTable("SucataEquips");
                });

            modelBuilder.Entity("InvenLock.Models.ConsertoEquip", b =>
                {
                    b.HasOne("InvenLock.Models.Equipamento", "Equipamento")
                        .WithMany("ConsertoEquips")
                        .HasForeignKey("EquipamentoId");

                    b.HasOne("InvenLock.Models.Ocorrencia", "Ocorrencia")
                        .WithOne("ConsertoEquip")
                        .HasForeignKey("InvenLock.Models.ConsertoEquip", "OcorrenciaId");

                    b.Navigation("Equipamento");

                    b.Navigation("Ocorrencia");
                });

            modelBuilder.Entity("InvenLock.Models.SucataEquip", b =>
                {
                    b.HasOne("InvenLock.Models.ConsertoEquip", "ConsertoEquip")
                        .WithOne("SucataEquip")
                        .HasForeignKey("InvenLock.Models.SucataEquip", "ConsertoEquipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ConsertoEquip");
                });

            modelBuilder.Entity("InvenLock.Models.ConsertoEquip", b =>
                {
                    b.Navigation("SucataEquip");
                });

            modelBuilder.Entity("InvenLock.Models.Equipamento", b =>
                {
                    b.Navigation("ConsertoEquips");
                });

            modelBuilder.Entity("InvenLock.Models.Ocorrencia", b =>
                {
                    b.Navigation("ConsertoEquip");
                });
#pragma warning restore 612, 618
        }
    }
}
