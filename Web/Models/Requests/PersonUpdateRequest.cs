using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goody.Web.Models.Requests
{
    public class PersonUpdateRequest : PersonAddRequest
    {
        public int Id { get; set; }
    }
}