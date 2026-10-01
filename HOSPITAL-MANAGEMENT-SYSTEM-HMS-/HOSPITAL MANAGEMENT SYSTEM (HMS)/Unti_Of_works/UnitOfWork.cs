using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.AppointmentCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.DepartmentCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.DoctorCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.MedicalRecordCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.PatientCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Unti_Of_works
{
    public class UnitOfWork : IunitOfWork
    {
        private readonly Context _context;
        public IDepartmentRepo department { get; }
        public IDoctorCustom doctor { get; }
        public IAppointmentRepo appointment { get; }
        public IMedicalRecord MedicalRecord { get; }
        public IPatientRepo patient { get; }
        public UnitOfWork(Context c , IDoctorCustom d , IAppointmentRepo a , IDepartmentRepo de , IPatientRepo p , IMedicalRecord m)
        {
            _context = c;
            department = de;
            doctor = d;
            appointment = a;    
            MedicalRecord = m;
            patient = p;

        }
       public int save()
        {
            return _context.SaveChanges();
        }


    }
}
