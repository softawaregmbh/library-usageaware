# UsageAware

UsageAware is a library for tracking user actions in an application.

Currently there is one implementation, UsageAware.ApplicationInsights, that logs the actions as custom events to ApplicationInsights.
There is also a middleware for easy ASP.NET Core integration:

```csharp
services.AddUsageAware(s =>
{
    var httpContext = s.GetRequiredService<IHttpContextAccessor>().HttpContext;
    return new UsageAwareContext(httpContext?.User?.Identity?.Name);
});
```

Attention: The service provider passed to the lambda expression in this case is not a scoped one, but based on the root scope.
You can still use the `HttpContextAccessor` though, as it is registered as a singleton.