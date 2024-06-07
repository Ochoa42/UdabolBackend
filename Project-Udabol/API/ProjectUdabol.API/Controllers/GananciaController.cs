using Microsoft.AspNetCore.Mvc;
using ProjectUdabol.DATA.Services;
using ProjectUdabol.DOMAIN.Models.Cis.Indepent;

namespace ProjectUdabol.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GananciaController : ControllerBase
    {
        private readonly GananciaService _gananciaService;

        public GananciaController(GananciaService gananciaService)
        {
            _gananciaService = gananciaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ganancia>>> GetAllGanancias()
        {
            var ganancias = await _gananciaService.GetGanancias();
            return Ok(ganancias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ganancia>> GetGananciaById(int id)
        {
            var ganancia = await _gananciaService.GetGananciaById(id);
            if (ganancia == null)
            {
                return NotFound();
            }
            return Ok(ganancia);
        }

        [HttpPost]
        public async Task<ActionResult<Ganancia>> CreateGanancia(Ganancia ganancia)
        {
            var newGanancia = await _gananciaService.CreateGanancia(ganancia);
            return CreatedAtAction(nameof(GetGananciaById), new { id = newGanancia.Id }, newGanancia);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGanancia(int id, Ganancia ganancia)
        {
            if (id != ganancia.Id)
            {
                return BadRequest();
            }

            var updatedGanancia = await _gananciaService.UpdateGanancia(ganancia);
            if (updatedGanancia == null)
            {
                return NotFound();
            }

            return Ok(new { message = "Ganancia actualizada correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGanancia(int id)
        {
            var result = await _gananciaService.DeleteGananciaById(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
