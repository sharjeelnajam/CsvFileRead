using DataAccessLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using DomainEntities;
using Microsoft.AspNetCore.Http;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using DomainEntities.DataContext;
using Dtos;
using Findd.Api.Busi;

namespace DataAccessLayer.Repository
{
    public class EmpRecords : IEmpRecords

    {
        private readonly AppDbContext dbContext;

        public EmpRecords(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        List<string> Employeelist = new List<string>();
        List<Employee> EmployeeRecords = new List<Employee>();
        public List<string> GetRecords()
        {
            string filepath = @"E:\CSv file\file.csv";
            try
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Employeelist.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return Employeelist;
        }
       // public List<EmployeeUpdate>
        public List<EmployeeDto> UploadData(IFormFile file)
        {
            try
            {
                List<EmployeeDto> list = new List<EmployeeDto>();
                var fileextension = Path.GetExtension(file.FileName);
                var filename = Guid.NewGuid().ToString() + fileextension;
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename);
                using (FileStream fs = File.Create(filepath))
                {
                    file.CopyTo(fs);
                }
                CSVReader cSVReader = new CSVReader(filepath);

                if (fileextension == ".csv")
                {
                    using (var reader = new StreamReader(filepath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))

                    {
                        var stringRow = csv.GetRecords<List<Dictionary<string, object>>>();
                        var csvRecords = csv.GetRecords<EmployeeDto>().ToList();
                        var Employees = dbContext.employees.DefaultIfEmpty().ToList();

                        foreach (var emp in Employees)
                        {
                            if (!list.Any(x => x.EmployeeId == emp.EmployeeId))
                            {
                                dbContext.employees.Remove(emp);
                            }
                        }
                        //Assigning And Binding column


                        var bindingProp = BindingProp(csvRecords);
                        dbContext.SaveChanges();
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
            }
            return new List<EmployeeDto>();
        }
        private Employee getEmp(string employeeId)
        {
            return dbContext.employees.Where(x => x.EmployeeId == employeeId).FirstOrDefault();
        }
        private List<Employee> BindingProp(List<EmployeeDto> csvRecords)
        {            
            foreach (var record in csvRecords)
            {
                Employee employee = getEmp(record.EmployeeId);
                if (employee != null)
                {
                    UpdateEmployee(employee, record);  
                    dbContext.employees.UpdateRange(EmployeeRecords);
                }
                else
                {
                    //  employee = new Employee();
                     AddEmp(employee, record);               
                    dbContext.employees.AddRange(EmployeeRecords);
                }

            }

            return dbContext.employees.ToList();
        }
        private List<Employee> UpdateEmployee(Employee employee,EmployeeDto record)
        {
            employee.EmployeeId = record.EmployeeId;
            employee.Status = record.Status;
            employee.FirstName = record.FirstName;
            employee.LastName = record.LastName;
            employee.Email = record.Email;
            employee.HireDate = record.HireDate;
            employee.BirthDate = record.BirthDate;
            employee.TerminationDate = record.TerminationDate;
            employee.EmployeePayGroup = record.EmployeePayGroup;
            employee.EmploymentStatus = record.EmploymentStatus;
            employee.EmployeeSupervisor = record.EmployeeSupervisor;
            employee.MobilePhone = record.MobilePhone;
            employee.HierarchyLevel1 = record.HierarchyLevel1;
            employee.HierarchyLevel2 = record.HierarchyLevel2;
            employee.Wage = record.Wage;
            employee.JobTitle = record.JobTitle;
            employee.HomePhone = record.HomePhone;
            EmployeeRecords.Add(employee);
            return EmployeeRecords;

        }
        private List<Employee> AddEmp(Employee employee,EmployeeDto record)
        {
            employee.EmployeeId = record.EmployeeId;
            employee.Status = record.Status;
            employee.FirstName = record.FirstName;
            employee.LastName = record.LastName;
            employee.Email = record.Email;
            employee.HireDate = record.HireDate;
            employee.BirthDate = record.BirthDate;
            employee.TerminationDate = record.TerminationDate;
            employee.EmployeePayGroup = record.EmployeePayGroup;
            employee.EmploymentStatus = record.EmploymentStatus;
            employee.EmployeeSupervisor = record.EmployeeSupervisor;
            employee.MobilePhone = record.MobilePhone;
            employee.HierarchyLevel1 = record.HierarchyLevel1;
            employee.HierarchyLevel2 = record.HierarchyLevel2;
            employee.Wage = record.Wage;
            employee.JobTitle = record.JobTitle;
            employee.HomePhone = record.HomePhone;
            EmployeeRecords.Add(employee);
            return EmployeeRecords;
        }
        public int CountRecord()
        {
            var countRecords = dbContext.employees.Count();
            return countRecords;
        }
    }
}
