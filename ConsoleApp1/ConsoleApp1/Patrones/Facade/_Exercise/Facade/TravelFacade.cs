using ConsoleApp1.Patrones.Facade._Exercise.Subsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Patrones.Facade._Exercise.Facade
{
    public class TravelFacade
    {
        private FlightBooking flightBooking;
        private HotelBooking hotelBooking;
        private CarRental carRental;

        public TravelFacade(FlightBooking flightBooking, HotelBooking hotelBooking, CarRental carRental)
        {
            this.flightBooking = flightBooking;
            this.hotelBooking = hotelBooking;
            this.carRental = carRental;
        }

        public void ArrangeTrip()
        {
            flightBooking.BookFlight();
            hotelBooking.BookHotel();
            carRental.RentCar();
        }
    }
}
