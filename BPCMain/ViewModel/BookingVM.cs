using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.AllJoyn;
using Windows.UI.Xaml.Controls;
using BPCClassLibrary;
using BPCMain.Persistency;
using BPCMain.Utilities;
using System.Reflection.Metadata.Ecma335;

namespace BPCMain.ViewModel
{
	class BookingVM : BaseVM
	{

		#region Instance field
		//General information
		protected int _orderNo;
		protected Datastructures.Status _status;
		protected int _companyCvrNo;
		protected int _numOfCarsNeeded;
		protected string _comment;
		//Payload information
		protected string _typeOfGoods;
		protected double _totalWidth;
		protected double _totalLength;
		protected double _totalHeight;
		protected double _totalWeight;
		//Departure information
		protected DateTime _startDate;
		protected string _startAddress;
		protected string _startCity;
		protected string _startPostalCode;
		protected string _startCountry;
		//Destination information
		protected DateTime _endDate;
		protected string _endAddress;
		protected string _endCity;
		protected string _endPostalCode;
		protected string _endCountry;
		//Truck
		protected int _truckdriverId;
		protected string _contactperson;
		//CarBooking
		protected int _carBookingId;
		protected int _carId;

		//Car
		protected Car _currentCar;

		//RelayCommands
		protected RelayCommand _acceptBookingAdmin;
		protected RelayCommand _requestJobCar;
		protected RelayCommand _cancelJobCar;
        private RelayCommand _backCommand;
        private RelayCommand _displayOmBpcCommand;
        private RelayCommand _displayFaqCommand;
        private RelayCommand _displayCreateBookingCompCommand;

		//new Truckdriver
		protected int _truckDriverTelNo;
		protected string _truckdriverEMail;

		protected string _errorMessage;

		protected Booking _selectedBooking;
		protected Booking _selectedAdminBooking;
		protected ObservableCollection<Booking> _bookings;
		protected ObservableCollection<Booking> _myCarBookings;

		protected ObservableCollection<CarBooking> _carBookings;
		protected ObservableCollection<Car> _cars;
		protected NavigationService navigation = new NavigationService();
		protected RestWorker restworker = new RestWorker();
		protected SharedUser _shared;
		#endregion

		//Enum Status Workaround
		protected string[] _statusArray;
		protected string _statusString;


		#region Properties

		public int OrderNo
		{
			get { return _orderNo; }
			set { _orderNo = value; }
		}

		public Datastructures.Status Status
		{
			get { return _status; }
			set { 
				_status = value;
				OnPropertyChanged();
				}
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
			get { return _selectedBooking; }
			set
			{
				_selectedBooking = value;
				OnPropertyChanged();
			}
		}

		public Car CurrentCar
		{
			get { return _currentCar; }
			set { _currentCar = value; }
		}

		public ObservableCollection<Booking> Bookings
		{
			get { return _bookings; }
			set
			{
				_bookings = value;
				OnPropertyChanged();
			}
		}

		public ObservableCollection<Booking> MyCarBookings
		{
			get { return _myCarBookings; }
			set { _myCarBookings = value; }
		}

		public ObservableCollection<CarBooking> CarBookings
		{
			get { return _carBookings; }
			set
			{
				_carBookings = value;
				OnPropertyChanged();
			}
		}

		public ObservableCollection<Car> Cars
		{
			get { return _cars; }
			set { _cars = value; }
		}

		public SharedUser Shared
		{
			get { return _shared; }
		}

		public string StatusString
		{
			get => _statusString;
			set
			{
				_statusString = value;
				OnPropertyChanged();
			}
		}

		public string[] StatusArray
		{
			get => _statusArray;

		}
		#endregion

		#region Properties RelayCommands 

		public RelayCommand BackCommand
        {
            get { return _backCommand; }
        }

        public RelayCommand DisplayOmBpcCommand
        {
            get { return _displayOmBpcCommand; }
        }

        public RelayCommand DisplayFaqCommand
        {
            get { return _displayFaqCommand; }
        }

        public RelayCommand DisplayCreateBookingCompCommand
        {
            get { return _displayCreateBookingCompCommand; }
        }

		public RelayCommand RequestJobCar
		{
			get { return _requestJobCar; }
		}

		public RelayCommand CancelJobCar
		{
			get { return _cancelJobCar; }
		}

		public RelayCommand AcceptBookingAdmin
		{
			get { return _acceptBookingAdmin; }
		}
		#endregion

		#region Constructor

		public BookingVM()
		{
			navigation = new NavigationService();
			_backCommand = new RelayCommand(GoBack, null);
			_displayFaqCommand = new RelayCommand(NavigateToFaq, null);
			_displayOmBpcCommand = new RelayCommand(NavigateToOmBpc, null);
			_displayCreateBookingCompCommand = new RelayCommand(NavigateToCreateBookingCompany, null);
			_statusString = "PendingAccept";
			_statusArray = new string[]{ "PendingAccept","Open","PendingClosing","Closed"};
			_shared = SharedUser.Instance;
			_bookings = new ObservableCollection<Booking>();
			_carBookings = new ObservableCollection<CarBooking>();
			_myCarBookings = new ObservableCollection<Booking>();
			
			GetBookingsAsync();
		}

		#endregion

		#region DisplayBookingCompany Methods

		protected virtual async Task<bool> GetAllBookingAsync()
		{
			List<Booking> list = (List<Booking>)await restworker.GetAllObjectsAsync<Booking>(Datastructures.TableName.Booking);
			Bookings = new ObservableCollection<Booking>(list);
			return true;
		}

		protected virtual async void GetBookingsAsync()
		{
			_ = await GetAllBookingAsync();
		}
		#endregion

		#region DisplayBookingCar Methods

		public async Task<bool> UpdateBookingTask(Booking updatedBooking)
		{
			var Task = await restworker.UpdateObjectAsync<Booking>(updatedBooking, updatedBooking.OrderNo,
				Datastructures.TableName.Booking);
			var result = Task;
			return result;
		}

		protected async Task<bool> GetAllCarsTask()
		{
			List<Car> list = (List<Car>)await restworker.GetAllObjectsAsync<Car>(Datastructures.TableName.Car);
			Cars = new ObservableCollection<Car>(list);
			return true;
		}
		protected async Task<bool> GetCurrentCarTask()
		{
			List<Car> list = (List<Car>)await restworker.GetAllObjectsAsync<Car>(Datastructures.TableName.Car);
			Cars = new ObservableCollection<Car>(list);
			foreach (Car c in list)
			{
				if (c.CvrNo.Equals(Shared.UserUser))
				{
					CurrentCar = c;
				}
			}
			return true;
		}

		protected virtual async Task<bool> GetAllCarBookingsTask()
		{
			CarBookings.Clear();
			List<CarBooking> list = (List<CarBooking>)await restworker.GetAllObjectsAsync<CarBooking>(Datastructures.TableName.CarBooking);
			foreach (CarBooking cb in list)
			{
					CarBookings.Add(cb);
			}
			return true;
		}

		#endregion


        #region Navigation Methods

        public void GoBack()
        {
			navigation.GoBack();
        }

        public void NavigateToOmBpc()
        {
			navigation.Navigate(typeof(BPCMain.View.AboutUs));
        }

        public void NavigateToFaq()
        {
			navigation.Navigate(typeof(BPCMain.View.Faq));
        }

        public void NavigateToCreateBookingCompany()
        {
			navigation.Navigate(typeof(BPCMain.View.CreateBookingCompany));
        }
        #endregion
	}
}
