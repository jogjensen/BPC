using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BPCClassLibrary
{
    public class Booking
    {
        #region Instance field
        //General information
        private int _orderNo;
        private Datastructures.Status _status;
        private int _companyCvrNo;
        private int _numOfCarsNeeded;
        private string _comment;
        //Departure information
        private DateTime _startDate;
        private string _startAddress;
        private string _startPostalCode;
        private string _startCity;
        private string _startCountry;
        //Payload information
        private string _typeOfGoods;
        private double _totalWidth;
        private double _totalLength;
        private double _totalHeight;
        private double _totalWeight;
        //Destination information
        private DateTime _endDate;
        private string _endAddress;
        private string _endPostalCode;
        private string _endCity;
        private string _endCountry;
        //Truck
        private int _truckDriverId;
        private string _contactPerson;
        #endregion

        #region Constructors
        public Booking()
        { }

        public Booking(Datastructures.Status status, int companyCvrNo, int numOfCarsNeeded, string typeOfGoods, double totalWidth, double totalLength, double totalHeight, double totalWeight, DateTime startDate, string startAddress, string startPostalCode, string startCity, string startCountry, DateTime endDate, string endAddress, string endPostalCode, string endCity, string endCountry, int truckDriverId, string contactPerson, string comment)
        {
            _status = status;
            _companyCvrNo = companyCvrNo;
            _numOfCarsNeeded = numOfCarsNeeded;
            _typeOfGoods = typeOfGoods;
            _totalWidth = totalWidth;
            _totalLength = totalLength;
            _totalHeight = totalHeight;
            _totalWeight = totalWeight;
            _startDate = startDate;
            _startAddress = startAddress;
            _startPostalCode = startPostalCode;
            _startCity = startCity;
            _startCountry = startCountry;
            _endDate = endDate;
            _endAddress = endAddress;
            _endPostalCode = endPostalCode;
            _endCity = endCity;
            _endCountry = endCountry;
            _truckDriverId = truckDriverId;
            _contactPerson = contactPerson;
            _comment = comment;
            if (comment == null) _comment = "N/A";

        }
        #endregion

        #region Properties
        public int OrderNo
        {
            get => _orderNo;
            set => _orderNo = value;
        }

        public Datastructures.Status Status
        {
            get => _status;
            set => _status = value;
        }

        public int CompanyCvrNo
        {
            get => _companyCvrNo;
            set => _companyCvrNo = value;
        }


        public int NumOfCarsNeeded
        {
            get => _numOfCarsNeeded;
            set => _numOfCarsNeeded = value;
        }

        public string Comment
        {
            get => _comment;
            set => _comment = value;
        }

        public string TypeOfGoods
        {
            get => _typeOfGoods;
            set => _typeOfGoods = value;
        }

        public double TotalWidth
        {
            get => _totalWidth;
            set => _totalWidth = value;
        }

        public double TotalLength
        {
            get => _totalLength;
            set => _totalLength = value;
        }

        public double TotalHeight
        {
            get => _totalHeight;
            set => _totalHeight = value;
        }

        public double TotalWeight
        {
            get => _totalWeight;
            set => _totalWeight = value;
        }

        public DateTime StartDate
        {
	        get => _startDate;
            set => _startDate = value;
        }

        public string StartAddress
        {
            get => _startAddress;
            set => _startAddress = value;
        }

        public string StartPostalCode
        {
            get => _startPostalCode;
            set => _startPostalCode = value;
        }

        public string StartCity
        {
            get => _startCity;
            set => _startCity = value;
        }

        public string StartCountry
        {
            get => _startCountry;
            set => _startCountry = value;
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => _endDate = value;
        }

        public string EndAddress
        {
            get => _endAddress;
            set => _endAddress = value;
        }

        public string EndPostalCode
        {
            get => _endPostalCode;
            set => _endPostalCode = value;
        }

        public string EndCity
        {
            get => _endCity;
            set => _endCity = value;
        }

        public string EndCountry
        {
            get => _endCountry;
            set => _endCountry = value;
        }

        public int TruckDriverId
        {
            get => _truckDriverId;
            set => _truckDriverId = value;
        }

        public string ContactPerson
        {
            get => _contactPerson;
            set => _contactPerson = value;
        }
        #endregion
    }
}
