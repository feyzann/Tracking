using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tracking.Models;

public partial class BonustrackingContext : DbContext
{
    public BonustrackingContext()
    {
    }

    public BonustrackingContext(DbContextOptions<BonustrackingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bonu> Bonus { get; set; }

    public virtual DbSet<EmailHistory> EmailHistories { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }

    public virtual DbSet<EmployeeTeam> EmployeeTeams { get; set; }

    public virtual DbSet<Objection> Objections { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Support> Supports { get; set; }

    public virtual DbSet<SupportDetail> SupportDetails { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public DbSet<SupportWithTimeDifference> SupportWithTimeDifferences { get; set; }

    public DbSet<GetObjectionsByEmployeeId> GetObjectionsByEmployeeId { get; set; }

    public DbSet<ObjectionsForTeamLead> ObjectionsForTeamLead { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=LAPTOP-M7RRRCVR;Initial Catalog=bonustracking;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ObjectionsForTeamLead>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("ObjectionsForTeamLead");
        });

        modelBuilder.Entity<GetObjectionsByEmployeeId>(entity =>
        {
            entity.HasNoKey();
        });


        modelBuilder.Entity<SupportWithTimeDifference>(entity =>
        {
            entity.HasNoKey(); // Views typically don't have a primary key
            entity.ToView("SupportWithTimeDifference"); // The name of the view in the database
        });


        modelBuilder.Entity<Bonu>(entity =>
        {
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Employee).WithMany(p => p.Bonus)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Bonus_Employee");
        });

        modelBuilder.Entity<EmailHistory>(entity =>
        {
            entity.ToTable("EmailHistory");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmailHistories)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmailHistory_Employee");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.HasOne(d => d.EmployeeDetail).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeDetailId)
                .HasConstraintName("FK_Employee_EmployeeDetail");

            entity.HasOne(d => d.Role).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Employee_Role");
        });

        modelBuilder.Entity<EmployeeDetail>(entity =>
        {
            entity.ToTable("EmployeeDetail");
        });

        modelBuilder.Entity<EmployeeTeam>(entity =>
        {
            entity.ToTable("EmployeeTeam");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeTeams)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeTeam_Employee");

            entity.HasOne(d => d.Team).WithMany(p => p.EmployeeTeams)
                .HasForeignKey(d => d.TeamId)
                .HasConstraintName("FK_EmployeeTeam_Team");
        });

        modelBuilder.Entity<Objection>(entity =>
        {
            entity.ToTable("Objection");

            entity.Property(e => e.Date).HasColumnType("datetime");

            entity.HasOne(d => d.Bonus).WithMany(p => p.Objections)
                .HasForeignKey(d => d.BonusId)
                .HasConstraintName("FK_Objection_Bonus");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");
        });

        modelBuilder.Entity<Support>(entity =>
        {
            entity.ToTable("Support");

            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");

            entity.HasOne(d => d.Employee).WithMany(p => p.Supports)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Support_Employee");
        });

        modelBuilder.Entity<SupportDetail>(entity =>
        {
            entity.ToTable("SupportDetail");

            entity.Property(e => e.Message)
                .HasMaxLength(10)
                .IsFixedLength();

            entity.HasOne(d => d.Support).WithMany(p => p.SupportDetails)
                .HasForeignKey(d => d.SupportId)
                .HasConstraintName("FK_SupportDetail_Support");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.ToTable("Team");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
