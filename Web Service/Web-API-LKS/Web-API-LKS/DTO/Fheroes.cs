using System.Text.Json.Serialization;
using Web_API_LKS.Database;

namespace Web_API_LKS.DTO
{
    public class Fheroes:FightHistory
    {

        [JsonIgnore]
        public new int Id { get => base.Id; set => base.Id = value; }
        





            





    }
}
