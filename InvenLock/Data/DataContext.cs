
using InvenLock.Models;
using InvenLock.Models.Enums.Conserto;
using InvenLock.Models.Enums.Equipamento;
using Microsoft.EntityFrameworkCore;

namespace InvenLock.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options ) : base(options){}
    public DbSet<Equipamento> Equipamentos { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Ocorrencia> Ocorrencias { get; set; }
    public DbSet<ConsertoEquip> ConsertoEquips { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Equipamento>()
            .HasOne<Funcionario>(f => f.Funcionario)
                .WithMany(e => e.Equipamentos)
                    .HasForeignKey(fk => fk.FuncionarioId);

        modelBuilder.Entity<Equipamento>()
            .HasKey(key => key.EquipamentoId);
        modelBuilder.Entity<Equipamento>()
            .Property(dt => dt.DataEntrega)
            .HasColumnType("smalldatetime")
            .HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<Equipamento>()
            .Property(te => te.TipoEquip)
            .HasDefaultValue(TipoEquip.Desktop);
        modelBuilder.Entity<Equipamento>()
            .Property(st => st.SituacaoEquip)
            .HasDefaultValue(SituacaoEquip.Disponível);
        modelBuilder.Entity<Equipamento>()
            .Property(fu => fu.FuncionarioRecebedor)
            .HasColumnType("varchar(70)");
        modelBuilder.Entity<Equipamento>()
            .Property(desc => desc.DescEquipamento)
            .HasColumnType("varchar(70)");
        modelBuilder.Entity<Equipamento>()
            .Property(desc => desc.MarcaEquipamento)
            .HasColumnType("varchar(20)");

        modelBuilder.Entity<Funcionario>()
            .HasKey(key => key.FuncionarioId);
        modelBuilder.Entity<Funcionario>()
            .Property(dt => dt.DataAdmissao)
            .HasColumnType("smalldatetime") 
            .HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<Funcionario>()
            .Property(dt => dt.DataDemissao)
            .HasColumnType("smalldatetime");
        modelBuilder.Entity<Funcionario>()
            .Property(cpf => cpf.FuncionarioCPF)
            .HasColumnType("varchar(11)")
            .IsRequired();
        modelBuilder.Entity<Funcionario>()
            .Property(cpf => cpf.NomeFuncionario)
            .HasColumnType("varchar(40)")
            .IsRequired();
        modelBuilder.Entity<Funcionario>()
            .Property(cpf => cpf.SobreNomeFuncionario)
            .HasColumnType("varchar(50)")
            .IsRequired();
        modelBuilder.Entity<Funcionario>()
            .Property(bl => bl.Ativo)
                .HasDefaultValue(true);

        modelBuilder.Entity<ConsertoEquip>()
            .HasKey(key => key.ConsertoEquipId);
        modelBuilder.Entity<ConsertoEquip>()
            .Property(st => st.SituacaoConserto)
            .HasDefaultValue(SituacaoConserto.Pendente);
        modelBuilder.Entity<ConsertoEquip>()
            .Property(ds => ds.Procedimentos)
            .HasColumnType("varchar(500)");



        modelBuilder.Entity<Ocorrencia>()
            .HasKey(key => key.OcorrenciaId);
        modelBuilder.Entity<Ocorrencia>()
            .Property(ds => ds.DescOcorrencia)
            .HasColumnType("varchar(300)");
        modelBuilder.Entity<Ocorrencia>()
            .Property(fid => fid.FuncionarioId)
            .HasColumnType("varchar(70)");
        modelBuilder.Entity<Ocorrencia>()
            .Property(cpf => cpf.FuncionarioCPF)
            .HasColumnType("varchar(11)");
        modelBuilder.Entity<Ocorrencia>()
            .Property(dt => dt.DataOcorrencia)
            .HasColumnType("smalldatetime")
            .HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<Ocorrencia>()
            .Property(dt => dt.DataFimOcorrencia)
            .HasColumnType("smalldatetime");
        modelBuilder.Entity<Ocorrencia>()
            .Property(st => st.SituacaoConserto)
            .HasDefaultValue(SituacaoConserto.Pendente);
        
        /*DEFININDO CHAVES ESTRANGEIRAS
        */

        modelBuilder.Entity<ConsertoEquip>()
            .HasOne<Ocorrencia>(ce => ce.Ocorrencia)
            .WithOne(oc => oc.ConsertoEquip)
                .HasForeignKey<ConsertoEquip>(fk => fk.OcorrenciaId);
        
        modelBuilder.Entity<Equipamento>()
            .HasMany(many => many.ConsertoEquips)
            .WithOne(one => one.Equipamento)
                .HasForeignKey(fk => fk.EquipamentoId);

    }
}
