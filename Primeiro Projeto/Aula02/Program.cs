using Aula02.Repositories;
using Aula02.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DI - Dependency Injection - Injecao de Dependencia       -- IMPORTANTE para prova

//builder.Services.AddSingleton<IPessoaRepository, PessoaRepository>();   AddSingleton - um para todo a aplicação
//builder.Services.AddTransient<IPessoaRepository, PessoaRepository>();   AddTransient - toda vez cria um item
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();         //AddScoped - reaproveita o item 
builder.Services.AddScoped<IOperadoraRepository, OperadoraRepository>();
builder.Services.AddScoped<ITelefoneRepository, TelefoneRepository>();

//Adicionando o servico de cache na aplicacao
builder.Services.AddMemoryCache();

//DI - Dependency Injection - Injecao de Dependencia



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
