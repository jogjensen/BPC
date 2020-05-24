using BPCClassLibrary;
using BPCMain.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Display;
using Windows.System;
using static BPCMain.Utilities.ConstraintMethods;

namespace BPCMain.ViewModel
{
	class DisplayBookingCompany : BookingVM
	{

		private RelayCommand _deleteBooking;
		private RelayCommand _updateBooking;

		public DisplayBookingCompany()
		{
			
			_deleteBooking = new RelayCommand(DeleteBookingAsync, null);
			_updateBooking = new RelayCommand(UpdateBookingAsync, null);
		}

		protected override async void GetBookingsAsync()
		{
			_ = await GetAllBookingAsync();
		}

		protected override async Task<bool> GetAllBookingAsync()
		{
			Bookings.Clear();
			List<Booking> list = (List<Booking>)await restworker.GetAllObjectsAsync<Booking>(Datastructures.TableName.Booking);
			foreach (Booking b in list)
			{
				if (b.CompanyCvrNo == Shared.UserUser)
				{
					Bookings.Add(b);
				}
			}
			return true;
		}

		protected async void DeleteBookingAsync()
		{
			await DeleteBookingTask(SelectedBooking, Bookings);
		}

		protected virtual async Task<bool> DeleteBookingTask(Booking selBooking, IList<Booking> bookings)
		{
			bool deleted = await restworker.DeleteObjectAsync<Booking>(selBooking.OrderNo, Datastructures.TableName.Booking);
			bookings.Remove(selBooking);
			return deleted;
		}

		protected async void UpdateBookingAsync()
		{
			await UpdateBookingCompanyTask(SelectedBooking);
		}

		protected async Task<bool> UpdateBookingCompanyTask(Booking updatedBooking)
		{
			updatedBooking.Status = (Datastructures.Status)Enum.Parse(typeof(Datastructures.Status), StatusString, true);
			bool updated = await restworker.UpdateObjectAsync<Booking>(updatedBooking, updatedBooking.OrderNo, Datastructures.TableName.Booking);
			return updated;
		}

		public RelayCommand DeleteBookingRC
		{
			get => _deleteBooking;
		}

		public RelayCommand UpdateBookingRC
		{
			get => _updateBooking;
		}

	}
}
