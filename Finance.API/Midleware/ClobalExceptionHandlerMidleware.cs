using Finance.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Http;
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
        catch (UserNotFoundException ex)
        {
            _logger.LogError($"User not found: {ex}");
            await HandleExceptionAsync(context, HttpStatusCode.NotFound, ex.Message);
        }
        catch (InvalidPasswordException ex)
        {
            _logger.LogError($"Invalid password: {ex}");
            await HandleExceptionAsync(context, HttpStatusCode.BadRequest, ex.Message);
        }
        catch (Exception exception)
        {
            HandleExceptionAsync(context, HttpStatusCode.InternalServerError, "Internal Server Error.");
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string message)
    {
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
