using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPCClassLibrary;
using BPCMain.Persistency;
using BPCMain.Utilities;

namespace BPCMain.ViewModel
{
	class Booking : BaseVM
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
		//RelayCommands
		private RelayCommand _createBookingCompany;
		private RelayCommand _RequestJobCar;

		private NavigationService navigation = new NavigationService();
		private RestWorker restworker = new RestWorker();
		#endregion

		#region Properties

		public int OrderNo
		{
			get { return _orderNo; }
			set { _orderNo = value; }
		}

		public Datastructures.Status Status
		{
			get { return _status; }
			set { _status = value; }
		}

		public string CompanyName
		{
			get { return _companyName; }
			set { _companyName = value; }
		}

		public int NumOfCarsNeeded
		{
			get { return _numOfCarsNeeded; }
			set { _numOfCarsNeeded = value; }
		}

		public string Comment
		{
			get { return _comment; }
			set { _comment = value; }
		}

		public string TypeOfGoods
		{
			get { return _typeOfGoods; }
			set { _typeOfGoods = value; }
		}

		public double TotalWidth
		{
			get { return _totalWidth; }
			set { _totalWidth = value; }
		}

		public double TotalLength
		{
			get { return _totalLength; }
			set { _totalLength = value; }
		}

		public double TotalHeight
		{
			get { return _totalHeight; }
			set { _totalHeight = value; }
		}

		public double TotalWeight
		{
			get { return _totalWeight; }
			set { _totalWeight = value; }
		}

		public DateTime StartDate
		{
			get { return _startDate; }
			set { _startDate = value; }
		}

		public string StartAddress
		{
			get { return _startAddress; }
			set { _startAddress = value; }
		}

		public string StartPostalCode
		{
			get { return _startPostalCode; }
			set { _startPostalCode = value; }
		}

		public string StartCountry
		{
			get { return _startCountry; }
			set { _startCountry = value; }
		}

		public DateTime EndDate
		{
			get { return _endDate; }
			set { _endDate = value; }
		}

		public string EndAddress
		{
			get { return _endAddress; }
			set { _endAddress = value; }
		}

		public string EndPostalCode
		{
			get { return _endPostalCode; }
			set { _endPostalCode = value; }
		}

		public string EndCountry
		{
			get { return _endCountry; }
			set { _endCountry = value; }
		}

		public int Truckdriver
		{
			get { return _truckdriver; }
			set { _truckdriver = value; }
		}

		public string Contactperson
		{
			get { return _contactperson; }
			set { _contactperson = value; }
		}
		#endregion

		#region Properties RelayCommands 

		public RelayCommand CreateBookingCompany
		{
			get { return _createBookingCompany; }
		}

		public RelayCommand RequestJobCar
		{
			get { return _RequestJobCar; }
		}

		#endregion

		#region Constructor

		public Booking()
		{
			_createBookingCompany = new RelayCommand(NewBooking, null);
			_RequestJobCar = new RelayCommand(NewJob, null);
		}

		#endregion

		#region DisplayBookingCompany Methods

		public async void NewBooking()
		{
			Booking newBooking = new Booking(CompanyName, ); //skal udfyldes
			if (ConstraintMethods.CreateBookingCheck(newBooking)) //metode i ConstraintMethods
			{
				//save new Car in database
				await CreateNewBooking(newBooking);
				CarBooking newCarBooking = new CarBooking(OrderNo, Car); //evt. flere
				navigation.Navigate(typeof(BPCMain.View.DisplayBookingCompany)); //evt. popup succesfull Booking
			}
			else
			{
				string errorMessage = "Fejl i oplysninger"; //evt. bruge header til fejlmeddelelser
			}
		}

		#endregion

		#region DisplayBookingCompany RelayCommands

		public async Task<bool> CreateNewBooking<T>(T newBooking)
		{
			var Task = await restworker.CreateObjectAsync(newBooking, Datastructures.TableName.Booking);
			var result = Task;
			return result;
		}

		#endregion

		#region DisplayBookingCar Methods

		public async void NewJob()
		{
			
		}

		#endregion

		#region DisplayBookingCar RelayCommands



		#endregion

		#region DisplayBookingAdmin Methods


		#endregion

		#region DisplayBookingAdmin RelayCommands



		#endregion


	}
}
