using ModernFrequency.Data;
using Microsoft.EntityFrameworkCore;
using ModernFrequency.Data.Abstraction.Repositories;
using ModernFrequency.Data.Repositories;
using ModernFrequency.Business.AutoMapper;
using AutoMapper;
using ModernFrequency.Business.Abstraction.Services;
using ModernFrequency.Business.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ModernFrequencyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IArtistRepository, ArtistRepository>();
builder.Services.AddScoped<IAlbumRepository, AlbumRepository>();
builder.Services.AddScoped<IAlbumArtistRepository, AlbumArtistRepository>();
builder.Services.AddScoped<ITrackRepository, TrackRepository>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddAutoMapper(typeof(ModernFrequencyMappingProifle));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
