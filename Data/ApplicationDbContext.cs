using System;
using System.Collections.Generic;
using System.Text;
using DubuisGelin.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DubuisGelin.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Utilisateur { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Champs> Champs { get; set; }
        public DbSet<Value> Values { get; set; }

        public DbSet<LiaisonValueChamps> LiaisonValueChamps { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Table>().ToTable(nameof(Table));
            modelBuilder.Entity<Table>().HasKey(b => b.Id);
            modelBuilder.Entity<Table>().Property(m => m.Nom).IsRequired();
            modelBuilder.Entity<Table>().HasOne(m => m.User).WithMany(m => m.TableEnfant);
            modelBuilder.Entity<Table>().HasMany(m => m.Champs).WithOne(w => w.Table).HasForeignKey(m => m.TableId);

            modelBuilder.Entity<User>().ToTable(nameof(User));
            modelBuilder.Entity<User>().HasKey(k => k.Id);
            modelBuilder.Entity<User>().HasMany(t => t.TableEnfant).WithOne(w => w.User).HasForeignKey(w => w.UserId);

            modelBuilder.Entity<Champs>().ToTable(nameof(Champs));
            modelBuilder.Entity<Champs>().HasKey(b => b.Id);
            modelBuilder.Entity<Champs>().HasOne(m => m.Table).WithMany(m => m.Champs);
            modelBuilder.Entity<Champs>().HasMany(m => m.Values).WithOne(m => m.Champs).HasForeignKey(w => w.ChampsId);
            modelBuilder.Entity<Champs>().Property(w => w.TypeEnum).IsRequired();

            modelBuilder.Entity<Value>().ToTable(nameof(Value));
            modelBuilder.Entity<Value>().HasKey(b => b.Id);
            modelBuilder.Entity<Value>().HasOne(w => w.Champs).WithMany(m => m.Values);
            modelBuilder.Entity<Value>().HasOne(w => w.LiaisonValueChamps).WithMany(m => m.Values);

            modelBuilder.Entity<LiaisonValueChamps>().ToTable(nameof(LiaisonValueChamps));
            modelBuilder.Entity<LiaisonValueChamps>().HasKey(w => w.Id);
            modelBuilder.Entity<LiaisonValueChamps>().HasMany(m => m.Values).WithOne(w => w.LiaisonValueChamps).HasForeignKey(p => p.IdLiaison);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "1", Name = "Utilisateur", NormalizedName = "UTILISATEUR", ConcurrencyStamp = "b1ad5b97-999b-48c1-bb2c-c971792aaa6b" }
                );
        }
    }
}
