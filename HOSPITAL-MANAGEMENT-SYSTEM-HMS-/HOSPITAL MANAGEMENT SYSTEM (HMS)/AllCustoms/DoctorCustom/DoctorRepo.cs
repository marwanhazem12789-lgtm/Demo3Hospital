using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DoctorDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Genarics;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.DoctorCustom
{
    public class DoctorRepo : GenaricRepo<Doctor> , IDoctorCustom
    {
        private readonly Context _context;
        public DoctorRepo(Context c):base(c)
        {
            _context = c;
        }

        public List<Doctor> Get_doctors_by_specialization(string specialization)
        {
            return _context.doctors.Where(i => i.Specialization.Contains(specialization)).ToList();
        }
    }
}
