using System;
using System.Collections.Generic;
using System.Text;

namespace BPCClassLibrary
{
    public static class Datastructures
    {
        //Used for booking status
        public enum Status
        {
            PendingAccept = 0,
            Open = 1,
            PendingCars = 2,
            Closed = 3
        };

        public enum TableName
        {
            Booking,
            Car,
            CarBooking,
            Customer,
            Truckdriver
        };

        //eventuel struct til eventuelt brug
        public struct Dimensions
        {
            double width;
            double length;
            double height;

            public double Volume()
            {
                return width * length * height;
            }
        }

        //enum eller list over mulige lande? PostalCode?
    }
}
