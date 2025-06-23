using Microsoft.EntityFrameworkCore;
using SisONG.Data.Context;
using SisONG.Repositories;
using SisONG.Services;

var builder = WebApplication.CreateBuilder(args);

// Registrar seus serviços aqui
builder.Services.AddScoped<IAdministradorService, AdministradorService>();
builder.Services.AddScoped<IAdministradorRepository, AdministradorRepository>();
builder.Services.AddScoped<IDoadorService, DoadorService>();
builder.Services.AddScoped<IDoadorRepository, DoadorRepository>();
builder.Services.AddScoped<IDoacaoService, DoacaoService>();
builder.Services.AddScoped<IDoacaoRepository, DoacaoRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IEventoVoluntarioService, EventoVoluntarioService>();
builder.Services.AddScoped<IEventoVoluntarioRepository, EventoVoluntarioRepository>();
builder.Services.AddScoped<IHistoricoUsoRepository, HistoricoUsoRepository>();
builder.Services.AddScoped<HistoricoUsoService>();
builder.Services.AddScoped<IProdutoInsumoRepository, ProdutoInsumoRepository>();
builder.Services.AddScoped<IProdutoInsumoService, ProdutoInsumoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IVoluntarioService, VoluntarioService>();
builder.Services.AddScoped<IVoluntarioRepository, VoluntarioRepository>();
builder.Services.AddScoped<ITransacaoFinanceiraRepository, TransacaoFinanceiraRepository>();
builder.Services.AddScoped<ITransacaoFinanceiraService, TransacaoFinanceiraService>();
builder.Services.AddScoped<IRelatorioRepository, RelatorioRepository>();
builder.Services.AddScoped<IRelatorioService, RelatorioService>();
builder.Services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
builder.Services.AddScoped<INotificacaoService, NotificacaoService>();
builder.Services.AddScoped<IPontoColetaRepository, PontoColetaRepository>();
builder.Services.AddScoped<IPontoColetaService, PontoColetaService>();
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<SisONGContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 31))));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<RelatorioPdfService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseDeveloperExceptionPage();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
