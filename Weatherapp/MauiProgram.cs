using Microsoft.Extensions.Logging;
using Weatherapp.ViewModel;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using Weatherapp.Services;
using CommunityToolkit.Maui;

namespace Weatherapp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .UseMauiMaps()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>

            {
                fonts.AddFont("Aloha.ttf", "Aloha");
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("icomoon.ttf", "MOON");
            });
           


#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<IHttpService, HttpService>();
        return builder.Build();
	}
}
