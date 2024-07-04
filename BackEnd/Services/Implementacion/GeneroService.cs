using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using BackEnd.Services.Contrato;

namespace BackEnd.Services.Implementacion
{
    public class GeneroService : IGeneroService
    {
        private DbdiagnosticoContext _dbContext;

        public GeneroService(DbdiagnosticoContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<List<Genero>> GetList()
        {
            try
            {
                List<Genero> lista = new List<Genero>();
                lista = await _dbContext.Generos.ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
