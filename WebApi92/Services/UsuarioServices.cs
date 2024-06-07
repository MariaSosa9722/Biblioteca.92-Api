using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi92.Context;

namespace WebApi92.Services
{
    public class UsuarioServices : IUsuariosServices
    {
        private readonly ApplicationDBContext _context;
        public UsuarioServices(ApplicationDBContext context)
        { 
            _context = context;

        }

        
        public async Task<Response<List<Usuario>>> GetUsuarios()
        {
            try
            {
                List<Usuario> response = await _context.Usuarios.Include(y => y.Roles).ToListAsync();

                return new Response<List<Usuario>>(response);

            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error "+ex.Message) ;
            }

        }

        public async Task<Response<Usuario>> GetByID(int id)
        {
            try
            {
                Usuario res = await _context.Usuarios.FirstOrDefaultAsync(x=> x.PkUsuario == id);

                return new Response<Usuario>(res);
            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error " + ex.Message);
            }
        }



        public async Task<Response<UsuariosResponse>> CrearUsuario(UsuariosResponse request)
        {
            try
            {
                Usuario usuario = new Usuario() 
                {
                     Nombre = request.Nombre,
                     User= request.User,
                     Password= request.Password,
                     FkRol = request.FkRol
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return new Response<UsuariosResponse>(request);
              
            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error " + ex.Message);
            }
        }



    }
}
