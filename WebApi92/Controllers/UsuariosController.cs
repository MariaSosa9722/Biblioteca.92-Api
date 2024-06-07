using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebApi92.Services;

namespace WebApi92.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosServices _usuariosServices;
        public UsuariosController(IUsuariosServices usuariosServices)
        {

            _usuariosServices = usuariosServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var response = await _usuariosServices.GetUsuarios();

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _usuariosServices.GetByID(id));
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] UsuariosResponse request)
        {

            var response = await _usuariosServices.CrearUsuario(request);
            return Ok(response);
        }
            

    }
}
