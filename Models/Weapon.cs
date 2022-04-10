using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HeroAPI.Models
{
    public class Weapon
    {
        //[ForeignKey("Hero")]
        public int WeaponID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public ICollection<Hero> Heroes { get; set; }
        //public int WeaponOfHeroID { get; set; }
        //public virtual Hero Hero { get; set; }

    }
}
