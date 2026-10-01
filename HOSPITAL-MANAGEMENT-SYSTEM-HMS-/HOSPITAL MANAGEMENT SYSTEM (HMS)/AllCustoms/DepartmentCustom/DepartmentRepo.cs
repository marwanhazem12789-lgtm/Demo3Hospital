using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DepartmentDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Genarics;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.DepartmentCustom
{
    public class DepartmentRepo : GenaricRepo<Department> , IDepartmentRepo
    {
        private readonly Context _context;
        public DepartmentRepo(Context c) : base(c)
        {
            _context = c;
        }

        public List<Q2> Get_doctor_count_for_each_department()
        {
            var t = _context.departments.Select(d => new Q2
            {
                Name = d.Name,
                Location = d.Location,
                counntt = d.Doctors.Count()
            })
        .ToList();
            return t;
        }

    }
}
