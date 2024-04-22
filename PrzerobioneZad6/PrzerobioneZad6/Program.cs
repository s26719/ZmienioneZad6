using PrzerobioneZad6.Repositories;
using PrzerobioneZad6.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<AnimalsService>();
builder.Services.AddScoped<IAnimalRepository,AnimalRepository>();


var app = builder.Build(); // budowanie aplikacji


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();


app.MapControllers();
app.UseAuthorization();

app.Run();




