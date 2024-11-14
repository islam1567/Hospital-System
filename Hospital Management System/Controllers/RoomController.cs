using Hospital_Management_System.Cores.Dtos;
using Hospital_Management_System.Cores.Interfaces;
using Hospital_Management_System.Cores.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRepository<RoomsDto> repo;

        public RoomController(IRepository<RoomsDto> repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [Route("get-all-room")]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet]
        [Route("get-room-by-id", Name = "RoomRoute")]
        public IActionResult GetById(string id)
        {
            return Ok(repo.GetById(id));
        }

        [HttpPost]
        [Route("add-room")]
        public IActionResult Add(RoomsDto dto)
        {
            if (ModelState.IsValid)
            {
                repo.Add(dto);
            }
            else
            {
                return BadRequest(ModelState);
            }
            var url = Url.Link("RoomRoute", new { id = dto.Id });
            return Created(url, dto);
        }

        [HttpPut]
        [Route("update-room")]
        public IActionResult Update(string id, RoomsDto dto)
        {
            if (ModelState.IsValid)
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
        [Route("delete-room")]
        public IActionResult Delete(string id)
        {
            repo.Delete(id);
            return Ok();
        }
    }
}
