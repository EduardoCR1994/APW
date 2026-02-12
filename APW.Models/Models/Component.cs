using APW.Models.Entities;
using System;
using System.Collections.Generic;

namespace APW.Models;

public partial class Component : IEntity
{
    public decimal Id { get; set; }

    public string Name { get; set; } = null!;

    public string Content { get; set; } = null!;
}
