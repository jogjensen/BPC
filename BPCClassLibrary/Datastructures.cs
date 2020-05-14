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
            Open,
            Pending,
            Closed
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
