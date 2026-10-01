using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.AppoinmentDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Genarics;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.AppointmentCustom
{
    public interface IAppointmentRepo : IGenaricRepo<Appointment>
    {
        List<GetAppoinments> Get_todays_appointments();
    }
}
