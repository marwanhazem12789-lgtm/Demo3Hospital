using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.AppoinmentDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Genarics;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.AppointmentCustom
{
    public class AppointmentRepo : GenaricRepo<Appointment> , IAppointmentRepo
    {
        private readonly Context _context;
        public AppointmentRepo(Context c) : base(c)
        {
            _context = c;
        }

        public List<GetAppoinments> Get_todays_appointments()
        {
            return _context.appointments
         .Where(i => i.AppointmentDate.Date == DateTime.Today).Select(i => new GetAppoinments
         {
             Doctorname = i.Doctor.FullName,
             Patientname = i.Patient.FullName,
             Status = i.Status,
             Id = i.Id,
             AppointmentDate = i.AppointmentDate
         })
         .ToList();
        }
    }
}
