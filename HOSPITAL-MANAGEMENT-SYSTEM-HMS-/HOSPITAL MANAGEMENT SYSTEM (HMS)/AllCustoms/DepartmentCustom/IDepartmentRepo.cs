using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DepartmentDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Genarics;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.DepartmentCustom
{
    public interface IDepartmentRepo : IGenaricRepo<Department>
    {
        List<Q2> Get_doctor_count_for_each_department();
    }
}
