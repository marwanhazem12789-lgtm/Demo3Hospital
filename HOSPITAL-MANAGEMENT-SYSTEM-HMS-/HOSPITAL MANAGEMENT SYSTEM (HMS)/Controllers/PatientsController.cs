using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.PatientDtos;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Unti_Of_works;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IunitOfWork _unitofwork;
        private readonly IMapper mapper;
        public PatientsController(IMapper mapper, IunitOfWork unit)
        {
            _unitofwork = unit;
            this.mapper = mapper;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var e = _unitofwork.patient.GetAll();
            var t = mapper.Map<List<GetPatient>>(e);
            return Ok(t);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var e = _unitofwork.patient.GetById(id);
            var t = mapper.Map<GetPatient>(e);
            return Ok(t);
        }

        [HttpPost]
        public IActionResult Create(CreatePatient pp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var patientModel = mapper.Map<Patient>(pp);

            _unitofwork.patient.Add(patientModel);
            _unitofwork.save();

            return Created("", patientModel);
        }
    }
}
