using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationtest1.Models;

public partial class FundmanagementDbContext : DbContext
{
    public FundmanagementDbContext()
    {
    }

    public FundmanagementDbContext(DbContextOptions<FundmanagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fund> Funds { get; set; }

    public virtual DbSet<FundTrend> FundTrends { get; set; }

    public virtual DbSet<InvestmentPortfolio> InvestmentPortfolios { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<StockTrend> StockTrends { get; set; }

    public virtual DbSet<StockTrend> StockTrend0s { get; set; }

    public virtual DbSet<TranscationRecord> TranscationRecords { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Fund management;Persist Security Info=True;User ID=sa;Password=1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fund>(entity =>
        {
            entity.HasKey(e => e.FundId).HasName("PK_Fund_1");

            entity.ToTable("Fund");

            entity.Property(e => e.FundId).ValueGeneratedNever();
            entity.Property(e => e.FundEstablishDate).HasColumnType("date");
            entity.Property(e => e.FundRedemptionOpenDay).HasColumnType("date");
            entity.Property(e => e.FundInitialPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FundInitialassets).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FundType)
               .HasMaxLength(10)
               .IsUnicode(false);
            entity.Property(e => e.FundManager)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FundName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<FundTrend>(entity =>
        {
            entity.HasKey(e => e.FtrendId);

            entity.ToTable("FundTrend");

            entity.Property(e => e.FtrendDate).HasColumnType("datetime");
            entity.Property(e => e.FundLatestnetworth).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<InvestmentPortfolio>(entity =>
        {
            entity.HasKey(e => e.PortfolioId).HasName("PK_Investment");

            entity.ToTable("InvestmentPortfolio");

            entity.Property(e => e.HolidingDate).HasColumnType("datetime");
            entity.Property(e => e.PurchaseCoast).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK_Stock_1");

            entity.ToTable("Stock");

            entity.Property(e => e.StockId).ValueGeneratedNever();
            entity.Property(e => e.StockName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.StockType)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<StockTrend>(entity =>
        {
            entity.HasKey(e => e.StrendId);

            entity.ToTable("StockTrend");

            entity.Property(e => e.StockDailyCloseprice).HasColumnType("decimal(10, 0)");
            entity.Property(e => e.StrendDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TranscationRecord>(entity =>
        {
            entity.HasKey(e => e.TranscationId).HasName("PK_TranscationId");

            entity.Property(e => e.TransType)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.TransDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
