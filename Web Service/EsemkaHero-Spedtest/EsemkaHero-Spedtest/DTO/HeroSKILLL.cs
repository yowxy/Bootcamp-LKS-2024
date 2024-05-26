using EsemkaHero_Spedtest.Database;
using System.Text.Json.Serialization;

namespace EsemkaHero_Spedtest.DTO
{
    public class HeroSKILLL:HeroSkill
    {

        [JsonIgnore]
        public new int Id { get => base.Id; set => base.Id = value; }


        public string HeroName { get => base.Hero?.Name; }

        public new int HeroId { get => base.HeroId; set => base.HeroId = value; }

        public string SkillName { get => base.Skill?.Name; }



        public new int SkillId { get => base.SkillId; set => base.SkillId = value; }



        public new double Power { get => base.Power; set => base.Power = value; }

        [JsonIgnore]
        public override Hero Hero { get => base.Hero; set => base.Hero = value; }
        [JsonIgnore]
        public override Skill Skill { get => base.Skill; set => base.Skill = value; }




    }
}
