using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MnagementAPI.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public required string EmployeeName { get; set; }

        public required String JobRole { get; set; }
    }
}
