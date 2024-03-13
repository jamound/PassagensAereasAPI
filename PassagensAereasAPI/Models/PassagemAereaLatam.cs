﻿namespace PassagensAereasAPI.Models
{
    public class PassagemAereaLatam
    {
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string Airline { get; set; }
        public string FlightID { get; set; }
        public DateTime FlightStart { get; set; }
        public DateTime FlightEnd { get; set; }
        public decimal TotalFare { get; set; }
    }
}
