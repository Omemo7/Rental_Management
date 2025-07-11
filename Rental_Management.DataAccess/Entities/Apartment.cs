﻿using System;
using System.Collections.Generic;
using System.Data;

namespace Rental_Management.DataAccess.Entities;

public partial class Apartment
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public int FloorNumber { get; set; }


    public int NumberOfRooms { get; set; }
    public int NumberOfBathrooms { get; set; }

    public bool Occupied { get; set; }
    public decimal SquaredMeters { get; set; }

    public int ApartmentBuildingId { get; set; }


    public virtual ICollection<ApartmentsRental> ApartmentsRentals { get; set; } = new List<ApartmentsRental>();
    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();
    public virtual ApartmentBuilding ApartmentBuilding { get; set; } = null!;
   
}
