using EsemkaHero_Spedtest.Database;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EsemkaHero_Spedtest.DTO
{
    public class Elementtttt:Element
    {
        [JsonIgnore]

        public new int Id { get => base.Id; set => base.Id = value; }
        [Required]
        [MaxLength(250)]
        public new string Element1 { get => base.Element1; set => base.Element1 = value; }
        [JsonIgnore]
        public override ICollection<Skill> Skills { get => base.Skills; set => base.Skills = value; }
    }
}
