using Microsoft.EntityFrameworkCore;
using Sistema_de_control_medico.Interfaces;
using Sistema_de_control_medico.Models;
using Sistema_de_control_medico.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("AppConnection");
builder.Services.AddDbContext<DBControl_medicoContext>(op => op.UseSqlServer(connectionString));
builder.Services.AddScoped<IMedico, CMedicoService>();
builder.Services.AddScoped<IPaciente, CPacienteService>();
builder.Services.AddScoped<IHabitacion, CHabitacionService>();
builder.Services.AddScoped<ICita, CCitaService>();
builder.Services.AddScoped<IIngreso, CIngresoService>();
builder.Services.AddScoped<IAltas, CAltaService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
