using BackEnd.Models;

namespace BackEnd.Services.Contrato
{
    public interface IGeneroService
    {
        Task<List<Genero>> GetList();
    }
}
