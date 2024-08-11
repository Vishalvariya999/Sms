﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using Domain.Extend;
using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Role : IAuditable
{
    public int RoleId { get; set; }

    public string? Name { get; set; }

    public DateTime Created { get; set; }

    public int CreatedBy { get; set; }

    public DateTime Updated { get; set; }

    public int UpdatedBy { get; set; }

    public bool Deleted { get; set; }

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}