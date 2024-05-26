using System;
using System.Collections.Generic;

namespace EsemkaHero_Spedtest.Database;

public partial class Clan
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Hero> Heroes { get; set; } = new List<Hero>();
}
