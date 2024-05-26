using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Web_API_LKS.Database;

namespace Web_API_LKS.DTO
{
    public class ELEMENEENTcs:Element
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
