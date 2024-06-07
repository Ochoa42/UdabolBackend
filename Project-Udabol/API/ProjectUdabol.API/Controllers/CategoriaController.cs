using Microsoft.AspNetCore.Mvc;
using ProjectUdabol.DATA.Services;
using ProjectUdabol.DOMAIN.Models.Cis.Indepent;

namespace ProjectUdabol.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController:ControllerBase
    {
        private readonly CategoriaService _categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetAllCategorias()
        {
            var categorias = await _categoriaService.GetCategorias();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoriaById(int id)
        {
            var categoria = await _categoriaService.GetCategoriaId(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> CreateCategoria(Categoria categoria)
        {
            var newCategoria = await _categoriaService.CreateCategoria(categoria);
            return CreatedAtAction(nameof(GetCategoriaById), new { id = newCategoria.id }, newCategoria);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCategoria(int id, Categoria categoria)
        {
            if (id != categoria.id)
            {
                return BadRequest();
            }

            var updatedCategoria = await _categoriaService.UpdateCategoria(categoria);
            if (updatedCategoria == null)
            {
                return NotFound();
            }

            return Ok(new { message = "Categoria actualizada correctamente" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategoria(int id)
        {
            var result = await _categoriaService.DeleteCategoriById(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
