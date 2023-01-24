using RestSharp;

namespace CSV.MvcProject.Repository
{
    public class EmpRepository : IEmpRepository
    {
        HttpClient httpclient = new HttpClient();
        public EmpRepository()
        {

        }

      

        public void uploadfile(IFormFile file)
        {
            try
            {
            
                var client = new RestClient("https://localhost:7026/api/EmpRecord");
                var fileextension = Path.GetExtension(file.FileName);
                var filename = Guid.NewGuid().ToString() + fileextension;
                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filename);
                using (FileStream fs = File.Create(filepath))
                {
                    file.CopyTo(fs);
                }
                var request = new RestRequest(Method.POST);
                // request.AddFile("file", @"E:\csv\test.csv");
                request.AddFile("file", filepath);
                IRestResponse response = client.Execute(request);
                

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
