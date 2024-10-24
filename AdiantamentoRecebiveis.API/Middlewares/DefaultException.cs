using System;
using System.Net;

namespace AdiantamentoRecebiveis.API.Middlewares;

public class DefaultException(string message, HttpStatusCode statusCode) : Exception(message)
{
    public HttpStatusCode? _statusCode { get; set; } = statusCode;
}
