using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.AppoinmentDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Mappings.AppoinmentMappings
{
    public class AppoinmentProfile : Profile
    {
        public AppoinmentProfile()
        {
            CreateMap<Appointment, GetAppoinments>()
                .ForMember(dest => dest.Doctorname, opt => opt.MapFrom(src => src.Doctor.FullName))
                .ForMember(dest => dest.Patientname, opt => opt.MapFrom(src => src.Patient.FullName));


            CreateMap<CreateAppoinment, Appointment>();

        }
    }
}
