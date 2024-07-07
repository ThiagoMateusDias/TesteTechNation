using Microsoft.EntityFrameworkCore;

namespace TesteTechNation.Web;

public partial class DashBoardFiscaisContext : DbContext
{
    public DashBoardFiscaisContext()
    {
    }

    public DashBoardFiscaisContext(DbContextOptions<DashBoardFiscaisContext> options) : base(options)
    {
    }

    public virtual DbSet<NotaFiscal> NotaFiscals { get; set; }

    public virtual DbSet<Pagador> Pagadors { get; set; }

    public virtual DbSet<StatusNotum> StatusNotas { get; set; }

    public virtual DbSet<TipoPagamento> TipoPagamentos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NotaFiscal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NotaFisc__3214EC075FAC3F2A");

            entity.ToTable("NotaFiscal");

            entity.Property(e => e.NumeroIdentificacao).HasMaxLength(50);
            entity.Property(e => e.Valor).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Pagador).WithMany(p => p.NotaFiscals)
                .HasForeignKey(d => d.PagadorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NotaFisca__Pagad__2A4B4B5E");

            entity.HasOne(d => d.StatusNota).WithMany(p => p.NotaFiscals)
                .HasForeignKey(d => d.StatusNotaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__NotaFisca__Statu__2B3F6F97");

            entity.HasOne(d => d.TipoPagamento).WithMany(p => p.NotaFiscals)
                .HasForeignKey(d => d.TipoPagamentoId)
                .HasConstraintName("FK__NotaFisca__TipoP__2C3393D0");
        });

        modelBuilder.Entity<Pagador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pagador__3214EC07133852E5");

            entity.ToTable("Pagador");

            entity.Property(e => e.Nome).HasMaxLength(100);
        });

        modelBuilder.Entity<StatusNotum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StatusNo__3214EC07AEBA75C3");

            entity.ToTable("StatusNota");

            entity.Property(e => e.Descricao).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoPagamento>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoPaga__3214EC07EEE24363");

            entity.ToTable("TipoPagamento");

            entity.Property(e => e.Descricao).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}