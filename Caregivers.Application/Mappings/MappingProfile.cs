using System.Linq;
using AutoMapper;
using Caregivers.Application.DTOs;
using Caregivers.Domains;

namespace Caregivers.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CaregiverDto, Caregiver>()
                .ConstructUsing(x => new Caregiver(x.Id, x.FullName, x.Gender, x.Photo, x.Biography, x.Whatsapp));

            CreateMap<Caregiver, CaregiverDto>()
                .ConstructUsing(x => new CaregiverDto
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    Gender = x.Gender,
                    Biography = x.Biography,
                    Whatsapp = x.Whatsapp,
                    Photo = x.Photo,
                    CitiesServed = x.Cities.Select(s => new CityDto
                                                {
                                                    Id = s.Id, Name = s.Name
                                                })
                                                .ToList()
                });

            CreateMap<City, CityDto>()
                .ForMember(x => x.Name, 
                             o => 
                                 o.MapFrom(s => $@"{s.Name} - {s.State.Name}"));
        }
    }    
}
