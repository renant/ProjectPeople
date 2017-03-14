using System.Collections.Generic;
using ProjectPeople.API.Responses.IResponses;

namespace ProjectPeople.API.Responses
{
    public class ListResponseModel<T> : IListResponseModel<T>
    {
        public string Message { get; set; }
        public bool DidError { get; set; }
        public string ErrorMessage { get; set; }
        public IEnumerable<T> Model { get; set; }
    }
}