using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using ProjectPeople.API.Responses.IResponses;

namespace ProjectPeople.API.Extensions
{
    public static class ResponseExtensions
    {
        public static IActionResult ToHttpResponse<TModel>(this IListResponseModel<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
                status = HttpStatusCode.InternalServerError;

            else if (response.Model == null)
                status = HttpStatusCode.NoContent;

            return new ObjectResult(response) { StatusCode = (int)status };
        }

        public static IActionResult ToHttpResponse<TModel>(this ISingleResponseModel<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
                status = HttpStatusCode.InternalServerError;

            else if (response.Model == null)
                status = HttpStatusCode.NotFound;

            return new ObjectResult(response) { StatusCode = (int)status };
        }
    }
}