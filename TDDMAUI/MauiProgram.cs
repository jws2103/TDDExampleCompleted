using TDDMAUI.Services;
using TDDMAUI.Services.Interfaces;
using TDDMAUI.ViewModels;
using TDDMAUI.Views;

namespace TDDMAUI;

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

		builder.Services.AddTransient<MyAccountPage>();
		builder.Services.AddTransient<MyAccountPageModel>();
		builder.Services.AddSingleton<IBankAccountService, BankAccountService>();
		builder.Services.AddSingleton<ILogger, Logger>();
		return builder.Build();
	}
}

