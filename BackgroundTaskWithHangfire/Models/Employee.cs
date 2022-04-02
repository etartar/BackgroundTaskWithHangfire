using System;
using System.ComponentModel.DataAnnotations;

namespace BackgroundTaskWithHangfire.Models
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
