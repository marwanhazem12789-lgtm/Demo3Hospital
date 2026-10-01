using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.AppoinmentDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.MedicalDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Unti_Of_works;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class medicalRecordsController : ControllerBase
    {
        private readonly IunitOfWork _unitofwork;
        private readonly IMapper mapper;
        public medicalRecordsController(IMapper mapper, IunitOfWork unit)
        {
            _unitofwork = unit;
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateMedicalRecord aa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var t = mapper.Map<MedicalRecord>(aa);

            _unitofwork.MedicalRecord.Add(t); _unitofwork.save();
            return Ok(t);
        }
    }
}
