using System.ComponentModel.DataAnnotations;

namespace AdiantamentoRecebiveis.API.Responses
{
    public static class GlobalResponse
    {
        public static IResult CreateResponse(object? response, int statusCode)
        {
            if (response is null)
                Results.BadRequest("Não foi possivel obter o response.");
            return Results.Json(response, statusCode: statusCode);
        }

        public static IResult Create200Response(object? response)
            => CreateResponse(response, StatusCodes.Status200OK);

        public static IResult Create201Response(object? response)
            => CreateResponse(response, StatusCodes.Status201Created);
    }
}
