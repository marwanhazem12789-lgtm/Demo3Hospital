using AutoMapper;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.AllCustoms.DoctorCustom;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DepartmentDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.DTOs.DoctorDTOs;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Models;
using HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Unti_Of_works;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace HOSPITAL_MANAGEMENT_SYSTEM__HMS_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IunitOfWork _unitofwork;
        private readonly IMapper mapper;
        public DoctorsController(IMapper mapper, IunitOfWork unit)
        {
            _unitofwork = unit;
            this.mapper = mapper;
        }


        [HttpGet("{N}")]
        public IActionResult GetAll(string N)
        {
            var y = _unitofwork.doctor.Get_doctors_by_specialization(N);
            var o = mapper.Map<List<GetDoctors>>(y);
            return Ok(o);
        }

        [HttpGet]
        public IActionResult Getall()
        {
            var y = _unitofwork.doctor.GetAll();
            var o = mapper.Map<List<GetDoctors>>(y);
            return Ok(o);
        }

        [HttpPost]
        public IActionResult CreatenewDoctor(CreateDoctor dd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var doctorModel = mapper.Map<Doctor>(dd);

            _unitofwork.doctor.Add(doctorModel);
            _unitofwork.save();           

            return Created("",doctorModel);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id , UpdateDoctor dd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var d = mapper.Map<Doctor>(dd);

            d.Id = id;

            _unitofwork.doctor.Update(d);
            _unitofwork.save();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var doctor = _unitofwork.doctor.GetById(id);

            if (doctor == null)
            {
                return NotFound();
            }

            _unitofwork.doctor.Delete(doctor.Id);
            _unitofwork.save();

            return NoContent();
        }

    }

}
