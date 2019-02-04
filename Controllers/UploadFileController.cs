using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using IrsMonkeyApi.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Net.Http.Headers;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace IrsMonkeyApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UploadFileController : Controller
    {
        private readonly IUploadFileDb _uploadFileDb;
        private readonly IConfiguration _configuration;

        public UploadFileController(IUploadFileDb uploadFileDb, IConfiguration configuration)
        {
            _uploadFileDb = uploadFileDb;
            _configuration = configuration;
        }


        [HttpPost, DisableRequestSizeLimit]
        public IActionResult UploadFileToServer()
        {
            try
            {
                var ms = new MemoryStream();
                var pdfStorageConnection = CloudStorageAccount.Parse(_configuration["ApplicationSettings:pdfStorage"]);
                var blobStorageClient = pdfStorageConnection.CreateCloudBlobClient();
                var blobContainer = blobStorageClient.GetContainerReference("pdffiles");

                var file = Request.Form.Files[0];
                var memberId = Request.Form["memberId"].ToString();
                var resolution = Request.Form["resolution"].ToString();
                var document = Request.Form["document"].ToString();

                if (file.Length <= 0) return Json("Upload UnSuccessful.");
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();

                var uploadFile = blobContainer.GetBlockBlobReference(memberId + "/" + resolution + "/" + document);
                uploadFile.UploadFromStreamAsync(ms);

                return Ok("Upload Successful.");
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetMemberFiles/{id}"), HttpGet]
        public IActionResult ListUserFiles(Guid id)
        {
            try
            {
                var listFiles = _uploadFileDb.ListFileByUser(id);
                return Ok(listFiles);
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}