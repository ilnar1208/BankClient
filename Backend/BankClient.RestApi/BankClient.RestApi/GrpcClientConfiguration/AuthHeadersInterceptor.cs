using Grpc.Core.Interceptors;
using Grpc.Core;
using Microsoft.Net.Http.Headers;

namespace BankClient.RestApi;

/// <summary>Перехватчик заголовков аутентификации.</summary>
public class AuthHeadersInterceptor : Interceptor
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AuthHeadersInterceptor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(TRequest request, ClientInterceptorContext<TRequest, TResponse> context, AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        var authHeader = _httpContextAccessor.HttpContext?.Request.Headers.Authorization;

        if (string.IsNullOrWhiteSpace(authHeader))
            return base.AsyncUnaryCall(request, context, continuation);

        var metadata = new Metadata
        {
            {HeaderNames.Authorization, authHeader!}
        };

        var callOption = context.Options.WithHeaders(metadata);
        context = new ClientInterceptorContext<TRequest, TResponse>(context.Method, context.Host, callOption);

        return base.AsyncUnaryCall(request, context, continuation);
    }
}
