﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rental_Management.Business.DTOs.Rental
{
    public class RentalDTO
    {
        public int TenantId { get; set; }
       
        public bool IsActive { get; set; }
        public decimal RentValue { get; set; }


        public int RentPaymentFrequencyId { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }
    }
}
