using BPCClassLibrary;

namespace BPCMain.ViewModel
{
	class DisplayMyBookingCar : BookingVM
	{

		public DisplayMyBookingCar()
		{
			DisplayMyBookings();
		}

		public async void DisplayMyBookings()
		{
			await GetAllCarBookingsTask();
			await GetCurrentCarTask();
			foreach (CarBooking cb in CarBookings)
			{
				if (cb.CarId != CurrentCar.Id)
				{
					foreach (Booking b in Bookings)
					{
						if (b.OrderNo == cb.OrderNo)
						{
							MyCarBookings.Add(b);
						}
					}
				}
			}


		}
	}
}
