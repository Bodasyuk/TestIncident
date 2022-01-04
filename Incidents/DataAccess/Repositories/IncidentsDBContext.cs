using System.ComponentModel.DataAnnotations.Schema;
using Incidents.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Incidents.DataAccess.Repositories;

public class IncidentsDBContext : DbContext
{
    public IncidentsDBContext(DbContextOptions<IncidentsDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Entities.Incidents>().Property(e => e.IncidentName)
            .HasColumnName("Name")
            .HasColumnType("uuid")
            .HasDefaultValueSql("uuid_generate_v4()")
            .IsRequired();
        builder.Entity<Contacts>()
            .HasOne<Accounts>()
            .WithMany()
            .IsRequired(false);
        builder.Entity<Accounts>()
            .HasOne<Entities.Incidents>()
            .WithMany()
            .IsRequired(false);
        builder.Entity<Accounts>()
            .HasIndex(i => i.Name).IsUnique();
        builder.Entity<Contacts>()
            .HasIndex(i => i.Email).IsUnique();
        
    }
    public DbSet<Accounts> Accounts { get; set; }
    public DbSet<Entities.Incidents> Incidents { get; set; }
    public DbSet<Contacts> Contacts { get; set; }
}