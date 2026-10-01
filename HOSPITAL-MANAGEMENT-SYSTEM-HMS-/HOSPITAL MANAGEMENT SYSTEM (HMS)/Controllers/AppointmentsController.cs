using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.AppoinmentDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Unti_Of_works;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IunitOfWork _unitofwork;
        private readonly IMapper mapper;
        public AppointmentsController(IMapper mapper, IunitOfWork unit)
        {
            _unitofwork = unit;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Getaall()
        {
            var t = _unitofwork.appointment.Get_todays_appointments();
            var y = mapper.Map<List<GetAppoinments>>(t);
            return Ok(y);
        }

        [HttpPost]
        public IActionResult Create(CreateAppoinment aa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var t = mapper.Map<Appointment>(aa);

            _unitofwork.appointment.Add(t);_unitofwork.save();
            return Ok(t);
        }
    }
}
