using System;
using System.Collections.Generic;

namespace fileGenerator;

public partial class Contract
{
    public int Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime FinishDate { get; set; }

    public byte[] Available { get; set; } = null!;

    public int Personaid { get; set; }

    public int Buildingid { get; set; }

    public virtual Building Building { get; set; } = null!;

    public virtual Persona Persona { get; set; } = null!;
}
