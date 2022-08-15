
using Ikayaki.Repository;

using Ikayaki.ViewModel;
namespace Ikayaki;

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
        string dbPath = FileAccessHelper.GetLocalFilePath("ikayaki.db3");
        builder.Services.AddSingleton<TaskRepository>(s => ActivatorUtilities.CreateInstance<TaskRepository>(s, dbPath));
        builder.Services.AddSingleton<TaskViewModel>(s => ActivatorUtilities.CreateInstance<TaskViewModel>(s));


        return builder.Build();
	}
}
