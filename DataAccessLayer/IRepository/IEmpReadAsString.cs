using DomainEntities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface IEmpReadAsString
    {
        public string[] UploadData(IFormFile file);
        public List<EmployeeUpdate> GetRecords();
        public EmployeeUpdate FindbyId(string id);
        public void ReadJson();
    }
}
