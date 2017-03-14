using ProjectPeople.API.Responses.IResponses;

namespace ProjectPeople.Responses
{
    public class SingleResponseModel<T> : ISingleResponseModel<T>
    {
        public string Message { get; set; }
        public bool DidError { get; set; }
        public string ErrorMessage { get; set; }
        public T Model { get; set; }
    }
}