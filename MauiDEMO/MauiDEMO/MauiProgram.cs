using Microsoft.Maui.LifecycleEvents;
using Plugin.Fingerprint;

namespace MauiDEMO;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseFingerPrint()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		return builder.Build();
	}

    static MauiAppBuilder UseFingerPrint(this MauiAppBuilder builder)
    {
		builder.ConfigureLifecycleEvents(events =>
		{
#if ANDROID
			events.AddAndroid(android => android
				.OnCreate((activity, bundle) => CrossFingerprint.SetCurrentActivityResolver(() => activity)));
#endif
        });
        return builder;
    }
}
