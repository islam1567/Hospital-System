using Hospital_Management_System.Cores.Dtos;
using Hospital_Management_System.Cores.Interfaces;
using Hospital_Management_System.Cores.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoctorController : ControllerBase
    {
        private readonly IRepository<DoctorDto> repo;

        public DoctorController(IRepository<DoctorDto> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("get-all-doctor")]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet]
        [Route("get-doctor-by-id", Name ="DoctorRoute")]
        public IActionResult GetById(string id)
        {
            return Ok(repo.GetById(id));
        }

        [HttpPost]
        [Route("add-doctor")]
        public IActionResult Add(DoctorDto dto)
        {
            if(ModelState.IsValid)
            {
                repo.Add(dto);                
            }
            else
            {
                return BadRequest(ModelState);
            }
            var url = Url.Link("DoctorRoute", new { id = dto.Id });
            return Created(url, dto);
        }

        [HttpPut]
        [Route("update-doctor")]
        public IActionResult Update(string id, DoctorDto dto)
        {
            if(ModelState.IsValid)
            {
                repo.Update(id, dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            return Ok(dto);
        }

        [HttpDelete]
        [Route("delete-doctor")]
        public IActionResult Delete(string id)
        {
            repo.Delete(id);
            return Ok();
        }

    }
}
