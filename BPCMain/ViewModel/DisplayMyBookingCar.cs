using BPCClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			GetCurrentCar();
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
