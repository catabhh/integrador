using System;
using System.Collections.Generic;

namespace webPersons;

public partial class Persona
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Rut { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; } = new List<Contract>();
}
