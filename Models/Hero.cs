using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HeroAPI.Models
{
    public class Hero
    {
        [Key]
        public string Name { get; set; }
        public string Role { get; set; }
        public string Overview { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Shield { get; set; }

        public int? PrimaryFireID { get; set; }
        public int? SecondaryFireID { get; set; }
        public int? Ability1ID { get; set; }
        public int? Ability2ID { get; set; }
        public int? UltimateID { get; set; }

        
        public virtual Weapon? PrimaryFire { get; set; }
        public virtual Weapon? SecondaryFire { get; set; }
        [ForeignKey("Ability1ID")]
        public virtual Standard? Ability1 { get; set; }
        [ForeignKey("Ability2ID")]
        public virtual Standard? Ability2 { get; set; }
        [ForeignKey("UltimateID")]
        public virtual Ulimate? Ultimate { get; set; }
        

    }

}
