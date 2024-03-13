using AutoMapper;
using PassagensAereasAPI.DTOs;
using PassagensAereasAPI.Models;

namespace PassagensAereasAPI.Profiles
{
    public class PassagemAereaProfile : Profile
    {
        public PassagemAereaProfile()
        {
            CreateMap<PassagemAereaGol, PassagemAereaResponse>()
                .ForMember(response => response.Voo, gol => gol.MapFrom(x => x.FlightNumber))
                .ForMember(response => response.Companhia, gol => gol.MapFrom(x => x.Carrier))
                .ForMember(response => response.Origem, gol => gol.MapFrom(x => x.OriginAirport))
                .ForMember(response => response.Destino, gol => gol.MapFrom(x => x.DestinationAirport))
                .ForMember(response => response.Partida, gol => gol.MapFrom(x => x.DepartureDate))
                .ForMember(response => response.Chegada, gol => gol.MapFrom(x => x.ArrivalDate))
                .ForMember(response => response.Tarifa, gol => gol.MapFrom(x => x.FarePrice));

            CreateMap<PassagemAereaLatam, PassagemAereaResponse>()
                .ForMember(response => response.Voo, gol => gol.MapFrom(x => x.FlightID))
                .ForMember(response => response.Companhia, gol => gol.MapFrom(x => x.Airline))
                .ForMember(response => response.Origem, gol => gol.MapFrom(x => x.DepartureAirport))
                .ForMember(response => response.Destino, gol => gol.MapFrom(x => x.ArrivalAirport))
                .ForMember(response => response.Partida, gol => gol.MapFrom(x => x.FlightStart))
                .ForMember(response => response.Chegada, gol => gol.MapFrom(x => x.FlightEnd))
                .ForMember(response => response.Tarifa, gol => gol.MapFrom(x => x.TotalFare));;
        }
    }
}
