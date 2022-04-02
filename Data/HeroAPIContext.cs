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
    }
}
