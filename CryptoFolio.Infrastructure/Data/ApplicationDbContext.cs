using CryptoFolio.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CryptoFolio.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
      

        public DbSet<Users> Users { get; set; }

        public DbSet<Wallet> Wallets { get; set; }

        public DbSet<CryptoCurrency> CryptoCurrencies { get; set; }

        public DbSet<UserAsset> UserAssets { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<WalletTransaction> WalletTransactions { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<UserSetting> UserSettings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // for Users
            modelBuilder.Entity<Users>(e =>
            {
                e.HasKey(u => u.UserId);

                e.HasIndex(u => u.Email)
                    .IsUnique();
            });

            // for Wallet
            modelBuilder.Entity<Wallet>(e =>
            {
                e.HasKey(w => w.WalletId);

                e.HasIndex(w => w.UserId)
                    .IsUnique();

                e.HasOne(w => w.User)
                    .WithOne(u => u.Wallet)
                    .HasForeignKey<Wallet>(w => w.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // for CryptoCurrency
            modelBuilder.Entity<CryptoCurrency>(e =>
            {
                e.HasKey(c => c.CryptoID);

                e.HasIndex(c => c.CoinGeckoID)
                    .IsUnique();

                e.HasIndex(c => c.Symbol);
            });

            // for UserAssets
            modelBuilder.Entity<UserAsset>(e =>
            {
                e.HasKey(a => a.AssetId);

                e.HasIndex(a => new { a.UserId, a.Symbol });

                e.HasOne(a => a.User)
                    .WithMany(u => u.UserAssets)
                    .HasForeignKey(a => a.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // for Transactions
            modelBuilder.Entity<Transaction>(e =>
            {
                e.HasKey(t => t.TransactionId);

                e.HasIndex(t => new { t.UserId, t.CryptoID });

                e.HasOne(t => t.User)
                    .WithMany(u => u.Transactions)
                    .HasForeignKey(t => t.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(t => t.CryptoCurrency)
                    .WithMany(c => c.Transactions)
                    .HasForeignKey(t => t.CryptoID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // for WalletTransactions
            modelBuilder.Entity<WalletTransaction>(e =>
            {
                e.HasKey(w => w.LogId);

                e.HasIndex(w => w.WalletId);

                e.HasOne(w => w.Wallet)
                    .WithMany(w => w.WalletTransactions)
                    .HasForeignKey(w => w.WalletId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // for Favorites
            modelBuilder.Entity<Favorite>(e =>
            {
                e.HasKey(f => f.FavoriteId);

                e.HasIndex(f => new { f.UserId, f.CryptoID })
                    .IsUnique();

                e.HasOne(f => f.User)
                    .WithMany(u => u.Favorites)
                    .HasForeignKey(f => f.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                e.HasOne(f => f.CryptoCurrency)
                    .WithMany(c => c.Favorites)
                    .HasForeignKey(f => f.CryptoID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // for UserSettings
            modelBuilder.Entity<UserSetting>(e =>
            {
                e.HasKey(s => s.SettingId);

                e.HasIndex(s => s.UserId)
                    .IsUnique();

                e.HasOne(s => s.User)
                    .WithOne(u => u.UserSetting)
                    .HasForeignKey<UserSetting>(s => s.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }


        // Automatically update audit timestamps 
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifiedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }
    }
}
