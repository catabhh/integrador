using System;
using System.Collections.Generic;

namespace webMaterials;

public partial class Material
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Cant { get; set; }

    public string Location { get; set; } = null!;
}
