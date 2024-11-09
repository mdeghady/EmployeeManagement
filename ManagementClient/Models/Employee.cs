using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagementClient.Models
{
    public class Employee : INotifyPropertyChanged
    {
        int _id;
        public int Id {
            get => _id;
            set
            {
                if (_id == value) {
                    return;
                };
                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        string _employeeName;
        public string EmployeeName
        {
            get => _employeeName;
            set
            {
                if (_employeeName == value)
                {
                    return;
                };
                _employeeName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EmployeeName)));
            }
        }

        string _jobRole;

        public string JobRole
        {
            get => _jobRole;
            set
            {
                if (_jobRole == value)
                {
                    return;
                };
                _jobRole = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(JobRole)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
