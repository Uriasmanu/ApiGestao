using ApiGestao.Banco;
using ApiGestao.Rotas;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Definir a string de conexão diretamente no código
string connectionString = "Server=tcp:mylojaapi.database.windows.net,1433;Initial Catalog=loja.db;Persist Security Info=False;User ID=loja;Password=senha123#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar o contexto de banco de dados com a string de conexão
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapear as rotas
app.MapEstoqueRotas();

app.Run();
