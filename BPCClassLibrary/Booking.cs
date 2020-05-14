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
        private string _companyName;
        private int _numOfCarsNeeded;
        private string _comment;
        //Payload information
        private string _typeOfGoods;
        private double _totalWidth;
        private double _totalLength;
        private double _totalHeight;
        private double _totalWeight;
        //Departure information
        private DateTime _startDate;
        private string _startAddress;
        private string _startPostalCode;
        private string _startCountry;
        //Destination information
        private DateTime _endDate;
        private string _endAddress;
        private string _endPostalCode;
        private string _endCountry;
        //Truck
        private int _truckdriver;
        private string _contactperson;
      #endregion

      #region Constructors
      public Booking()
        { }
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

        public string CompanyName
        {
	        get => _companyName;
	        set => _companyName = value;
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

        public string EndCountry
        {
            get => _endCountry;
            set => _endCountry = value;
        }

        public int Truckdriver
        {
	        get => _truckdriver;
	        set => _truckdriver = value;
        }

        public string ContactPerson
        {
	        get => _contactperson;
	        set => _contactperson = value;
      }
      #endregion
   }
}
