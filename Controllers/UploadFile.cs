using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Net.Http.Headers;

namespace IrsMonkeyApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UploadFile : Controller
    {
        private  IHostingEnvironment _hostingEnvironment;

        public UploadFile(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        
        
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult UploadFileToServer()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_hostingEnvironment.WebRootPath))
                {
                    _hostingEnvironment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "./uploads");
                }
                var file = Request.Form.Files[0];
                var memberId = Request.Form["memberId"].ToString();
                var resolution = Request.Form["resolution"].ToString();
                var folderName = memberId;
                var webRootPath = _hostingEnvironment.WebRootPath;
                var newPath = Path.Combine(webRootPath, folderName);
                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                if (file.Length <= 0) return Json("Upload Successful.");
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.ToString()
                    .Trim('"');
                var filename2 = resolution + "-" + memberId + "-" + fileName;
                var fullPath = Path.Combine(newPath, filename2);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return Json("Upload Successful.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}