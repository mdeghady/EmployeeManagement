using ManagementClient.DataServices;
using ManagementClient.Models;
using System.Diagnostics;

namespace ManagementClient.Pages;

[QueryProperty(nameof(Employee) , "Employee")]
public partial class ManageEmployeePage : ContentPage
{
    private readonly IRestDataService _dataService;
    Employee _employee;
    bool _isnew;

    public Employee Employee
    {
        get => _employee;
        set
        {
            _isnew = IsNew(value);
            _employee = value;
            OnPropertyChanged();
        }
    }

    public ManageEmployeePage(IRestDataService dataService)
	{
		InitializeComponent();
        _dataService = dataService;
        BindingContext = this;

    }


    bool IsNew(Employee employee) {

        if (employee.Id == 0)
            
            return true;
        
        return false;
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        if (_isnew)
        {
            Debug.WriteLine("---> Add new Item");
            await _dataService.AddEmployeeAsync(Employee);

        }
        else
        {
            Debug.WriteLine("---> Update an Item");
            await _dataService.UpdateEmployee(Employee);
        }

        await Shell.Current.GoToAsync("..");

    }


    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        await _dataService.DeleteEmployeeAsync(Employee.Id);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }



}