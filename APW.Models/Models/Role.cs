using APW.Models.Entities;
using System;
using System.Collections.Generic;

namespace APW.Models;

public partial class Role : IEntity
{
    public int RoleId { get; set; }

    public string? RoleName { get; set; }
}
