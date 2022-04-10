using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HeroAPI.Models
{
    public class Ability
    {
        //[ForeignKey("Hero")]
        public int AbilityID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        /*
        bool isUltimate { get; set; } = false;  
        public int? Cooldown { get; set; }
        public int? Cost { get; set; }
        */

    }
    
      public class Standard : Ability
      {
          public int? Cooldown { get; set; }
      }

      public class Ulimate : Ability
      {
          public int? Cost { get; set; }
      }
    


}
