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
		private RelayCommand _acceptBookingCar;
		protected RelayCommand _getallBookingsStart;

		private ObservableCollection<Car> cars1 = new ObservableCollection<Car>();
		private ObservableCollection<Booking> availableBookings = new ObservableCollection<Booking>();

		public RelayCommand AcceptBookingCar
		{
			get { return _acceptBookingCar; }
		}

		public RelayCommand GetallBookingsStart
		{
			get { return _getallBookingsStart; }
		}

		public ObservableCollection<Booking> AvailableBookings
		{
			get { return availableBookings; }
			set { availableBookings = value; }
		}

		public DisplayBookingCar()
		{
			_acceptBookingCar = new RelayCommand(AcceptBookCar, null);

			//_getallBookingsStart = new RelayCommand(GetAllBookingsAsync, null);
			//GetAvailableBookings();
			//GetAllBookingsAsync();
		}



		#region DisplayBookingCar Methods

		public async void AcceptBookCar()
		{
			CarBooking updatedCarBooking = new CarBooking();
			await GetAllCarBookingsTask();
			//await GetAllBookingAsync();
			await GetCurrentCarTask();

			//foreach (Booking b in Bookings)
			//{
			//	if (b.Status != Datastructures.Status.Open)
			//	{
			//		Bookings.Remove(b);
			//	}
			//}
			foreach (CarBooking cb in CarBookings)
			{
				if (cb.OrderNo == SelectedBooking.OrderNo && cb.CarId == 1)
				{
					updatedCarBooking.CarId = CurrentCar.Id;
					updatedCarBooking.OrderNo = cb.OrderNo;
					updatedCarBooking.CarBookingId = cb.CarBookingId;
					await UpdateCarBooking(updatedCarBooking);
					break;
				}
			}
			SelectedBooking.Status = Datastructures.Status.PendingClosing;
			await UpdateBooking(SelectedBooking);
			navigation.Navigate(typeof(View.DisplayMyBookingCar));
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

		public async void CancelJob()
		{
			SelectedBooking.Status = Datastructures.Status.PendingAccept;
			await UpdateBooking(SelectedBooking);
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
	}
}
