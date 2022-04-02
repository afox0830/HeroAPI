using System.ComponentModel.DataAnnotations;

namespace HeroAPI.Models
{
    public class Weapon
    {
        [Key] public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
