
using InvenLock.Models;
using InvenLock.Models.Enums.Conserto;
using InvenLock.Models.Enums.Equipamento;
using Microsoft.EntityFrameworkCore;

namespace InvenLock.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options ) : base(options){}
    public DbSet<ConsertoEquip> ConsertoEquips { get; set; }
    public DbSet<ContatoFuncionario> ContatoFuncionarios { get; set; }
    public DbSet<EnderecoFuncionario> EnderecoFuncionarios { get; set; }
    public DbSet<Equipamento> Equipamentos { get; set; }
    public DbSet<EquipamentoEmprestimo> EquipamentoEmprestimos { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Ocorrencia> Ocorrencias { get; set; }
    public DbSet<SucataEquip> SucataEquips { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        /* ------ ENDERECOFUNCIONARIO ------ */

        modelBuilder.Entity<EnderecoFuncionario>()
            .HasKey(key => key.FuncionarioId);
        modelBuilder.Entity<EnderecoFuncionario>()
            .Property(p => p.Complemento)
            .HasColumnType("VARCHAR(250)");
        modelBuilder.Entity<EnderecoFuncionario>()
            .Property(p => p.DataUltimaAtualizacao)
            .HasColumnType("smalldatetime")
                .HasDefaultValueSql("GETDATE()");
        modelBuilder.Entity<EnderecoFuncionario>()
            .Property(p => p.NomeRua)
            .HasColumnType("VARCHAR(30)");
        modelBuilder.Entity<EnderecoFuncionario>()  
            .Property(p => p.Numero)
            .HasColumnType("int");

        /* ------ CONTATOFUNCIONARIO ------ */
    
        modelBuilder.Entity<ContatoFuncionario>()
            .HasKey(key => key.FuncionarioId);
        modelBuilder.Entity<ContatoFuncionario>()
            .Property(cp => cp.CPF)
            .HasColumnType("varchar(11)");
        modelBuilder.Entity<ContatoFuncionario>()
            .Property(p => p.Celular)
            .HasColumnType("VARCHAR(11)");
        modelBuilder.Entity<ContatoFuncionario>()
            .Property(p => p.CelularCorp)
            .HasColumnType("VARCHAR(11)");
        modelBuilder.Entity<ContatoFuncionario>()
            .Property(p => p.Email)
            .HasColumnType("VARCHAR(70)");
        modelBuilder.Entity<ContatoFuncionario>()
            .Property(p => p.EmailCorp)
            .HasColumnType("VARCHAR(70)");
        modelBuilder.Entity<ContatoFuncionario>()
            .Property(p => p.DataUltimaAtualizacao)
            .HasColumnType("smalldatetime")
            .HasDefaultValueSql("GETDATE()");
            
        /* ------ EQUIPAMENTO ------ */

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
            .Property(desc => desc.CodigoInterno)
            .ValueGeneratedOnAdd();

        /* ------ FUNCIONARIO ------ */

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
        modelBuilder.Entity<Funcionario>()
            .Property(n => n.NumOcorrencias)
            .HasDefaultValue(0);

        /* ------ CONSERTOEQUIP ------ */

        modelBuilder.Entity<ConsertoEquip>()
            .HasKey(key => key.ConsertoEquipId);
        modelBuilder.Entity<ConsertoEquip>()
            .Property(st => st.SituacaoConserto)
            .HasDefaultValue(SituacaoConserto.Pendente);
        modelBuilder.Entity<ConsertoEquip>()
            .Property(ds => ds.Procedimentos)
            .HasColumnType("varchar(500)");

        /* ------ OCORRENCIA ------ */

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
        modelBuilder.Entity<Ocorrencia>()
            .Property(p => p.MotivoSucata)
            .HasColumnType("varchar(200)");
        

        /* ------ SUCATAEQUIP ------ */

        modelBuilder.Entity<SucataEquip>()
            .HasKey(key => key.SucataEquipId);
        modelBuilder.Entity<SucataEquip>()
            .Property(p => p.MotivoSucata)
            .HasColumnType("varchar(250)");
        modelBuilder.Entity<SucataEquip>()
            .Property(p => p.DataDescarte)
            .HasColumnType("SMALLDATETIME")
            .HasDefaultValueSql("GETDATE()");

        /* ------ EQUIPAMENTOEMPRESTIMO ------ */

        modelBuilder.Entity<EquipamentoEmprestimo>()
            .HasKey(key => key.FuncionarioId);
        modelBuilder.Entity<EquipamentoEmprestimo>()
            .Property(p => p.DataDevolucao)
            .HasColumnType("smalldatetime");
        modelBuilder.Entity<EquipamentoEmprestimo>()
            .Property(p => p.DataEmprestimo)
            .HasColumnType("smalldatetime");
        modelBuilder.Entity<EquipamentoEmprestimo>()
            .Property(p => p.FuncionarioEntregadorCpf)
            .HasColumnType("VARCHAR(11)");
        

        /*DEFININDO CHAVES ESTRANGEIRAS
        */

        modelBuilder.Entity<EquipamentoEmprestimo>()
            .HasOne<Equipamento>(one => one.Equipamento)
            .WithMany(many => many.EquipamentoEmprestimo)
                .HasForeignKey(fk => fk.EquipamentoId);

        modelBuilder.Entity<EquipamentoEmprestimo>()
            .HasOne<Funcionario>(one => one.Funcionario)
            .WithMany(many => many.EquipamentoEmprestimos)
                .HasForeignKey(fk => fk.FuncionarioId);

        modelBuilder.Entity<Ocorrencia>()
            .HasOne<Funcionario>(one => one.Funcionario)
            .WithMany(many => many.Ocorrencia)
                .HasForeignKey(fk => fk.FuncionarioId);            
        
        modelBuilder.Entity<Equipamento>()
            .HasMany(many => many.ConsertoEquips)
            .WithOne(one => one.Equipamento)
                .HasForeignKey(fk => fk.EquipamentoId);

        modelBuilder.Entity<SucataEquip>()
            .HasOne<ConsertoEquip>(one => one.ConsertoEquip)
            .WithOne(one => one.SucataEquip)
                .HasForeignKey<SucataEquip>(fk => fk.ConsertoEquipId);

        modelBuilder.Entity<ContatoFuncionario>()
            .HasOne<Funcionario>(one => one.Funcionario)
            .WithOne(one => one.ContatoFuncionario)
            .HasForeignKey<ContatoFuncionario>( fkey => fkey.FuncionarioId);
        
        modelBuilder.Entity<EnderecoFuncionario>()
            .HasOne<Funcionario>(one => one.Funcionario)
            .WithOne(one => one.EnderecoFuncionario)
            .HasForeignKey<EnderecoFuncionario>(fkey => fkey.FuncionarioId);
    }
}
