using Goody.Web.Models.Domain;
using Goody.Web.Models.Requests;
using Goody.Web.Models.Responses;
using Goody.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Goody.Web.Controllers.Api
{
    [RoutePrefix("api/person")]
    public class PersonApiController : ApiController
    {
        PersonService personService = new PersonService();

        [HttpPost]
        [Route]
        public HttpResponseMessage Post(PersonAddRequest model)
        {
            ItemResponse<int> response = new ItemResponse<int>();

            if (HttpContext.Current.User.Identity.IsAuthenticated)
                model.ModifiedBy = HttpContext.Current.User.Identity.Name;
            else
                model.ModifiedBy = "Anonymous";

            response.Item = personService.Insert(model);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route("{id:int}")]
        public HttpResponseMessage GetById(int id)
        {
            ItemResponse<Person> response = new ItemResponse<Person>();
            response.Item = personService.SelectById(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpGet]
        [Route]
        public HttpResponseMessage GetAll()
        {
            ItemsResponse<Person> response = new ItemsResponse<Person>();
            response.Items = personService.SelectAll();
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpPut]
        [Route]
        public HttpResponseMessage Put(Person model)
        {
            SuccessResponse response = new SuccessResponse();

            if (HttpContext.Current.User.Identity.IsAuthenticated)
                model.ModifiedBy = HttpContext.Current.User.Identity.Name;
            else
                model.ModifiedBy = "Anonymous";

            personService.Update(model);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public HttpResponseMessage Delete(int id)
        {
            SuccessResponse response = new SuccessResponse();
            personService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}