using ConsultaWebAPI.Repository;
using ConsultaWebAPI.Service;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient(x => new MySqlConnection(builder.Configuration.GetConnectionString("AWS")));

builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IZoomMeetingService, ZoomMeetingService>();
builder.Services.AddTransient<IConsultaService, ConsultaService>();
builder.Services.AddTransient<IConsultaDatabase, ConsultaDatabase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors(options => {options.AllowAnyOrigin(); options.AllowAnyHeader(); options.AllowAnyMethod();});

app.MapControllers();

app.Run();
