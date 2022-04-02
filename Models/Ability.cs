using System.ComponentModel.DataAnnotations;

namespace HeroAPI.Models
{
    public class Ability
    {
        [Key] public string? Name { get; set; }
        public string? Description { get; set; }

    }
    
    public class Standard : Ability
    {
        public int Cooldown { get; set; }
    }
    
    public class Ulimate : Ability
    {
        public int Cost { get; set; }
    }



}
