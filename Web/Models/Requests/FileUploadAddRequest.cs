using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goody.Web.Models.Requests
{
    public class FileUploadAddRequest
    {
        public string Username { get; set; }
        public string ServerFileName { get; set; }
        public string ModifiedBy { get; set; }
        public HttpPostedFile PostedFile { get; set; }
    }
}