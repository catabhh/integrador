using System;
using System.Collections.Generic;

namespace webPersons;

public partial class Job
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public float Progress { get; set; }

    public virtual ICollection<Building> Buildings { get; } = new List<Building>();
}
