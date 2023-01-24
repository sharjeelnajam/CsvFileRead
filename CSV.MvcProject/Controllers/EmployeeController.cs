using CSV.MvcProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CSV.MvcProject.Controllers
{
    public class EmployeeController : Controller
        
    {
        private readonly IEmpRepository _empRepository;
        public EmployeeController(IEmpRepository empRepository)
        {
            this._empRepository = empRepository;
        }

        [HttpGet]
        public IActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            _empRepository.uploadfile(file);
            return Ok();
        }
    }
}
