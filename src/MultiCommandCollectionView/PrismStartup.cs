using System.Diagnostics;
using MultiCommandCollectionView.Abstractions;
using MultiCommandCollectionView.Pages;
using MultiCommandCollectionView.Services;
using MultiCommandCollectionView.ViewModels;
namespace MultiCommandCollectionView;

internal static class PrismStartup
{
    public static void Configure(PrismAppBuilder builder)
    {
        builder.RegisterTypes(RegisterTypes)
            .OnAppStart(OnAppStart);
    }

    private static void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
        containerRegistry.RegisterSingleton<IFileSystemService, FileSystemService>();
    }
    
    private static async Task OnAppStart(INavigationService navigationService)
    {
        var result = await navigationService.CreateBuilder()
            .AddNavigationPage()
            .AddSegment<MainViewModel>()
            .NavigateAsync();

        if (!result.Success)
        {
            Debug.WriteLine(result.Exception);
            Debugger.Break();
        }
    }
}