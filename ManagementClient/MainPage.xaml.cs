using ManagementClient.DataServices;
using ManagementClient.Models;
using ManagementClient.Pages;
using System.Diagnostics;

namespace ManagementClient
{
    
    public partial class MainPage : ContentPage
    {
        private readonly IRestDataService _dataService;

        public MainPage(IRestDataService dataService)
        {
            InitializeComponent();
            _dataService = dataService;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await _dataService.GetAllEmployeesAsync();
        }

        async void OnAddEmployeeClicked(object sender , EventArgs e)
        {
            Debug.WriteLine("---> Add Button Clicked");

            var navigationParameter = new Dictionary<string, object>
            {
                {nameof(Employee) , new Employee() }
            };

            await Shell.Current.GoToAsync(nameof(ManageEmployeePage) , navigationParameter);
        }

        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("---> Item Changed Clicked");

            var navigationParameter = new Dictionary<string, object>
            {
                {nameof(Employee) , e.CurrentSelection.FirstOrDefault() as Employee }
            };

            await Shell.Current.GoToAsync(nameof(ManageEmployeePage), navigationParameter);
        }

        
    }

}
