using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DoctorDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Genarics;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.DoctorCustom
{
    public interface IDoctorCustom : IGenaricRepo<Doctor>
    {
        List<Doctor> Get_doctors_by_specialization(string specialization);
    }
}
