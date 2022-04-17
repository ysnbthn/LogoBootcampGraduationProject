using BootcampProject.Core.DTOs;
using BootcampProject.Core.DTOs.ApartmentDtos;
using System.Collections.Generic;

namespace BootcampProject.Core.Abstract
{
    public interface IApartmentService
    {
        PaginatedApartmentsDto GetPagedApartments(int page);
        ResponseDto AddApartment(CreateApartmentDto entity);
        ResponseDto DeleteApartment(int entityId);
        ResponseDto UpdateApartment(UpdateApartmentDto entity);
        UpdateApartmentDto GetApartmentById(int id);

        List<BlockDto> GetBlocks();
        List<FlatTypeDto> GetFlatTypes();
        List<ResidentsDto> GetResidents();
    }
}
