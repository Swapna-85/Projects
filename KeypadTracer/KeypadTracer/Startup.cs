using KeypadTracer.ChessPieces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KeypadTracer
{
    public static class Startup
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
               .ConfigureAppConfiguration((context, config) =>
               {
                   config.SetBasePath(Directory.GetCurrentDirectory());
                   config.AddJsonFile("appSettings.json");
               })
               .ConfigureServices((context, services) =>
               {
                   services.AddSingleton<IChessPieceFactory, ChessPieceFactory>();
                   services.AddTransient<IPhoneDigitValidator, PhoneDigitValidator>();
                   services.AddTransient<IKeypadTracer, KeypadTracer>();
               });
    }
}
