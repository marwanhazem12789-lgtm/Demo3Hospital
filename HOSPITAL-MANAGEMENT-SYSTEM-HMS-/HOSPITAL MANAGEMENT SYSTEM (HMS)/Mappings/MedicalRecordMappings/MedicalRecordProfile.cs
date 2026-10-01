using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.MedicalDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Mappings.MedicalRecordMappings
{
    public class MedicalRecordProfile : Profile
    {
        public MedicalRecordProfile()
        {
            CreateMap<CreateMedicalRecord, MedicalRecord>().ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
