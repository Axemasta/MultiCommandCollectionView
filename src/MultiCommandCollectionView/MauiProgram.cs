using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using MultiCommandCollectionView.Abstractions;
using MultiCommandCollectionView.Fonts;
using MultiCommandCollectionView.Pages;
using MultiCommandCollectionView.Services;
using MultiCommandCollectionView.ViewModels;
namespace MultiCommandCollectionView;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCompatibility()
			.ConfigureMauiHandlers(handlers =>
			{
				// https://devblogs.microsoft.com/xamarin/introducing-net-maui-compatibility-for-the-xamarin-community-toolkit/
				handlers.AddCompatibilityRenderers(typeof(Xamarin.CommunityToolkit.UI.Views.MediaElementRenderer).Assembly);
			})
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				
				fonts.AddFont("fa-brands-400.ttf", FontConstants.FontAwesomeBrands);
				fonts.AddFont("fa-regular-400.ttf", FontConstants.FontAwesomeRegular);
				fonts.AddFont("fa-solid-900.ttf", FontConstants.FontAwesomeSolid);
			});

		builder.Services.AddTransient<MainPage>();
		builder.Services.AddTransient<MainViewModel>();
		builder.Services.AddTransient<IFileSystemService, FileSystemService>();

#if DEBUG
		builder.Logging.AddDebug();
		builder.Logging.SetMinimumLevel(LogLevel.Trace);
#endif

		return builder.Build();
	}
}

