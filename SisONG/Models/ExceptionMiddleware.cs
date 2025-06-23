using System.Net;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); // continua a pipeline
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro não tratado.");

            context.Response.ContentType = "application/json";

            if (ex is InvalidOperationException)
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            else if (ex is DbUpdateException dbEx && dbEx.InnerException?.Message.Contains("Duplicate entry") == true)
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            else
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var mensagem = ex switch
            {
                InvalidOperationException => ex.Message,
                DbUpdateException dbEx when dbEx.InnerException?.Message.Contains("Duplicate entry") == true
                    => "Já existe um usuário cadastrado com este e-mail.",
                _ => "Erro interno no servidor."
            };

            var response = new { mensagem };

            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}
