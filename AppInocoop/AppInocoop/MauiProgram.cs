﻿using AppInocoop.ViewModels;

namespace AppInocoop
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

            builder.Services.AddSingleton<IBluetoothService, BluetoothService>();
            builder.Services.AddSingleton<MainViewModel>();

            return builder.Build();
        }
    }
}
