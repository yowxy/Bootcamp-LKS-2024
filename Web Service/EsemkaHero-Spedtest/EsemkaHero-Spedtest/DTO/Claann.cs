using EsemkaHero_Spedtest.Database;
using System.Text.Json.Serialization;

namespace EsemkaHero_Spedtest.DTO
{
    public class Claann:Clan
    {

        [JsonIgnore]
        public new int Id { get => base.Id; set => base.Id = value; }

        [JsonIgnore]
        public override ICollection<Hero> Heroes { get => base.Heroes; set => base.Heroes = value; }
    }
}
