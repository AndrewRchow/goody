using Goody.Web.Models.Requests;

namespace Goody.Web.Models.Responses
{
    public class EditorContentResponse : EditorContentInsertRequest
    {
        public int Id { get; set; }
    }
}