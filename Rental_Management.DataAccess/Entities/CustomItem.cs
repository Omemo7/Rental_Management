﻿using System;
using System.Collections.Generic;

namespace Rental_Management.DataAccess.Entities;

public partial class CustomItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;
    public bool Vacant { get; set; }
    public int LandLordId { get; set; }

    public int CustomItemTypeId { get; set; }

    public virtual CustomItemType CustomItemType { get; set; } = null!;

    public virtual ICollection<CustomRental> CustomRentals { get; set; } = new List<CustomRental>();
    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual Landlord LandLord { get; set; } = null!;
}
