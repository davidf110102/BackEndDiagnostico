using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using BackEnd.Services.Contrato;

namespace BackEnd.Services.Implementacion
{
    public class PersonaService : IPersonaService
    {
        private DbdiagnosticoContext _dbContext;

        public PersonaService(DbdiagnosticoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Persona>> GetList()
        {
            try { 
                List<Persona> lista = new List<Persona>();
                lista = await _dbContext.Personas.Include(gnr => gnr.GeneroNavigation).ToListAsync();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Persona> Get(int idPersona)
        {
            try
            {
                Persona? encontrada = new Persona();
                encontrada = await _dbContext.Personas.Include(gnr => gnr.GeneroNavigation)
                    .Where(e => e.IdPersona == idPersona).FirstOrDefaultAsync();
                return encontrada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Persona> Add(Persona modelo)
        {
            try
            {
                _dbContext.Personas.Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Update(Persona modelo)
        {
            try
            {
                _dbContext.Personas.Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(Persona modelo)
        {
            try
            {
                _dbContext.Personas.Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
