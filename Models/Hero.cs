using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HeroAPI.Models
{
    public class Hero
    {
        [Key] public string? Name { get; set; }
        public string? Role { get; set; }
        public Weapon? PrimaryFire { get; set; }
        public Weapon? SecondaryFire { get; set; }
        public Standard? Ability1 { get; set; }
        public Standard? Ability2 { get; set; }
        public Ulimate? Ultimate { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Shield { get; set; }
    }

}
