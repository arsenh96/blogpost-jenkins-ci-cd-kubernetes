using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace HelloWorldWebApp;
public static class Program {

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        var app = builder.Build();
        app.Run();

    }

}