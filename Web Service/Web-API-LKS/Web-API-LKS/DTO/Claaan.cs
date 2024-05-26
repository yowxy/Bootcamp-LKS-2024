using System.Text.Json.Serialization;
using Web_API_LKS.Database;

namespace Web_API_LKS.DTO
{
    public class Claaan : Clan
    {


        [JsonIgnore]
        public new int Id { get => base.Id; set => base.Id = value; }
        [JsonIgnore]
        public override ICollection<Hero> Heroes { get => base.Heroes; set => base.Heroes = value; }
    }
}
