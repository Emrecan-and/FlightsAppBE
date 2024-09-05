using FlightsAppBE.Model.Models;
using FlightsAppBE.Repository.Models;
using MediatR;

namespace FlightsAppBE.Med.Quaries
{
    public class GetCitiesQuery : IRequest<ApiResponse<List<string>>>
    {
        public string Country { get; set; }
    }
    
}
