﻿using ManagementClient.DataServices;
using ManagementClient.Pages;
using Microsoft.Extensions.Logging;

namespace ManagementClient
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IRestDataService , RestDataService>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<ManageEmployeePage>();



            return builder.Build();
        }
    }
}
