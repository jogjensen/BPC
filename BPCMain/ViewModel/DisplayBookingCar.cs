using BPCClassLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPCMain.ViewModel
{
	class DisplayBookingCar : BookingVM
	{
		private ObservableCollection<Car> _cars = new ObservableCollection<Car>();

		#region DisplayBookingCar Methods

		public async void AcceptBookCar()
		{
			SelectedBooking.Status = Datastructures.Status.PendingClosing;
			//await UpdateCarBooking()
			await UpdateBooking(SelectedBooking);
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

		public async Task<bool> UpdateCarBooking(CarBooking upDatedCarBooking)
		{
			var Task = await restworker.UpdateObjectAsync<CarBooking>(upDatedCarBooking, )  // Datastructures.TableName.Booking);
			return Task;
		}

		protected async Task<bool> GetAllCarsAsync()
		{
			List<Booking> list = (List<Booking>)await restworker.GetAllObjectsAsync<Booking>(Datastructures.TableName.Booking);
			Bookings = new ObservableCollection<Booking>(list);
			return true;
		}

		protected async Task<bool> getAllCarBookingsTask()
		{
			List<Booking> list = (List<Booking>)await restworker.GetAllObjectsAsync<Booking>(Datastructures.TableName.Booking);
			Bookings = new ObservableCollection<Booking>(list);
			return true;
		}

		#endregion

		#region DisplayBookingCar RelayCommands



		#endregion
	}
}
