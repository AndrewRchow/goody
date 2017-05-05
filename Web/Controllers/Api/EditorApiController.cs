using Goody.Web.Models;
using Goody.Web.Models.Requests;
using Goody.Web.Models.Responses;
using Goody.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Goody.Web.Controllers.Api
{
    [RoutePrefix("api/editor")]
    public class EditorApiController : ApiController
    {
        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id = 0) {
            EditorService service = new EditorService();
            service.EditorContent_DeleteById(id);
            return Request.CreateResponse(HttpStatusCode.OK, new SuccessResponse());
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetById(int id = 0)
        {
            ItemResponse<EditorContentResponse> resp = new ItemResponse<EditorContentResponse>();
            EditorService service = new EditorService();
            resp.Item = service.EditorContent_SelectById(id);
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }

        [HttpGet]
        [Route]
        public HttpResponseMessage Get()
        {
            ItemsResponse<EditorContentResponse> resp = new ItemsResponse<EditorContentResponse>();
            EditorService service = new EditorService();
            resp.Items = service.EditorContent_GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }

        [HttpPost]
        [Route]
        public HttpResponseMessage Insert(EditorContentInsertRequest req)
        {
            ItemResponse<int> resp = new ItemResponse<int>();
            EditorService service = new EditorService();
            resp.Item = service.EditorContent_Insert(req);
            return Request.CreateResponse(HttpStatusCode.OK, resp);
        }

        [HttpPut]
        [Route]
        public HttpResponseMessage Update([FromBody] EditorContentUpdateRequest req) {
            EditorService service = new EditorService();
            service.EditorContent_Update(req);
            return Request.CreateResponse(HttpStatusCode.OK, new SuccessResponse());
        }
    }
}
