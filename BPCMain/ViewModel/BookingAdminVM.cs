using BPCClassLibrary;
using BPCMain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BPCMain.ViewModel
{
    class BookingAdminVM : BookingVM
    {
        private RelayCommand _deleteBooking;

        public BookingAdminVM()
        {
            _deleteBooking = new RelayCommand(DeleteBookingAsync, null);
        }

        private async void DeleteBookingAsync()
        {
            await DeleteBookingTask();
        }

        private async Task<bool> DeleteBookingTask()
        {
            bool deleted = await restworker.DeleteObjectAsync<Booking>(SelectedBooking.OrderNo, Datastructures.TableName.Booking);
            Bookings.Remove(SelectedBooking);
            return deleted;
        }



        public RelayCommand DeleteBookingRC
        {
            get { return _deleteBooking; }
        }
    }
}
