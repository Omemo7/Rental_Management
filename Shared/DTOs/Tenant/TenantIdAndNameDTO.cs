﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs.Tenant
{
    public class TenantIdAndNameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        
    }
}
