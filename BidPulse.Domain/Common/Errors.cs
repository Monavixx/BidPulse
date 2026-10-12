using FluentResults;

namespace BidPulse.Domain.Common;

public static class Errors
{
    public static Error Error(string code, string message, int httpCode) => new Error(message)
        .WithMetadata("HttpCode", httpCode)
        .WithMetadata("ErrorCode", code);
    public static Error NotFound(string code, string message) => Error(code, message, 404);
    public static Error Validation(string code, string message) => Error(code, message, 400);
}
