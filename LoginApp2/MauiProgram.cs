using LoginApp2.services;
using Microsoft.Extensions.Logging;

namespace LoginApp2;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder.Services.AddScoped(x => new HttpClient());
		builder.Services.AddScoped<ILoginService, LoginService>();
        builder.Services.AddTransient<MainPage>(x => new MainPage(x.GetRequiredService<ILoginService>()));

        builder
			.UseMauiApp<App>()
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
