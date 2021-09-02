# EasyException

Easy Exception is a C# library to make Exception Handling Easy in .Net core App/Api. 

You can Register your own service to handle the Exception and return a standard response in every Exception.

You can Implement the Below Interface. You can handle your exceptions here the way you line and return a error response.
```c
    public interface IErrorHandlingService
    {
        public Task<ErrorResponse> HandleException(Exception context);
    }
```

you can Implement the above Interface like the below sample.


```c

 public class ErrorHandlingService : IErrorHandlingService
    {
        public Task<ErrorResponse> HandleException(Exception exception)
        {
            switch (exception)
            {
                case ProfileApiException ex:
                    return Task.FromResult<ErrorResponse>(new ErrorResponse() { Code = "ApiError", Message = exception.Message });

                case ProfileDomainException ex:
                    return Task.FromResult<ErrorResponse>(new ErrorResponse() { Code = "DomainError", Message = exception.Message });

                case ProfileApplicationException ex:
                    return Task.FromResult<ErrorResponse>(new ErrorResponse() { Code = "AppError", Message = exception.Message });

                default:
                    return Task.FromResult<ErrorResponse>(new ErrorResponse() { Code = "InternalError", Message = exception.Message });
            }
        }
    }

```


Now , in the StartUp.cs you can then register your Implementation as a singleton

```c
 public void ConfigureServices(IServiceCollection services)
 {
  services.AddSingleton<IErrorHandlingService,ErrorHandlingService>();
  ...
  
```

And then configuring the app builder you can tell the app to use the middleware.

```c
 public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
 {
   app.UseEasyExceptionHandling();
   ...
   
```
