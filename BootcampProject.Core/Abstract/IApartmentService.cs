using BootcampProject.Core.DTOs;
using BootcampProject.Core.DTOs.ApartmentDtos;
using System.Collections.Generic;

namespace BootcampProject.Core.Abstract
{
    public interface IApartmentService
    {
        PaginatedApartmentsDto GetPagedApartments(int page);
        ResponseDto AddApartment(CreateApartmentDto entity);

        List<BlockDto> GetBlocks();
        List<FlatTypeDto> GetFlatTypes();
        List<ResidentsDto> GetResidents();

        //UpdateUserDto GetUserById(string id);

        //ResponseDto UpdateUser(UpdateUserDto entity);
        ResponseDto DeleteApartment(int entityId);
    }
}
