using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.AppointmentCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.DepartmentCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.DoctorCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.MedicalRecordCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.PatientCustom;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Unti_Of_works
{
    public interface IunitOfWork
    {
        IDepartmentRepo department { get; }
        IAppointmentRepo appointment { get; }
        IDoctorCustom doctor { get; }
        IPatientRepo patient { get; }
        IMedicalRecord MedicalRecord { get; }

        int save();
    }
}
