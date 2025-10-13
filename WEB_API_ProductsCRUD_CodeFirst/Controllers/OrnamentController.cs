using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_API_ProductsCRUD_CodeFirst.Models;
using WEB_API_ProductsCRUD_CodeFirst.Repository;

namespace WEB_API_ProductsCRUD_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrnamentController : ControllerBase
    {
        private readonly IOrnamentRepository _repo;
        public OrnamentController(IOrnamentRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            return Ok(await _repo.GetAllOrnaments());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute]int id)
        {
            Ornament ornament = await _repo.GetById(id);
            if (ornament == null)
            {
                return NotFound();
            }
            return Ok(ornament);
        }

        [HttpGet("ornaments/{metal}")]
        public async Task<IActionResult> GetByMetal([FromRoute] string metal)
        {
            IEnumerable<Ornament> ornaments = await _repo.GetOrnamentsByMetal(metal);
            if (ornaments == null)
            {
                return NotFound();
            }
            return Ok(ornaments);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrnament(Ornament ornament)
        {
            await _repo.AddNewOrnament(ornament);
            return CreatedAtAction(nameof(GetByID), new { id = ornament.Id }, ornament);
        }

        [HttpPatch("{id}/{price}")]
        public async Task<IActionResult> UpdatePrice([FromRoute] int id, [FromRoute]double price)
        {
            Ornament ornament = await _repo.GetById(id);
            if (ornament == null)
            {
                return NotFound();
            }
            await _repo.UpdatePrice(id, price);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrnament(int id)
        {
            Ornament ornament = await _repo.GetById(id);
            if (ornament == null)
            {
                return NotFound();
            }
            await _repo.DeleteOrnament(id);
            return Ok();
        }
    }
}
