using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Web_API_LKS.Database;

namespace Web_API_LKS.DTO
{
    public class SKILL : Skill
    {
        [JsonIgnore]
        public new int Id { get => base.Id; set => base.Id = value; }

        [Required]
        [MaxLength(250)]
        public new string Name { get => base.Name; set => base.Name = value; }

        public new string? Description { get => base.Description; set => base.Description = value; }

        public new int? ElementId { get => base.ElementId; set => base.ElementId = value; }
        public string? element { get => base.Element?.Element1; }
        [Required]
        public new string DifficultyLevel { get => base.DifficultyLevel; set => base.DifficultyLevel = value; }

        [JsonIgnore]
        public override Element? Element { get => base.Element; set => base.Element = value; }
        [JsonIgnore]
        public override ICollection<HeroSkill> HeroSkills { get => base.HeroSkills; set => base.HeroSkills = value; }
    }
}
