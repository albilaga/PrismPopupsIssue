using Microsoft.Extensions.Logging;
using Prism.Plugin.Popups;

namespace PrismPopupsIssue;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UsePrism(prism =>
            {
                prism.ConfigureMopupDialogs()
                    .RegisterTypes(containerRegistry =>
                    {
                        containerRegistry.RegisterForNavigation<MainPage>();
                        containerRegistry.RegisterForNavigation<PopupPage>();
                        containerRegistry.RegisterDialog<PopupView,PopupViewModel>();
                    })
                    .CreateWindow(navigationService =>
                        navigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MainPage)}"));
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}