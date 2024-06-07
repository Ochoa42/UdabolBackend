using Microsoft.AspNetCore.Mvc;
using ProjectUdabol.DATA.Services;
using ProjectUdabol.DOMAIN.Models.Cis.Indepent;

namespace ProjectUdabol.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly InventarioService _inventarioService;

        public InventarioController(InventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventario>>> GetAllInventarios()
        {
            var inventarios = await _inventarioService.GetInventarios();
            return Ok(inventarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inventario>> GetInventarioById(int id)
        {
            var inventario = await _inventarioService.GetInventarioById(id);
            if (inventario == null)
            {
                return NotFound();
            }
            return Ok(inventario);
        }

        [HttpPost]
        public async Task<ActionResult<Inventario>> CreateInventario(Inventario inventario)
        {
            var newInventario = await _inventarioService.CreateInventario(inventario);
            return CreatedAtAction(nameof(GetInventarioById), new { id = newInventario.Id }, newInventario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInventario(int id, Inventario inventario)
        {
            if (id != inventario.Id)
            {
                return BadRequest();
            }

            var updatedInventario = await _inventarioService.UpdateInventario(inventario);
            if (updatedInventario == null)
            {
                return NotFound();
            }

            return Ok(new { message = "Inventario actualizado correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInventario(int id)
        {
            var result = await _inventarioService.DeleteInventarioById(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
