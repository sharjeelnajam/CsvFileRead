using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
using DomainEntities;
using Microsoft.AspNetCore.Mvc;

namespace CSVfile.Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EmpRecordController : ControllerBase
    {
        private readonly IEmpRecords _empRecords;
        private readonly IEmpReadAsString _empReadAsString;
        public EmpRecordController(IEmpRecords empRecords, IEmpReadAsString empReadAsString)
        {
               this._empRecords= empRecords;
            this._empReadAsString= empReadAsString;
        }
        [HttpGet]
        public  IActionResult  show()
        {
          List<string> Record=  _empRecords.GetRecords();
            return Ok(Record);

        }

        [HttpPost]
        public IActionResult UploadData(IFormFile file)
        {
           // var Addlist=_empRecords.UploadData(file);
            //return Ok(Addlist);
            var uploadFile = _empReadAsString.UploadData(file);
            var TotalRecords = _empRecords.CountRecord();
             return Ok(TotalRecords);
           // return Ok(uploadFile);
        }
        [HttpGet("EmployeeList")]
        public async Task<IActionResult> getRecords()
        {
            var EmployeeList= _empReadAsString.GetRecords();
            return Ok(EmployeeList);
        }
        [HttpGet("FindbyId/{id}")]
        public async Task<IActionResult> FindbyId(string id)
        {
           var employe= _empReadAsString.FindbyId(id);
           return Ok(employe);
        }
        [HttpGet("ReadJson")]
        public IActionResult ReadJson()
        {
            _empReadAsString.ReadJson();
            return Ok("SAve");
        }

    }
}
