using ApiGestao.Banco;
using ApiGestao.Rotas;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Definir a string de conexão diretamente no código
// string connectionString = "Server=tcp:mylojaapi.database.windows.net,1433;Initial Catalog=loja.db;Persist Security Info=False;User ID=loja;Password=senha123#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=C:\\USERS\\USUARIO\\ONEDRIVE\\DOCUMENTOS\\URIAS.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(option => option.AddDefaultPolicy(policy =>
{
    policy.AllowAnyOrigin();
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
}));

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


app.UseCors();
// Mapear as rotas
app.MapClienteRotas();
app.MapLoginRotas(); ;

app.Run();
