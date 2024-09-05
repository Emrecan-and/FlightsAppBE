using AutoMapper;
using FlightsAppBE.Model.Models;
using ServiceReference1;

namespace FlightsAppBE.Mapping
{
    public class FlightProfile :Profile
    {
        public FlightProfile()
        {
            CreateMap<OneWayFlightRequest, SearchRequest>();

            CreateMap<FlightOption, Flight>()
                .ForMember(dest => dest.DepartureDateTime, opt => opt.MapFrom(src => src.ArrivalDateTime))  //Servisteki hata sebebiyle ters map lendi
                .ForMember(dest => dest.ArrivalDateTime, opt => opt.MapFrom(src => src.DepartureDateTime));
        }
    }
}
