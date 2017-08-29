using Goody.Web.Models.Requests;
using Goody.Web.Models.Responses;
using Goody.Web.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        [HttpPost]
        [Route("upload")]
        public async Task<HttpResponseMessage> UploadAsync()
        {
            ItemResponse<int> response = new ItemResponse<int>();

            FileUploadAddRequest model = new FileUploadAddRequest
            {
                ModifiedBy = HttpContext.Current.User.Identity.IsAuthenticated ? HttpContext.Current.User.Identity.Name : "anonymous",
                PostedFile = HttpContext.Current.Request.Files[0]
            };
            string contentType = Request.Content.Headers.ContentType.MediaType;

            model.ServerFileName = string.Format("{0}_{1}{2}",
                Path.GetFileNameWithoutExtension(model.PostedFile.FileName),
                Guid.NewGuid().ToString(),
                Path.GetExtension(model.PostedFile.FileName));

            await SavePostedFile(model);
            response.Item = await fileService.Insert(model);

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        private async Task SavePostedFile(FileUploadAddRequest file)
        {
            MemoryStream ms = null;
            string rootPath = string.Empty;
            string serverPath = string.Empty;
            string fqn = string.Empty;

            serverPath = System.Configuration.ConfigurationManager.AppSettings["fileFolder"];
            rootPath = HttpContext.Current.Server.MapPath(serverPath);
            fqn = System.IO.Path.Combine(rootPath, file.ServerFileName);

            using (FileStream fs = new FileStream(fqn, FileMode.Append, FileAccess.Write, FileShare.None, bufferSize: file.PostedFile.ContentLength, useAsync: true))
            {
                ms = new MemoryStream();
                file.PostedFile.InputStream.CopyTo(ms);
                await fs.WriteAsync(ms.ToArray(), 0, file.PostedFile.ContentLength);
            }
        }
    }
}
