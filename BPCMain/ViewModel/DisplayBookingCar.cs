using BPCClassLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPCMain.Utilities;

namespace BPCMain.ViewModel
{
	class DisplayBookingCar : BookingVM
	{
		#region Instance Fields

		private RelayCommand _acceptBookingCar;

		private RelayCommand _backCommand;
		private RelayCommand _displayOmBpcCommand;
		private RelayCommand _displayFaqCommand;
		private RelayCommand _displayMyBookingCarCommand;

		private NavigationService _navigation;

		private ObservableCollection<Car> cars1 = new ObservableCollection<Car>();
		private ObservableCollection<Booking> availableBookings = new ObservableCollection<Booking>();
		#endregion

		#region Properties

		public RelayCommand AcceptBookingCar
		{
			get { return _acceptBookingCar; }
		}

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

		public RelayCommand DisplayMyBookingCarCommand
		{
			get { return _displayMyBookingCarCommand; }
		}

		public ObservableCollection<Booking> AvailableBookings
		{
			get { return availableBookings; }
			set { availableBookings = value; }
		}

		public ObservableCollection<Car> CarsList
		{
			get => cars1;
			set
			{
				cars1 = value;
				OnPropertyChanged();
			}
		}
		#endregion

		#region Constructor

		public DisplayBookingCar()
		{
			_navigation = new NavigationService();
			_backCommand = new RelayCommand(GoBack, null);
			_displayOmBpcCommand = new RelayCommand(NavigateToOmBpc, null);
			_displayFaqCommand = new RelayCommand(NavigateToFaq, null);
			_displayMyBookingCarCommand = new RelayCommand(NavigateToMyBookingCar, null);
			_acceptBookingCar = new RelayCommand(AcceptBookCar, null);
		}
		#endregion

		#region Navigation Methods

		public void GoBack()
		{
			_navigation.GoBack();
		}

		public void NavigateToOmBpc()
		{
			_navigation.Navigate(typeof(BPCMain.View.AboutUs));
		}

		public void NavigateToFaq()
		{
			_navigation.Navigate(typeof(BPCMain.View.Faq));
		}

		public void NavigateToMyBookingCar()
		{
			_navigation.Navigate(typeof(BPCMain.View.DisplayMyBookingCar));
		}
		#endregion

		#region DisplayBookingCar Methods

		public async void AcceptBookCar()
		{
			CarBooking updatedCarBooking = new CarBooking();
			await GetAllCarBookingsTask();
			await GetCurrentCarTask();
			foreach (CarBooking cb in CarBookings)
			{
				if (cb.OrderNo == SelectedBooking.OrderNo && cb.CarId == 1)
				{
					updatedCarBooking.CarId = CurrentCar.Id;
					updatedCarBooking.OrderNo = cb.OrderNo;
					updatedCarBooking.CarBookingId = cb.CarBookingId;
					await UpdateCarBooking(updatedCarBooking);
					if ((--SelectedBooking.NumOfCarsNeeded) == 0)
					{
						SelectedBooking.Status = Datastructures.Status.PendingClosing;
						await UpdateBooking(SelectedBooking);
						await GetAllBookingAsync();
					}
					//navigation.Navigate(typeof(View.DisplayMyBookingCar));
					break;
				}
			}
		}

		protected override async Task<bool> GetAllBookingAsync()
		{
			Bookings.Clear();
			List<Booking> list = (List<Booking>)await restworker.GetAllObjectsAsync<Booking>(Datastructures.TableName.Booking);
			foreach (Booking b in list)
			{
				if (b.Status == Datastructures.Status.Open) Bookings.Add(b);
			}
			return true;
		}

		protected override async Task<bool> GetAllCarBookingsTask()
		{
			CarBookings.Clear();
			IList<CarBooking> list = await restworker.GetAllObjectsAsync<CarBooking>(Datastructures.TableName.CarBooking);
			foreach (CarBooking cb in list)
			{
				CarBookings.Add(cb);
			}
			return true;
		}


		public async Task<bool> UpdateCarBooking(CarBooking upDatedCarBooking)
		{
			var Task = await restworker.UpdateObjectAsync<CarBooking>(upDatedCarBooking, upDatedCarBooking.CarBookingId, Datastructures.TableName.CarBooking);
			return Task;
		}



		public async Task<bool> UpdateBooking(Booking updatedBooking)
		{
			var Task = await restworker.UpdateObjectAsync<Booking>(updatedBooking, updatedBooking.OrderNo,
				Datastructures.TableName.Booking);
			var result = Task;
			return result;
		}

		#endregion

	}
}
