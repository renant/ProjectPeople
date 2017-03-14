using System;
using System.Collections.Generic;

namespace ProjectPeople.API.Responses.IResponses
{
    public interface IListResponseModel<T> : IResponse
    {
        IEnumerable<T> Model { get; set; }
    }
}