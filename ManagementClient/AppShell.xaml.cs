using ManagementClient.Pages;

namespace ManagementClient
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ManageEmployeePage) , typeof(ManageEmployeePage));
        }
    }
}
