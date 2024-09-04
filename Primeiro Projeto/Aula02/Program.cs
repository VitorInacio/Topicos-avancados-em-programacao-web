using Aula02.Repositories;
using Aula02.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DI - Dependency Injetction 
builder.Services.AddSingleton<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IOperadoraRepository, OperadoraRepository>();
//DI - Dependency Injetction 


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
