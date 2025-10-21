using Vendas.Application;
using Vendas.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// 🧩 Configuração do Serilog (logging estruturado)
builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration)
          .Enrich.FromLogContext()
          .WriteTo.Console();
});

// 🧱 Injeção das camadas DDD
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// 🌐 Configuração básica da API
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "Serviço de Vendas", Version = "v1" });
});

var app = builder.Build();

// 🚀 Pipeline da aplicação
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseSerilogRequestLogging(); // log de cada request
app.UseAuthorization();

app.MapControllers();

app.Run();
