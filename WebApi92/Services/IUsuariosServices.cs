using Domain.Entities;

namespace WebApi92.Services
{
    public interface IUsuariosServices
    {

        public Task<Response<List<Usuario>>> GetUsuarios();

        public Task<Response<UsuariosResponse>> CrearUsuario(UsuariosResponse request);

        public Task<Response<Usuario>> GetByID(int id);
    }
}
