#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HeroAPI.Models;

namespace HeroAPI.Data
{
    public class HeroAPIContext : DbContext
    {
        public HeroAPIContext (DbContextOptions<HeroAPIContext> options)
            : base(options)
        {
        }

        public DbSet<HeroAPI.Models.Hero> Heroes { get; set; }
        public DbSet<HeroAPI.Models.Ability> Abilities { get; set; }
        public DbSet<HeroAPI.Models.Weapon> Weapons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
            modelBuilder.Entity<Hero>()
                .HasOne<Ability>(h => h.Ability1)
                .WithMany(a => a.Heroes)
                .HasForeignKey(h => h.Ability1ID);
            
            modelBuilder.Entity<Hero>()
                .HasOne<Ability>(h => h.Ability2)
                .WithMany(a => a.Heroes)
                .HasForeignKey(h => h.Ability2ID);
            
            modelBuilder.Entity<Hero>()
                .HasOne<Weapon>(h => h.PrimaryFire)
                .WithMany(a => a.Heroes)
                .HasForeignKey(h => h.PrimaryFireID);
            
            modelBuilder.Entity<Hero>()
                .HasOne<Weapon>(h => h.SecondaryFire)
                .WithMany(a => a.Heroes)
                .HasForeignKey(h => h.SecondaryFireID);

            
            modelBuilder.Entity<Hero>()
            .HasOne<Ability>(h => h.Ability2)
            .WithOne(a => a.Hero)
            .HasForeignKey<Ability>(a => a.AbilityOfHeroID);
            
            modelBuilder.Entity<Hero>()
            .HasOne<Weapon>(h => h.PrimaryFire)
            .WithOne(w => w.Hero)
            .HasForeignKey<Weapon>(w => w.WeaponOfHeroID);
            */

        }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Hero>()
                .HasOne(h => h.Ability1)
                .WithOne(a => a.Hero)
                .HasForeignKey<Hero>(h => h.HeroId);

            
            modelBuilder.Entity<Hero>()
                .HasOne(x => x.Ability1).WithOne().HasForeignKey(x => x.Ability1ID);
            
            modelBuilder.Entity<Hero>()
                .HasOne(x => x.Ability2).WithOne().OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Hero>()
                .HasOne(x => x.Ultimate).WithOne().OnDelete(DeleteBehavior.Cascade);
            

        }
        */

    }
}
