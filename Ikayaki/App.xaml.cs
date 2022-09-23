using Ikayaki.Repositories;
using Ikayaki.Models;

namespace Ikayaki;

public partial class App : Application
{
    public static class Model
    {
        public static Tasks Tasks { get; internal set; }
        public static Records Records { get; internal set; }
    }
    public App(
		Connection connection
		)
	{
		InitializeComponent();
        Model.Tasks = new Tasks(connection);
        Model.Records = new Records(connection);

        Model.Tasks.GetAll();
        Model.Records.GetAll();

        MainPage = new AppShell();
	}
}
