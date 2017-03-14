namespace ProjectPeople.API.Responses.IResponses
{
    public interface ISingleResponseModel<T> : IResponse
    {
        T Model { get; set; }
    }
}