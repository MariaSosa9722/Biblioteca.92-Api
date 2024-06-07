using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi92.Context;

namespace WebApi92.Services
{
    public class AutorServices :IAutorServices
    {
        private readonly ApplicationDBContext _context;
        public AutorServices(ApplicationDBContext context)
        {
            _context= context;
        }


        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> Response = new List<Autor>();
                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new { }, commandType: CommandType.StoredProcedure);

                Response = result.ToList();

                return new Response<List<Autor>> (Response);
            }   
            catch (Exception ex)
            {

                throw new Exception("Succedio un error :c" + ex.Message);
            }
        }

    }
}
