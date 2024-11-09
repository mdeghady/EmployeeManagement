using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManagementClient.Models
{
    public class JobRole : INotifyPropertyChanged
    {

        int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (_id == value)
                {
                    return;
                };
                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id)));
            }
        }

        string _jobRoleName;
        public string JobRoleName
        {
            get => _jobRoleName;
            set
            {
                if (_jobRoleName == value)
                {
                    return;
                };
                _jobRoleName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(JobRoleName)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
