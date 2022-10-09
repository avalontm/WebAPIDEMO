using Android.App;
using Android.Runtime;

namespace MauiDEMO;

[Application(UsesCleartextTraffic = true)]  // connect to local service
public class MainApplication : MauiApplication
{
	public MainApplication(IntPtr handle, JniHandleOwnership ownership): base(handle, ownership)
	{
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
