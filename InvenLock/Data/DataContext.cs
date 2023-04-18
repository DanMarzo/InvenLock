
using InvenLock.Models;
using InvenLock.Models.Enums.Conserto;
using InvenLock.Models.Enums.Equipamento;
using Microsoft.EntityFrameworkCore;
using InvenLock.Models.Enums.Funcionario;
using InvenLock.Utils;

namespace InvenLock.Data;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    public DbSet<ConsertoEquip> ConsertoEquips { get; set; }
    public DbSet<ContatoFuncionario> ContatoFuncionarios { get; set; }
    public DbSet<EnderecoFuncionario> EnderecoFuncionarios { get; set; }
    public DbSet<Equipamento> Equipamentos { get; set; }
    public DbSet<EquipamentoEmprestimo> EquipamentoEmprestimos { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Ocorrencia> Ocorrencias { get; set; }
    public DbSet<SucataEquip> SucataEquips { get; set; }

    protected override void OnModelCreating(ModelBuilder md)
    {

        /* ------ ENDERECOFUNCIONARIO ------ */

        md.Entity<EnderecoFuncionario>()
            .HasKey(key => key.FuncionarioId);
        md.Entity<EnderecoFuncionario>()
            .Property(p => p.Complemento)
            .HasColumnType("VARCHAR(250)");
        md.Entity<EnderecoFuncionario>()
            .Property(p => p.DataUltimaAtualizacao)
            .HasColumnType("datetime2(0)")
                .HasDefaultValueSql("GETDATE()");
        md.Entity<EnderecoFuncionario>()
            .Property(p => p.NomeRua)
            .HasColumnType("VARCHAR(30)");
        md.Entity<EnderecoFuncionario>()
            .Property(p => p.Numero)
            .HasColumnType("int");

        #region CONTATOFUNCIONARIO

        md.Entity<ContatoFuncionario>()
            .HasKey(key => key.FuncionarioId);
        md.Entity<ContatoFuncionario>()
            .HasOne(one => one.Funcionario)
            .WithOne(one => one.ContatoFuncionario)
                .HasForeignKey<ContatoFuncionario>(x => x.FuncionarioId)
                .HasConstraintName("PK_ContatoFuncionario_Funcionario");

        md.Entity<ContatoFuncionario>()
            .Property(p => p.Celular)
            .HasColumnType("VARCHAR(11)");
        md.Entity<ContatoFuncionario>()
            .Property(p => p.CelularCorp)
            .HasColumnType("VARCHAR(11)");
        md.Entity<ContatoFuncionario>()
            .Property(p => p.Email)
            .HasColumnType("VARCHAR(70)");

        md.Entity<ContatoFuncionario>()
            .HasIndex(em => em.Email)
            .IsUnique(true);
        md.Entity<ContatoFuncionario>()
            .Property(p => p.EmailCorp)
            .HasColumnType("VARCHAR(70)");
        md.Entity<ContatoFuncionario>()
            .Property(p => p.UltimaAtualizacao)
            .HasColumnType("datetime2(0)")
            .HasDefaultValueSql("GETDATE()");
        #region ContatoDefault

        md.Entity<ContatoFuncionario>()
            .HasData(
            new ContatoFuncionario 
            {
                FuncionarioId = 1,
                Email = "marzogildan@gmail.com",
                EmailCorp = "marzogildan@rrsoft.com.br",
                UltimaAtualizacao = DateTime.Now,
            }
            );
        #endregion

        #endregion

        #region EQUIPAMENTO

        md.Entity<Equipamento>()
            .HasKey(key => key.EquipamentoId);
        md.Entity<Equipamento>()
            .Property(dt => dt.DataEntrega)
            .HasColumnType("datetime2(0)")
            .HasDefaultValueSql("GETDATE()");
        md.Entity<Equipamento>()
            .Property(te => te.TipoEquip)
            .HasDefaultValue(TipoEquip.Desktop);
        md.Entity<Equipamento>()
            .Property(st => st.SituacaoEquip)
            .HasDefaultValue(SituacaoEquip.Disponível);
        md.Entity<Equipamento>()
            .Property(fu => fu.FuncionarioRecebedor)
            .HasColumnType("varchar(70)");
        md.Entity<Equipamento>()
            .Property(desc => desc.DescEquipamento)
            .HasColumnType("varchar(70)");
        md.Entity<Equipamento>()
            .Property(desc => desc.CodigoInterno)
            .ValueGeneratedOnAdd();
        #endregion


        #region FUNCIONARIO 

        md.Entity<Funcionario>()
            .HasKey(key => key.FuncionarioId)
            .HasName("PK_FuncionarioId");

        md.Entity<Funcionario>()
            .Property(dt => dt.Admissao)
            .HasColumnType("datetime2(0)")
            .HasDefaultValueSql("GETDATE()");

        md.Entity<Funcionario>()
            .Property(dt => dt.Demissao)
            .HasColumnType("datetime2(0)");

        md.Entity<Funcionario>()
            .Property(cpf => cpf.CPF)
            .HasColumnType("varchar(11)")
            .IsRequired();
        md.Entity<Funcionario>()
            .Property(nm => nm.Nome)
            .HasColumnType("varchar(40)")
            .IsRequired();
        md.Entity<Funcionario>()
            .Property(snm => snm.Sobrenome)
            .HasColumnType("varchar(50)")
            .IsRequired();
        md.Entity<Funcionario>()
            .Property(bl => bl.Status)
                .HasDefaultValue(true);

        md.Entity<Funcionario>()
            .Property(n => n.NumOcorrencias)
            .HasDefaultValue(0);

        #region FuncionarioDefault
        Criptografia.CriarPasswordHash("1q2w3e4r", out byte[] salt, out byte[] hash);

        md.Entity<Funcionario>()
            .HasData(
                new Funcionario
                {
                    FuncionarioId = 1,
                    Admissao = DateTime.Now,
                    CPF = "56053311839",
                    FuncionarioCargo = FuncionarioCargo.Diretor,
                    Nome = "Dan",
                    Sobrenome = "marzo",
                    Status = true,
                    NumOcorrencias = 0,
                    Pwdhash = hash,
                    Pwdsalt = salt,
                    
                }
            );
        #endregion

        #endregion
        /* ------ CONSERTOEQUIP ------ */

        md.Entity<ConsertoEquip>()
            .HasKey(key => key.ConsertoEquipId);
        md.Entity<ConsertoEquip>()
            .Property(st => st.SituacaoConserto)
            .HasDefaultValue(SituacaoConserto.Pendente);
        md.Entity<ConsertoEquip>()
            .Property(ds => ds.Procedimentos)
            .HasColumnType("varchar(500)");

        /* ------ OCORRENCIA ------ */

        md.Entity<Ocorrencia>()
            .HasKey(key => key.OcorrenciaId);

        md.Entity<Ocorrencia>()
            .Property(ds => ds.DescOcorrencia)
            .HasColumnType("varchar(300)");
        md.Entity<Ocorrencia>()
            .Property(cpf => cpf.FuncionarioCPF)
            .HasColumnType("varchar(11)");
        md.Entity<Ocorrencia>()
            .Property(dt => dt.DataOcorrencia)
            .HasColumnType("datetime2(0)")
            .HasDefaultValueSql("GETDATE()");
        md.Entity<Ocorrencia>()
            .Property(dt => dt.DataFimOcorrencia)
            .HasColumnType("datetime2(0)");
        md.Entity<Ocorrencia>()
            .Property(st => st.SituacaoConserto)
            .HasDefaultValue(SituacaoConserto.Pendente);
        md.Entity<Ocorrencia>()
            .Property(p => p.MotivoSucata)
            .HasColumnType("varchar(200)");


        /* ------ SUCATAEQUIP ------ */

        md.Entity<SucataEquip>()
            .HasKey(key => key.SucataEquipId);
        md.Entity<SucataEquip>()
            .Property(p => p.MotivoSucata)
            .HasColumnType("varchar(250)");
        md.Entity<SucataEquip>()
            .Property(p => p.DataDescarte)
            .HasColumnType("datetime2(0)")
            .HasDefaultValueSql("GETDATE()");

        /* ------ EQUIPAMENTOEMPRESTIMO ------ */

        md.Entity<EquipamentoEmprestimo>()
            .HasKey(key => key.FuncionarioId);
        md.Entity<EquipamentoEmprestimo>()
            .Property(p => p.DataDevolucao)
            .HasColumnType("datetime2(0)");
        md.Entity<EquipamentoEmprestimo>()
            .Property(p => p.DataEmprestimo)
            .HasColumnType("datetime2(0)");
        md.Entity<EquipamentoEmprestimo>()
            .Property(p => p.FuncionarioEntregadorCpf)
            .HasColumnType("VARCHAR(11)");

        /* ------ DEFININDO CHAVES ESTRANGEIRAS ------ */

        md.Entity<EquipamentoEmprestimo>()
            .HasOne<Equipamento>(one => one.Equipamento)
            .WithMany(many => many.EquipamentoEmprestimo)
                .HasForeignKey(fk => fk.EquipamentoId);

        md.Entity<EquipamentoEmprestimo>()
            .HasOne<Funcionario>(one => one.Funcionario)
            .WithMany(many => many.EquipamentoEmprestimos)
                .HasForeignKey(fk => fk.FuncionarioId);

        md.Entity<Ocorrencia>()
            .HasOne<Funcionario>(one => one.Funcionario)
            .WithMany(many => many.Ocorrencia)
                .HasForeignKey(fk => fk.FuncionarioId);

        md.Entity<Ocorrencia>()
            .HasOne<ConsertoEquip>(cse => cse.ConsertoEquip)
            .WithOne(c => c.Ocorrencia)
            .HasForeignKey<ConsertoEquip>(fk => fk.OcorrenciaId);

        md.Entity<Equipamento>()
            .HasMany(many => many.ConsertoEquips)
            .WithOne(one => one.Equipamento)
                .HasForeignKey(fk => fk.EquipamentoId);

        md.Entity<SucataEquip>()
            .HasOne<ConsertoEquip>(one => one.ConsertoEquip)
            .WithOne(one => one.SucataEquip)
                .HasForeignKey<SucataEquip>(fk => fk.ConsertoEquipId);

        md.Entity<ContatoFuncionario>()
            .HasOne<Funcionario>(one => one.Funcionario)
            .WithOne(one => one.ContatoFuncionario)
            .HasForeignKey<ContatoFuncionario>(fkey => fkey.FuncionarioId);

        md.Entity<EnderecoFuncionario>()
            .HasOne<Funcionario>(one => one.Funcionario)
            .WithOne(one => one.EnderecoFuncionario)
            .HasForeignKey<EnderecoFuncionario>(fkey => fkey.FuncionarioId);
    }
}
