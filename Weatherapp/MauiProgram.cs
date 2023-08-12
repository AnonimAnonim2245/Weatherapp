using Microsoft.Extensions.Logging;
using Weatherapp.ViewModel;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using Weatherapp.Services;
using CommunityToolkit.Maui;
using Weatherapp.Views;
using System.Data.Common;

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
        builder.Services.AddSingleton<Views.MainPage>();
        builder.Services.AddSingleton<Views.InfoPage>();
        builder.Services.AddSingleton<Views.ForecastPage>();
        builder.Services.AddSingleton<Views.CitiesPage>();

        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<LineViewModel>();
        builder.Services.AddSingleton<DataViewModel>();
        builder.Services.AddSingleton<EditViewModel>();

        builder.Services.AddSingleton<IHttpService, HttpService>();
        Routing.RegisterRoute(nameof(InfoPage), typeof(InfoPage));
        Routing.RegisterRoute(nameof(CitiesPage), typeof(CitiesPage));

        Routing.RegisterRoute(nameof(ForecastPage), typeof(ForecastPage));
        builder.Services.AddSingleton<Services.DbConnection>();


        return builder.Build();
	}
}
