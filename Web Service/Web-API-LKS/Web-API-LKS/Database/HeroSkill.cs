using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Web_API_LKS.Database;

public partial class HeroSkill
{
    public int Id { get; set; }
    [JsonIgnore]
    public int HeroId { get; set; }
    [JsonIgnore]
    public int SkillId { get; set; }

    public double Power { get; set; }

    public virtual Hero Hero { get; set; } = null!;

    public virtual Skill Skill { get; set; } = null!;
}
