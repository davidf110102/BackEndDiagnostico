using BackEnd.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

using BackEnd.Services.Contrato;
using BackEnd.Services.Implementacion;
using AutoMapper;
using BackEnd.DTOs;
using BackEnd.Utilidades;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<DbdiagnosticoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddScoped<IGeneroService, GeneroService>();
builder.Services.AddScoped<IPersonaService, PersonaService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddCors(options =>
{
    options.AddPolicy("Nueva Politica", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region PETICIONES API REST

app.MapGet("/genero/lista",async(
    IGeneroService _generoServicio,
    IMapper _mapper
    ) =>
{
    var listaGenero = await _generoServicio.GetList();
    var listaGeneroDTO = _mapper.Map<List<GeneroDTO>>(listaGenero);

    if (listaGeneroDTO.Count > 0)
        return Results.Ok(listaGeneroDTO);
    else
        return Results.NotFound();

});

app.MapGet("/persona/lista", async (
    IPersonaService _personaServicio,
    IMapper _mapper
    ) =>
{
    var listaPersona = await _personaServicio.GetList();
    var listaPersonaDTO = _mapper.Map<List<PersonaDTO>>(listaPersona);

    if (listaPersonaDTO.Count > 0)
        return Results.Ok(listaPersonaDTO);
    else
        return Results.NotFound();

});

app.MapPost("/persona/guadar", async (
    PersonaDTO modelo,
    IPersonaService _personaServicio,
    IMapper _mapper
    ) => {
        var _persona = _mapper.Map<Persona>(modelo);
        var _personaCreada = await _personaServicio.Add(_persona);

        if (_personaCreada.IdPersona != 0)
            return Results.Ok(_mapper.Map<PersonaDTO>(_personaCreada));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);


});

app.MapPut("/persona/actualizar/{idPersona}", async (
    int idPersona,
    PersonaDTO modelo,
    IPersonaService _personaServicio,
    IMapper _mapper
    ) => {
        var _encontrada = await _personaServicio.Get(idPersona);

        if(_encontrada is null) return Results.NotFound();

        var _persona = _mapper.Map<Persona>(modelo);

        _encontrada.Nombre = _persona.Nombre;
        _encontrada.Apellido = _persona.Apellido;
        _encontrada.FechaNacimiento = _persona.FechaNacimiento;
        _encontrada.GeneroId = _persona.GeneroId;

        var respuesta = await _personaServicio.Update(_encontrada);

        if(respuesta)
            return Results.Ok(_mapper.Map<PersonaDTO>(_encontrada));
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
    });

app.MapDelete("/persona/eliminar/{idPersona}", async (
    int idPersona,
    IPersonaService _personaServicio
    ) => {
        var _encontrada = await _personaServicio.Get(idPersona);

        if (_encontrada is null) return Results.NotFound();

        var respuesta = await _personaServicio.Delete(_encontrada);

        if (respuesta)
            return Results.Ok();
        else
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
    });

#endregion

app.UseCors("Nueva Politica");

app.Run();

