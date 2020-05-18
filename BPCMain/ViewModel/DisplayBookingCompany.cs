using BPCClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPCMain.ViewModel
{
    class DisplayBookingCompany
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

      
        #region Properties
        public int OrderNo
        { get => _orderNo; }

        public Datastructures.Status Status
        { get => _status; }

        public string CompanyName
        { get => _companyName; }
        
        public int NumOfCarsNeeded
        { get => _numOfCarsNeeded; }

        public string Comment
        { get => _comment; }

        public string TypeOfGoods
        { get => _typeOfGoods; }

        public double TotalWidth
        { get => _totalWidth; }

        public double TotalLength
        { get => _totalLength; }

        public double TotalHeight
        { get => _totalHeight; }

        public double TotalWeight
        { get => _totalWeight; }

        public DateTime StartDate
        { get => _startDate; }

        public string StartAddress
        { get => _startAddress; }

        public string StartPostalCode
        { get => _startPostalCode; }

        public string StartCountry
        { get => _startCountry; }

        public DateTime EndDate
        { get => _endDate; }

        public string EndAddress
        { get => _endAddress; }

        public string EndPostalCode
        { get => _endPostalCode; }

        public string EndCountry
        { get => _endCountry; }

        public int Truckdriver
        { get => _truckdriver; }

        public string ContactPerson
        { get => _contactperson; }
        #endregion



        #region RelayCommands



        #endregion
    }
}
