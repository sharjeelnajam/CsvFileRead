using DomainEntities;
using Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IEmpRecords 
    {
       public int CountRecord();
        public List<string> GetRecords();
       public List<EmployeeDto> UploadData(IFormFile file);
   //     public string[] UploadData(IFormFile file);
    }
}
