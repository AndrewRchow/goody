using Goody.Web.Models.Domain;
using Goody.Web.Models.Requests;
using Goody.Web.Models.Responses;
using Goody.Web.Services;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Goody.Web.Controllers.Api
{
    [RoutePrefix("api/file")]
    public class FileApiController : ApiController
    {
        FileService fileService = new FileService();
        string serverFileName = string.Empty;

        [HttpPost]
        [Route("upload")]
        public async Task<HttpResponseMessage> UploadAsync()
        {
            try
            {
                ItemResponse<int> response = new ItemResponse<int>();
                HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];
                FileUploadAddRequest model = new FileUploadAddRequest
                {
                    FileName = postedFile.FileName,
                    Size = postedFile.ContentLength,
                    Type = postedFile.ContentType,
                    ModifiedBy = HttpContext.Current.User.Identity.IsAuthenticated ? HttpContext.Current.User.Identity.Name : "anonymous"
                };
                string contentType = Request.Content.Headers.ContentType.MediaType;

                serverFileName = string.Format("{0}_{1}{2}",
                    Path.GetFileNameWithoutExtension(postedFile.FileName),
                    Guid.NewGuid().ToString(),
                    Path.GetExtension(postedFile.FileName));

                model.ServerFileName = serverFileName;

                await SavePostedFile(postedFile);
                response.Item = await fileService.Insert(model);

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("getall")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                ItemsResponse<UploadedFile> response = new ItemsResponse<UploadedFile>();
                response.Items = fileService.SelectAll();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        private async Task SavePostedFile(HttpPostedFile postedFile)
        {
            MemoryStream ms = null;
            string rootPath = string.Empty;
            string serverPath = string.Empty;
            string fqn = string.Empty;

            serverPath = System.Configuration.ConfigurationManager.AppSettings["fileFolder"];
            rootPath = HttpContext.Current.Server.MapPath(serverPath);
            fqn = System.IO.Path.Combine(rootPath, serverFileName);

            using (FileStream fs = new FileStream(fqn, FileMode.Append, FileAccess.Write, FileShare.None, bufferSize: postedFile.ContentLength, useAsync: true))
            {
                ms = new MemoryStream();
                postedFile.InputStream.CopyTo(ms);
                await fs.WriteAsync(ms.ToArray(), 0, postedFile.ContentLength);
            }
        }
    }
}
