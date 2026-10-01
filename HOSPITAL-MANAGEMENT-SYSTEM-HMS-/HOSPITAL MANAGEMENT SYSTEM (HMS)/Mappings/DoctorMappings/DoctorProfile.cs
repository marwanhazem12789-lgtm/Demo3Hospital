using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DoctorDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Mappings.DoctorMappings
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, GetDoctors>().ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
            CreateMap<CreateDoctor, Doctor>();
            CreateMap<UpdateDoctor, Doctor>().ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
