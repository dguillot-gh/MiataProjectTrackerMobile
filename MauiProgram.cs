using Microsoft.Extensions.Logging;
using MiataProjectTracker.Mobile.Services;

namespace MiataProjectTracker.Mobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            // Register our service
            builder.Services.AddSingleton<PartsService>();
            // Add this line to your existing MauiProgram.cs
            builder.Services.AddSingleton<BuildTaskService>();
            // In Program.cs
            builder.Services.AddSingleton<BuildLogService>();

            return builder.Build();
        }
    }
}