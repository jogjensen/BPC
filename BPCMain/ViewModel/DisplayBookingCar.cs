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

		private ObservableCollection<Car> _cars = new ObservableCollection<Car>();

		public RelayCommand AcceptBookingCar
		{
			get { return _acceptBookingCar; }
		}

		public DisplayBookingCar()
		{
			_acceptBookingCar = new RelayCommand(AcceptBookCar, null);
		}

		#region DisplayBookingCar Methods

		public async void AcceptBookCar()
		{
			await GetAllCarBookingsTask();
			await GetAllCarsTask();
			CarBooking updatedCarBooking = new CarBooking();
			GetCurrentCar();
			foreach (CarBooking cb in CarBookings)
			{
				if (cb.OrderNo.Equals(SelectedBooking.OrderNo) && cb.CarId == 0)
				{
					//cb.CarId = CurrentCar.Id;
					
					updatedCarBooking.CarId = CurrentCar.Id;
					updatedCarBooking.OrderNo = cb.OrderNo;
					updatedCarBooking.CarBookingId = cb.CarBookingId;
					await UpdateCarBooking(updatedCarBooking);
					break;
				}
			}
			SelectedBooking.Status = Datastructures.Status.PendingClosing;
			await UpdateBooking(SelectedBooking);
			navigation.Navigate(typeof(View.DisplayBookingCar));
		}

		public async Task<bool> UpdateCarBooking(CarBooking upDatedCarBooking)
		{
			var Task = await restworker.UpdateObjectAsync<CarBooking>(upDatedCarBooking, upDatedCarBooking.CarBookingId, Datastructures.TableName.CarBooking);
			return Task;
		}

		public async void CancelJob()
		{
			SelectedBooking.Status = Datastructures.Status.Open;
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
