using System.Collections.Generic;
using BPCClassLibrary;
using System.Threading.Tasks;
using BPCMain.Utilities;

namespace BPCMain.ViewModel
{
	class DisplayMyBookingCar : BookingVM
	{

		public DisplayMyBookingCar()
		{
			_cancelJobCar = new RelayCommand(CancelJob, null);
		}

		//public async void CancelJob()
		//{
		//	SelectedBooking.Status = Datastructures.Status.Open;
		//	await UpdateBookingTask(SelectedBooking);
		//}

		public async void CancelJob()
		{
			SelectedBooking.Status = Datastructures.Status.PendingAccept;
			await UpdateBooking(SelectedBooking);
		}

		protected override async Task<bool> GetAllBookingAsync()
		{
			Bookings.Clear();
			List<Booking> list = (List<Booking>)await restworker.GetAllObjectsAsync<Booking>(Datastructures.TableName.Booking);
			foreach (Booking b in list)
			{
				if (b.Status == Datastructures.Status.PendingClosing)
				{
					foreach (CarBooking cb in CarBookings)
					{
						if (cb.CarId == CurrentCar.Id && b.OrderNo == cb.OrderNo)
						{
								Bookings.Add(b);
						}
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
	}
}
