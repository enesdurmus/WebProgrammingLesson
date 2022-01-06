using System;
using System.Collections.Generic;

#nullable disable

namespace Lesson5Application1.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? DepartmentId { get; set; }
        public int Salary { get; set; }

        public virtual Department Department { get; set; }
    }
}
