using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Text.Json;

namespace Finance.API.Midleware;

public class ClobalExceptionHandlerMidleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ClobalExceptionHandlerMidleware> _logger;

    public ClobalExceptionHandlerMidleware(
        RequestDelegate next, 
        ILogger<ClobalExceptionHandlerMidleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            HandleExceptionAsync(exception, context);
        }
    }
    private async Task HandleExceptionAsync(Exception exception, HttpContext context)
    {
        _logger.LogError(exception, exception.Message);

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        ProblemDetails problem = new()
        {
            Status = (int)HttpStatusCode.InternalServerError,
            Type = "Server Error",
            Title = "Server Error",
            Detail = "An iternal server on occurred"
        };

        string json = JsonSerializer.Serialize(problem);

        await context.Response.WriteAsync(json);

        context.Response.ContentType = "application/json";
    }
}
