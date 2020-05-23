using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using BPCClassLibrary;
using BPCMain.Persistency;
using BPCMain.Utilities;

namespace BPCMain.ViewModel
{
	class BookingVM : BaseVM
	{

		#region Instance field
		//General information
		private int _orderNo;
		private Datastructures.Status _status;
		private int _companyCvrNo;
		private int _numOfCarsNeeded;
		private string _comment;
		//Payload information
		private string _typeOfGoods;
		private double _totalWidth;
		private double _totalLength;
		private double _totalHeight;
		private double _totalWeight;
		//Departure information
		private CalendarDatePicker _sDate;
		private TimePicker _sTime;
		private DateTime _startDate;
		private string _startAddress;
		private string _startCity;
		private string _startPostalCode;
		private string _startCountry;
		//Destination information
		private DateTime _endDate;
		private string _endAddress;
		private string _endCity;
		private string _endPostalCode;
		private string _endCountry;
		//Truck
		private int _truckdriverId;
		private string _contactperson;
		//CarBooking
		private int _carBookingId;
		//RelayCommands
		private RelayCommand _createBookingCompany;
		private RelayCommand _requestJobCar;
		private RelayCommand _cancelJobCar;

		//new Truckdriver
		private int _truckDriverTelNo;
		private string _truckdriverEMail;

		private string _errorMessage;

        private Booking _selectedBooking;
        private ObservableCollection<Booking> _bookings;
        private ObservableCollection<CarBooking> _carBookings;
		private NavigationService navigation = new NavigationService();
		private RestWorker restworker = new RestWorker();
        private SharedUser _shared;
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

		public int CompanyCvrNo
		{
			get { return 1; } //Find den i customer
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
			set
			{
				DateTime dt = new DateTime();
				_startDate = value;
			}
		}

		public CalendarDatePicker SDate
		{
			get { return _sDate; }
			set { _sDate = value; }
		}

