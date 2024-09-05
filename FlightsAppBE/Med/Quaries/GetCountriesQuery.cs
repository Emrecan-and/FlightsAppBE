using FlightsAppBE.Model.Models;
using MediatR;

namespace FlightsAppBE.Med.Quaries
{
    public class GetCountriesQuery : IRequest<ApiResponse<List<string>>>
    {
    }
}
