using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainEntities
{
    public class Employee
    {
        [Name("Employee Id")]
        public string EmployeeId { get; set; }
        [Key]
        public int Id { get; set; }
        [Name("First Name")]
        public string FirstName { get; set; }
        [Name("Last Name")]
        public string LastName { get; set; }
        [Name("Job Title")]
        public string JobTitle { get; set; }
        public string Email { get; set; }
        [Name("Mobile Phone")]
        public string MobilePhone { get; set; }
        [Name("Home Phone")]
        public string HomePhone { get; set; }
        [Name("Employment Status")]
        public string EmploymentStatus { get; set; }
        [Name("Pay Type")]
        public string PayType { get; set; }
        public string Status { get; set; }
        [Name("Employee Pay Group")]
        public string EmployeePayGroup { get; set; }
        [Name("Hire Date")]
        public string HireDate { get; set; }
        [Name("Termination Date")]
        public string TerminationDate { get; set; }
        [Name("Birth Date")]
        public string BirthDate { get; set; }
        [Name("Employee Supervisor")]
        public string EmployeeSupervisor { get; set; }
        [Name("Hierarchy Level 1")]
        public string HierarchyLevel1 { get; set; }
        [Name("Hierarchy Level 2")]
        public string HierarchyLevel2 { get; set; }
        public string Wage { get; set; }
    }
}
