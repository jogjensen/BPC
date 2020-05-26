using System.Collections.Generic;
using BPCClassLibrary;
using System.Threading.Tasks;
using BPCMain.Utilities;

namespace BPCMain.ViewModel
{
	class DisplayMyBookingCar : BookingVM
	{
		private RelayCommand _backCommand;
		private RelayCommand _displayOmBpcCommand;
		private RelayCommand _displayFaqCommand;
		private RelayCommand _displayBookingCarCommand;

		private NavigationService _navigation;

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

		public RelayCommand DisplayBookingCarCommand
		{
			get { return _displayBookingCarCommand; }
		}

		public DisplayMyBookingCar()
		{
			_cancelJobCar = new RelayCommand(CancelBooking, null);
			_navigation = new NavigationService();
			_backCommand = new RelayCommand(GoBack, null);
			_displayOmBpcCommand = new RelayCommand(NavigateToOmBpc, null);
			_displayFaqCommand = new RelayCommand(NavigateToFaq, null);
			_displayBookingCarCommand = new RelayCommand(NavigateToBookingCar, null);
		}

		public async void CancelBooking()
		{
			CarBooking updatedCarBooking = new CarBooking();
			await GetAllCarBookingsTask();
			await GetCurrentCarTask();
			foreach (CarBooking cb in CarBookings)
			{
				if (cb.OrderNo == SelectedBooking.OrderNo && cb.CarId == CurrentCar.Id)
				{
					updatedCarBooking.CarId = 1;
					updatedCarBooking.OrderNo = cb.OrderNo;
					updatedCarBooking.CarBookingId = cb.CarBookingId;
					SelectedBooking.NumOfCarsNeeded++;
					SelectedBooking.Status = Datastructures.Status.Open;
					await UpdateCarBooking(updatedCarBooking);
					await UpdateBooking(SelectedBooking);
					await GetAllBookingAsync();
					break;
				}
			}
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

<<<<<<< HEAD

=======
>>>>>>> 23b419041e552f6661821636eac413f9791be663
		protected override async Task<bool> GetAllBookingAsync()
		{
			Bookings.Clear();
			List<Booking> list = (List<Booking>)await restworker.GetAllObjectsAsync<Booking>(Datastructures.TableName.Booking);
			foreach (Booking b in list)
			{
				foreach (CarBooking cb in CarBookings)
				{
					if (cb.CarId == CurrentCar.Id && b.OrderNo == cb.OrderNo)
					{
						Bookings.Add(b);
					}
				}
			}
			return true;
		}

		protected override async void GetBookingsAsync()
		{
			await GetCurrentCarTask();
			await GetAllCarBookingsTask();
			_ = await GetAllBookingAsync();
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

		public void NavigateToBookingCar()
		{
			_navigation.Navigate(typeof(BPCMain.View.DisplayBookingCar));
		}
		#endregion
	}
}
