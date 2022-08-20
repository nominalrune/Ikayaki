using Ikayaki.Page;
namespace Ikayaki;

public partial class AppShell : Shell
{
    public Dictionary<string, Type> Routes { get; private set; } 
    public AppShell()
	{
		InitializeComponent();
        RegisterRoutes();
        BindingContext = this;
    }
    void RegisterRoutes()
    {
        Routes= new Dictionary<string, Type>() { 
            {"tasks", typeof(TaskIndex) },
            { "tasks/detail", typeof(TaskDetail)},
            {"tasks/new",typeof(TaskCreate) }
        };

        foreach (var item in Routes)
        {
            Routing.RegisterRoute(item.Key, item.Value);
        }
    }
}
