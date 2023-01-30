using InvenLock.Models;
using InvenLock.Models.Enums.Conserto;
using InvenLock.Models.Enums.Equipamento;
using Microsoft.EntityFrameworkCore;

namespace InvenLock.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options){ }
    public DbSet<Equipamento> Equipamentos { get; set; }
    public DbSet<ConsertoEquip> ConsertoEquip { get; set; }
    public DbSet<Ocorrencia> Ocorrencias { get; set; }
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
        /*
         * Atributos com DATA
         */
        modelBuilder.Entity<Equipamento>()
            .Property(dt => dt.DataEntrega)
                .HasColumnType("smalldatetime");
        modelBuilder.Entity<Ocorrencia>()
            .Property(dt => dt.DataOcorrencia)
                .HasColumnType("smalldatetime");
        modelBuilder.Entity<Ocorrencia>()
            .Property(dt => dt.DataFimOcorrencia)
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
            .Property(de => de.DataOcorrencia)
                .HasDefaultValue(DateTime.Now);
        modelBuilder.Entity<Ocorrencia>()
            .Property(de => de.SituacaoConserto)
                .HasDefaultValue(SituacaoConserto.Pendente);
        modelBuilder.Entity<Equipamento>()
            .Property(dt => dt.DataEntrega)
                .HasDefaultValue(DateTime.Now);
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

    }
}
