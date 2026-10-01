using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.PatientDtos;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Mappings.PatientMappings
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, GetPatient>();
            CreateMap<Patient, GetPatientByID>();
            CreateMap<CreatePatient, Patient>().ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
