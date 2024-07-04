using AutoMapper;
using BackEnd.DTOs;
using BackEnd.Models;
using System.Globalization;

namespace BackEnd.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Genero
            CreateMap<Genero, GeneroDTO>().ReverseMap();
            #endregion

            #region Persona
            CreateMap<Persona, PersonaDTO>()
                .ForMember(destino =>
                destino.NombreGenero,
                opt => opt.MapFrom(origen => origen.GeneroNavigation.Nombre)
                )
                .ForMember(destino =>
                destino.FechaNacimiento,
                opt => opt.MapFrom(origen => origen.FechaNacimiento.Value.ToString("dd/MM/yyyy"))
               );

            CreateMap<PersonaDTO, Persona>()
                .ForMember(destino =>
                destino.GeneroNavigation,
                opt => opt.Ignore()
                )
                .ForMember(destino =>
                destino.FechaNacimiento,
                opt => opt.MapFrom(origen => DateTime.ParseExact(origen.FechaNacimiento, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture))
               );
            #endregion
        }
    }
}
