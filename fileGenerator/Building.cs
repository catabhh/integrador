using System;
using System.Collections.Generic;

namespace fileGenerator;

public partial class Building
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public float Progress { get; set; }

    public int Jobid { get; set; }

    public virtual ICollection<Contract> Contracts { get; } = new List<Contract>();

    public virtual Job Job { get; set; } = null!;
}