		public TimePicker STime
		{
			get { return _sTime; }
			set { _sTime = value; }
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

		public string StartCity
		{
			get { return _startCity; }
			set { _startCity = value; }
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

		public string EndCity
		{
			get { return _endCity; }
			set { _endCity = value; }
		}

		public string EndCountry
		{
			get { return _endCountry; }
			set { _endCountry = value; }
		}

		public int TruckdriverId
		{
			get { return _truckdriverId; }
			set { _truckdriverId = value; }
		}

		public string Contactperson
		{
			get { return _contactperson; }
			set { _contactperson = value; }
		}

		public int CarBookingId
		{
			get { return _carBookingId; }
			set { _carBookingId = value; }
		}

		public int TruckDriverTelNo
		{
			get { return _truckDriverTelNo; }
			set { _truckDriverTelNo = value; }
		}

		public string TruckdriverEMail
		{
			get { return _truckdriverEMail; }
			set { _truckdriverEMail = value; }
		}

		public string ErrorMessage
		{
			get { return _errorMessage; }
			set { _errorMessage = value; }
		}

        public Booking SelectedBooking
        {
            get { return _selectedBooking;}
            set
            {
                _selectedBooking = value;
				OnPropertyChanged();
            }

        }

        public ObservableCollection<Booking> Bookings
        {
            get { return _bookings; }
            set { _bookings = value; }
        }

        public ObservableCollection<CarBooking> CarBookings
        {
	        get { return _carBookings; }
        }

        public SharedUser Shared
        {
            get { return _shared; }
        }

		#endregion

		#region Properties RelayCommands 

		public RelayCommand CreateBookingCompany
		{
			get { return _createBookingCompany; }
		}

		public RelayCommand RequestJobCar
		{
			get { return _requestJobCar; }
		}

		public RelayCommand CancelJobCar
		{
			get { return _cancelJobCar; }
			set { _cancelJobCar = value; }
		}

		#endregion

		#region Constructor

		public BookingVM()
		{
			_shared = SharedUser.Instance;
			_bookings = new ObservableCollection<Booking>();
			_carBookings = new ObservableCollection<CarBooking>();
            _createBookingCompany = new RelayCommand(NewBooking, null);
			_requestJobCar = new RelayCommand(RequestJob, null);
			_cancelJobCar = new RelayCommand(CancelJob, null);
		}

		#endregion

		#region DisplayBookingCompany Methods

        public async void AddBookingToList()
        {
			IList<Booking> bookingList = new List<Booking>();
            bookingList = await GetAllBookings();
            foreach (Booking booking in bookingList)
            {
                if (SharedUser.Instance.UserUser == booking.CompanyCvrNo)
                {
                    Bookings.Add(booking);
                }
            }

          
        }

        public async Task<IList<Booking>> GetAllBookings()
        {
            var Task = await restworker.GetAllObjectsAsync<Booking>(Datastructures.TableName.Booking);
            var result = Task;

            return result;
        }

		public async void NewBooking()
		{
			Status = Datastructures.Status.Open;
			
			Booking newBooking = new Booking(Status, CompanyCvrNo, NumOfCarsNeeded, TypeOfGoods, TotalWidth, TotalLength, TotalHeight, TotalWeight, StartDate, StartAddress, StartPostalCode, StartCity, StartCountry, EndDate, EndAddress, EndPostalCode, EndCity, EndCountry, TruckdriverId, Contactperson, Comment);
			
			Truckdriver truckdriver = new Truckdriver(CompanyCvrNo, TruckDriverTelNo, TruckdriverEMail);

			if (ConstraintMethods.CreateBookingCheck(newBooking)) //metode i ConstraintMethods
			{
				//save new Car in database
				await CreateNewBooking(newBooking);
				//save new Truckdriver in database
				await CreateTruckdriver(truckdriver);
				//evt. popup successful Booking
				navigation.Navigate(typeof(BPCMain.View.DisplayBookingCompany));
			}
			else
			{
				string ErrorMessage = "Fejl i oplysninger"; //evt. bruge header til fejlmeddelelser
			}
		}

		public async Task<bool> CreateTruckdriver<T>(T truckdriver)
		{
			var Task = await restworker.CreateObjectAsync<T>(truckdriver, Datastructures.TableName.Truckdriver);
			var result = Task;
			return result;
		}

		public async void newCarBooking()
		{
			for (int i = 0; i < NumOfCarsNeeded; i++)
			{
				CarBooking newCarBooking = new CarBooking(OrderNo);
				
				await CreateNewCarBooking(newCarBooking);
			}
		}

		public async Task<bool> CreateNewCarBooking(CarBooking newCarBooking)
		{
			var Task = await restworker.CreateObjectAsync<CarBooking>(newCarBooking, Datastructures.TableName.CarBooking);
			return Task;
		}

		#endregion

		#region DisplayBookingCompany RelayCommands

		public async Task<bool> CreateNewBooking(Booking newBooking)
		{
			var Task = await restworker.CreateObjectAsync<Booking>(newBooking, Datastructures.TableName.Booking);
			var result = Task;
			return result;
		}

		#endregion
		
		#region DisplayBookingCar Methods

		public async void RequestJob()
		{
			SelectedBooking.Status = Datastructures.Status.Pending;
			await UpdateBooking(SelectedBooking);
		}

		public async void CancelJob()
		{
			SelectedBooking.Status = Datastructures.Status.Open;
			await UpdateBooking(SelectedBooking);

			//if ((Int32) SelectedBooking.Status == (Int32) Datastructures.Status.Pending)
			//{
			//	SelectedBooking.Status = Datastructures.Status.Open;
			//}

		}

		public async Task<bool> UpdateBooking(Booking updatedBooking)
		{
			var Task = await restworker.UpdateObjectAsync<Booking>(updatedBooking, updatedBooking.OrderNo,
				Datastructures.TableName.Booking);
			var result = Task;
			return result;
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
