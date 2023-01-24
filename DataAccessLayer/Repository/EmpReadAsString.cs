using DataAccessLayer.IRepository;
using DomainEntities;
using DomainEntities.DataContext;
using DomainEntities.JsonReadClass;
using DomainEntities.JsonReadClasses;
using Dtos;
using Findd.Api.Busi;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccessLayer.Repository
{
    public class EmpReadAsString : IEmpReadAsString

    {
        private readonly AppDbContext _dbContext;
        public EmpReadAsString(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public EmpReadAsString()
        {

        }
        public string[] UploadData(IFormFile file)
        {
            try
            {
             
                var fileextension = Path.GetExtension(file.FileName);
                var filename = Guid.NewGuid().ToString() + fileextension;
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename);
                using (FileStream fs = File.Create(filepath))
                {
                    file.CopyTo(fs);
                }

                CSVReader csv = new CSVReader(filepath);
               // var csvLines = new string[] { };
                List<List<string>> empRecords = new List<List<string>>();
                List<EmployeeUpdate> csvEmployees = new List<EmployeeUpdate>();

                try
                {
                    //use the csvreader to read in the csv data
                    List<string> fields;
                    while ((fields = csv.GetCSVLine()) != null)
                    {
                        List<string> rowData = new List<string>();

                        foreach (var column in fields)
                        {
                            if (column.Trim().Length != 0)
                            {

                                rowData.Add(column);
                            }
                            else
                            {
                                rowData.Add(string.Empty);
                            }
                        }
                        empRecords.Add(rowData);
                    }
                    var headerCheck = true;
                    foreach (var row in empRecords)
                    {
                        if(headerCheck)
                        {
                            headerCheck = false;
                            continue;
                        }
                        EmployeeUpdate csvEmployee = BindData(row);
                        csvEmployees.Add(csvEmployee);
                    }
                    _dbContext.employeeUpdatedFile.AddRange(csvEmployees);
                    _dbContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
                return new string[] { };
            }
            catch 
            {
                return new string[] { };
            }
        }
        private EmployeeUpdate BindData(List<string> csvRow)
        {
            try
            {
                 var hireDateCheck = DateTime.TryParse(csvRow[18], out var hireDate);
                var termDateCheck = DateTime.TryParse(csvRow[21], out var termDate);
                var birthDateCheck = DateTime.TryParse(csvRow[23], out var birthDate);
                EmployeeUpdate csvEmployee = new EmployeeUpdate()
                {
                    Id = Guid.NewGuid().ToString(),
                    ClockPin = String.IsNullOrWhiteSpace(csvRow[0]) ? string.Empty : csvRow[0],
                    ExternalId = String.IsNullOrWhiteSpace(csvRow[0]) ? string.Empty : csvRow[0],
                    FirstName = String.IsNullOrWhiteSpace(csvRow[2]) ? String.Empty : csvRow[2],
                    LastName = String.IsNullOrWhiteSpace(csvRow[3]) ? String.Empty : csvRow[3],
                    Email = String.IsNullOrWhiteSpace(csvRow[6]) ? String.Empty : csvRow[6],
                    HireDate = hireDateCheck ? hireDate : null,
                    TerminationDate = termDateCheck ? termDate : null,
                    DateOfBirth = birthDateCheck ? birthDate : null,
                    Field1=String.IsNullOrWhiteSpace(csvRow[13]) ? String.Empty : csvRow[13],
              
                };
                var empPosition = _dbContext.positions.FirstOrDefault(x => x.CostCenter.Equals(csvRow[27]));
                var defaultHierarchyId = _dbContext.HierarchyItems.FirstOrDefault(x => x.CostCenter.Equals(csvRow[27]))?.Id;
                var payrollHierarchyId = _dbContext.HierarchyItems.FirstOrDefault(x => x.CostCenter.Equals(csvRow[26]))?.Id;
                csvEmployee.DefaultHierarchyItemId=defaultHierarchyId;
                csvEmployee.PayrollHierarchyItemId=payrollHierarchyId;
                csvEmployee.DefaultPunchHierarchyId=payrollHierarchyId;

                if (empPosition != null)
                {
                    csvEmployee.Position = new List<Position>();
                    csvEmployee.DefaultPositionId = empPosition.Id;
                    csvEmployee.Position.Add(empPosition);
                }
                
                return csvEmployee;
            }
            catch (Exception ex)
            {
                return new EmployeeUpdate();
            }
        }

        public List<EmployeeUpdate> GetRecords()
        {
            var employeeRecords = _dbContext.employeeUpdatedFile.DefaultIfEmpty().ToList();
            return employeeRecords;
        }
        public EmployeeUpdate FindbyId(string id)
        {
            var findEmploye = _dbContext.employeeUpdatedFile.Find(id);
            return findEmploye;
        }
        public void ReadJson()
        {
            string json = File.ReadAllText(@"C:\Users\s\source\repos\CSVfile.Project\CSVfile.Project\wwwroot\MyJson.json");
            Root jsonConvertData = JsonConvert.DeserializeObject<Root>(json);
            List<Position> updatePositions = new List<Position>();
            List<Position> insertPositions = new List<Position>();
       
            List<HierarchyItem> updateHierarachyItems=new List<HierarchyItem>();
            List<HierarchyItem>  insertHierarachyItems=new List<HierarchyItem>();   

            foreach (var item in jsonConvertData.PositionDefinitions)
            {
                Position empPosition = getEmpPosition(item._id);
                if (empPosition != null)
                    updatePositions.Add(GetPosition(empPosition, item));
                else
                    insertPositions.Add(GetPosition(empPosition, item));
            }
            _dbContext.positions.UpdateRange(updatePositions);
            _dbContext.positions.AddRange(insertPositions);
            _dbContext.SaveChanges();

            foreach (var item in jsonConvertData.HierarchyItems)
            {
                HierarchyItem hierarchyItem = getEmpHierarchy(item._id);
                if (hierarchyItem != null)
                    updateHierarachyItems.Add(GetHierarchy(hierarchyItem, item));
                else
                    insertHierarachyItems.Add(GetHierarchy(hierarchyItem, item));
            }
             _dbContext.HierarchyItems.UpdateRange(updateHierarachyItems);
             _dbContext.HierarchyItems.AddRange(insertHierarachyItems);
             _dbContext.SaveChanges();

        }
        private Position getEmpPosition(string Id)
        {
            return _dbContext.positions.Where(x => x.Id == Id).DefaultIfEmpty().FirstOrDefault();
        }
        private HierarchyItem getEmpHierarchy(string Id)
        {
           return _dbContext.HierarchyItems.Where(x => x.Id == Id).DefaultIfEmpty().FirstOrDefault();
        }
        private Position GetPosition(Position position, PositionDefinition item)
        {
            position ??= new();
            position.Id = item._id;
            position.BasePositionId = item.BasePositionId;
            position.Active = item.Active;
            position.Copied = item.Copied;
            position.Active = item.Active;
            position.HierarchyItemId = (string)item.HierarchyItemId;
            position.ExternalId = (string)item.ExternalId;
            position.Name = item.Name;
            position.Description = item.Description;
            position.CostCenter = item.CostCenter;
            return position;
        }
        private HierarchyItem GetHierarchy(HierarchyItem hierarchyItem, HierarchyItems item)
        {
            hierarchyItem ??= new();
            hierarchyItem.Id = Guid.NewGuid().ToString();
            hierarchyItem.Id = item._id;
            hierarchyItem.Label = item.Label;
            hierarchyItem.HierarchyDefinitionId = item.HierarchyDefinitionId;
            hierarchyItem.ParentId = item.ParentId;
            hierarchyItem.CostCenter = item.CostCenter;
            hierarchyItem.Active = item.Active;
            hierarchyItem.ExternalId = item.ExternalId;
            hierarchyItem.ExternalId2 = (string)item.ExternalId2;
            hierarchyItem.Position = (List<Position>)item.Positions;
            hierarchyItem.PayrollExportName = item.PayrollExportName;
            hierarchyItem.UserModified = item.UserModified;
            hierarchyItem.Type = item.Type;
            return hierarchyItem;
        }
    }
}
