﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.DTOs.Apartment
{
    public class UpdateApartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FloorNumber { get; set; }
        public int NumberOfRooms { get; set; }
        public int NumberOfBathrooms { get; set; }
        public decimal SquaredMeters { get; set; }

    }
}
