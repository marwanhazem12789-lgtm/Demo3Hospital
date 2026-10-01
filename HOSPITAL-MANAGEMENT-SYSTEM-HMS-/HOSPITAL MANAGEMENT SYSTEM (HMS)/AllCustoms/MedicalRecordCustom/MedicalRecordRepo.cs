using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.DepartmentCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Genarics;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.MedicalRecordCustom
{
    public class MedicalRecordRepo : GenaricRepo<MedicalRecord>, IMedicalRecord
    {
        private readonly Context _context;
        public MedicalRecordRepo(Context c) : base(c)
        {
            _context = c;
        }
   
    }
}
