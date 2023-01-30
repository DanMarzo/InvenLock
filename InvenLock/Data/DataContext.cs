using InvenLock.Models;
using InvenLock.Models.Enums.Conserto;
using InvenLock.Models.Enums.Equipamento;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace InvenLock.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options){ }
    public DbSet<Equipamento> Equipamentos { get; set; }
    public DbSet<ConsertoEquip> ConsertoEquip { get; set; }
    public DbSet<Ocorrencia> Ocorrencias { get; set; }
    public DbSet<SucataEquip> SucataEquips { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<HistoricoEmpresEquip> HistoricoEmpresEquips { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
         * CHAVES PRIMARY KEY
         */
        modelBuilder.Entity<Equipamento>()
            .HasKey(key => key.EquipamentoId);

        modelBuilder.Entity<ConsertoEquip>()
            .HasKey(key => key.ConsertoEquipId);

        modelBuilder.Entity<Ocorrencia>()
            .HasKey(key => key.OcorrenciaId);

        modelBuilder.Entity<SucataEquip>()
            .HasKey(key => key.SucataEquipId);

        modelBuilder.Entity<Funcionario>()
            .HasKey(key => key.FuncionarioId);
        
        modelBuilder.Entity<HistoricoEmpresEquip>()
            .HasKey(key => key.HistoricoEmpresEquipId);

        /*
         * Chaves FOREIGN KEY
         */

        modelBuilder.Entity<ConsertoEquip>()
            .HasOne<Equipamento>(one => one.Equipamento)
                .WithMany(many => many.ConsertoEquips)
                    .HasForeignKey(fk => fk.EquipamentoId);
        modelBuilder.Entity<Ocorrencia>()
            .HasOne<ConsertoEquip>(one => one.ConsertoEquip)
                .WithOne(one => one.Ocorrencia)
                    .HasForeignKey<ConsertoEquip>(fk => fk.OcorrenciaId);
        modelBuilder.Entity<SucataEquip>()
            .HasOne<ConsertoEquip>(one => one.ConsertoEquip)
                .WithOne(wOne => wOne.SucataEquip)
                    .HasForeignKey<SucataEquip>(fk => fk.ConsertoEquipId);
        modelBuilder.Entity<Funcionario>()
            .HasMany<Equipamento>(eq => eq.Equipamentos)
                .WithOne(one => one.Funcionario)
                    .HasForeignKey(fk => fk.EquipamentoId);
        modelBuilder.Entity<HistoricoEmpresEquip>()
            .HasOne<Funcionario>(many => many.Funcionario)
                .WithMany(his => his.historicoEmpresEquips)
                    .HasForeignKey(fk => fk.FuncionarioId);
        /*
         * Atributos com DATA
         */
        modelBuilder.Entity<Equipamento>()
            .Property(dt => dt.DataEntrega)
                .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<Ocorrencia>()
            .Property(dt => dt.DataOcorrencia)
                .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<Ocorrencia>()
            .Property(dt => dt.DataFimOcorrencia)
                .HasColumnType("smalldatetime");
        modelBuilder.Entity<SucataEquip>()
            .Property(dt => dt.DataDescarte)
                .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<Funcionario>()
            .Property(dt => dt.DataAdmissao)
                .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("GETDATE()")
                        .IsRequired();
        modelBuilder.Entity<Funcionario>()
            .Property(dt => dt.DataDemissao)
                .HasColumnType("smalldatetime");
        modelBuilder.Entity<HistoricoEmpresEquip>()
            .Property(dt => dt.DataEmprestimo)
                .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<HistoricoEmpresEquip>()
            .Property(dt => dt.DateDevolucao)
                .HasColumnType("smalldatetime");
        /*
         * PRIMARY KEYs is required
         */

        modelBuilder.Entity<Ocorrencia>()
            .Property(key => key.OcorrenciaId)
                .IsRequired();
        modelBuilder.Entity<Equipamento>()
            .Property(key => key.EquipamentoId)
                .IsRequired(); 
        modelBuilder.Entity<ConsertoEquip>()
            .Property(key => key.ConsertoEquipId)
                .IsRequired();

        /*
         * Atributos com DEFAULT
         */
        modelBuilder.Entity<Ocorrencia>()
            .Property(de => de.SituacaoConserto)
                .HasDefaultValue(SituacaoConserto.Pendente);
        modelBuilder.Entity<ConsertoEquip>()
            .Property(cs => cs.SituacaoConserto)
                .HasDefaultValue(SituacaoConserto.Pendente);
        modelBuilder.Entity<Equipamento>()
            .Property(st => st.SituacaoEquip)
                .HasDefaultValue(SituacaoEquip.Disponível);
        /*
         * Atributos com REQUIRED
         */
        modelBuilder.Entity<Ocorrencia>()
            .Property(fu => fu.FuncionarioCPF)
                .IsRequired();
        modelBuilder.Entity<Ocorrencia>()
            .Property(ds => ds.DescOcorrencia)
                .IsRequired();
        modelBuilder.Entity<Equipamento>()
            .Property (tp => tp.TipoEquip)
                .IsRequired();
        /*
         * PARAMETROS ATRIBUTOS
         */

        modelBuilder.Entity<Ocorrencia>()
            .Property(ds => ds.DescOcorrencia)
                .HasMaxLength(250);
        modelBuilder.Entity<Equipamento>()
            .Property(ds => ds.DescEquipamento)
                .HasMaxLength(250);
        modelBuilder.Entity<ConsertoEquip>()
            .Property(ds => ds.Procedimentos)
                .HasMaxLength(250);
        modelBuilder.Entity<SucataEquip>()
            .Property(ds => ds.DescMotivo)
                .HasMaxLength(250)
                    .IsRequired();
        modelBuilder.Entity<Funcionario>()
            .Property(p => p.FuncionarioCPF)
                .HasColumnType("varchar(11)")
                    .IsRequired();
        modelBuilder.Entity<Funcionario>()
            .Property(p => p.NomeFuncionario)
                .HasColumnType("varchar(60)")
                    .IsRequired();
        modelBuilder.Entity<Funcionario>()
            .Property(p => p.SobreNomeFuncionario)
                .HasColumnType("varchar(60)")
                    .IsRequired();
    }
}
