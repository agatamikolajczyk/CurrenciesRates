using CurrenciesRates.Application.Models;
using Microsoft.EntityFrameworkCore;

namespace CurrenciesRates.Infrastructure.EF;

public class CurrenciesRatesContext(DbContextOptions<CurrenciesRatesContext> options) : DbContext(options)
{
    public DbSet<CurrencyRate> CurrenciesRates { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<CurrencyRate>(entity =>
        {
            entity.ToTable("CurrenciesRates");

            entity.HasKey(e => e.Id);

            entity.Property(p => p.Currency)
                .HasColumnType("VARCHAR(3)")
                .IsRequired();

            entity.Property(p => p.Date)
                .IsRequired();
            
            // entity.Property(p => p.Bid)
            //     .HasColumnType("decimal(10,4)")
            //     .IsRequired();
            //
            // entity.Property(p => p.Ask)
            //     .HasColumnType("decimal(10,4)")
            //     .IsRequired();
        });
        
        /*builder.Entity<CurrencyRate>()
            .Property(p => p.Currency)
            .HasColumnType("VARCHAR(3)")
            .IsRequired();

        builder.Entity<CurrencyRate>()
            .Property(p => p.Ask)
            .HasColumnType("decimal(10,4)")
            .IsRequired();

        builder.Entity<CurrencyRate>()
            .Property(p => p.Bid)
            .HasColumnType("decimal(10,4)")
            .IsRequired();
        builder.Entity<CurrencyRate>()
            .Property(p => p.Date)
            .IsRequired();*/

    }
}