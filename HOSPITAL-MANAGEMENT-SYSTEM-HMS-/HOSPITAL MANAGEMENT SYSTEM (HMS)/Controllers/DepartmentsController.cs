using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DepartmentDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DoctorDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Unti_Of_works;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
       private readonly IunitOfWork _unitofwork ;
        private readonly IMapper mapper;
        public DepartmentsController(IMapper mapper , IunitOfWork unit)
        {
            _unitofwork = unit;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var e = _unitofwork.department.GetAll();
            var t = mapper.Map<List<GetDepartments>>(e);
            return Ok(t);
        }

        [HttpGet("Get count of doctors in department")]
        public IActionResult counting()
        {
            var y = _unitofwork.department.Get_doctor_count_for_each_department();
            var o = mapper.Map<List<Q2>>(y);
            return Ok(o);
        }

    }
}
