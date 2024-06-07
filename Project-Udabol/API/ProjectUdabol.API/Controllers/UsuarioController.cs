using Microsoft.AspNetCore.Mvc;
using ProjectUdabol.DATA.Services;
using ProjectUdabol.DOMAIN.Models.Cis;

namespace ProjectUdabol.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _UserService;

    public UsuarioController(UsuarioService userService)
    {
        _UserService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetAllUsers()
    {
        return await _UserService.GetUsuarios();
    }
    [HttpPost]
    public async Task<ActionResult<Usuario>> CreateUsuario(Usuario user)
    {
        var newIdea = await _UserService.CreateUser(user);
        return newIdea;
    }
    [HttpDelete("{id}")]
    public async Task <ActionResult> DeleteUser(int id)
    {
        try
        {
            await _UserService.DeleteUserById(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpPut]
    public async Task<ActionResult> Update(Usuario user)
    {
        var UpdateUser = await _UserService.UpdateUser(user);
        if (UpdateUser == null)
            return NotFound();
        return Ok( new {messsage = "Usuario actualizado correctamente"});
    }
}
