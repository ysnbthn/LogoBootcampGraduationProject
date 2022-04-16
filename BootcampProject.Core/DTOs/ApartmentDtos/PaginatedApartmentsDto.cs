﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootcampProject.Core.DTOs.ApartmentDtos
{
    public class PaginatedApartmentsDto
    {
        public List<GetApartmentDto> Apartments { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
