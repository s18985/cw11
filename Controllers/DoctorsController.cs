using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cw11.DAL;
using cw11.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cw11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private IDoctorDbService _service;

        public DoctorsController(IDoctorDbService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            var res = _service.GetDoctors();

            return Ok(res);
        }


        [HttpPut("{id}")]
        public IActionResult ModifyDoctor(int id, ModifyDoctorRequest request)
        {

            var res = _service.ModifyDoctor(id, request);

            if (res != null)
            {
                return Ok(res);
            }
            else
            {
                return NotFound("Nie ma takiego doktora");
            }

        }


        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var res = _service.DeleteDoctor(id);

            if (res == true)
            {
                return Ok("Usunieto doktora");
            }
            else
            {
                return NotFound("Nie ma takiego doktora");
            }
        }

        [HttpPost]
        public IActionResult AddDoctor(AddDoctorRequest request)
        {
            var res = _service.AddDoctor(request);

            return Ok(res);
        }



    }
}