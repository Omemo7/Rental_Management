﻿using Rental_Management.Business.DTOs.ApartmentRental;
using Shared.DTOs.ApartmentRental;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.Interfaces
{
    public interface IApartmentRentalService:IService<ApartmentRentalDTO, AddApartmentRentalDTO, UpdateApartmentRentalDTO>
    {
        public Task<ICollection<ApartmentRentalDTOForUI>> GetAllApartmentRentalsForApartment(int apartmentId);
        public Task<ICollection<ApartmentRentalDTOForUI>> GetAllApartmentRentalsForLandlordForUI(int landlordId);

        public Task<ICollection<ApartmentRentalDTOForTenant>> GetAllApartmentRentalsForTenant(int tenantId);
    }
}
