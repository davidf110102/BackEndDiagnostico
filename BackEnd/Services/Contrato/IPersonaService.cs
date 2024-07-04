using BackEnd.Models;
namespace BackEnd.Services.Contrato
{
    public interface IPersonaService
    {
        Task<List<Persona>> GetList();
        Task<Persona> Get(int idPersona);
        Task<Persona> Add(Persona modelo);
        Task<bool> Update(Persona modelo);
        Task<bool> Delete(Persona modelo);
    }
}
