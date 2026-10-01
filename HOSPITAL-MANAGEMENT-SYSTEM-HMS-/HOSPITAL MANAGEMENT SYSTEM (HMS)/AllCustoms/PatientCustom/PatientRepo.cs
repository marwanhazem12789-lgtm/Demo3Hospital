using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.DepartmentCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Genarics;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.PatientCustom
{
    public class PatientRepo : GenaricRepo<Patient>, IPatientRepo
    {
        private readonly Context _context;
        public PatientRepo(Context c) : base(c)
        {
            _context = c;
        }
   
    }
}
