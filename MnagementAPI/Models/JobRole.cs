using System.ComponentModel.DataAnnotations;

namespace MnagementAPI.Models
{
    public class JobRole
    {
        [Key]
        public int Id { get; set; }
        public string JobRoleName { get; set; }
    }
}
