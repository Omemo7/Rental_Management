﻿using Rental_Management.Business.DTOs.Rental;

namespace Rental_Management.Business.DTOs.ApartmentRental
{
    public class UpdateApartmentRentalDTO
    {
        public int ApartmentId { get; set; }
        public RentalDTO Rental { get; set; }
    }
}