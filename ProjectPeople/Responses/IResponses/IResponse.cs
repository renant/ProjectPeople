namespace ProjectPeople.API.Responses.IResponses
{
    public interface IResponse
    {
        string Message { get; set; }
        bool DidError { get; set; }
        string ErrorMessage { get; set; }
    }
}