using BPCClassLibrary;
using BPCMain.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BPCMain.ViewModel
{
    class BookingAdminVM : DisplayBookingCompany
    {
        private RelayCommand _deleteBooking;

        public BookingAdminVM()
        {
            _deleteBooking = new RelayCommand(DeleteBookingAsync, null);
        }

        protected override async Task<bool> GetAllBookingAsync()
        {
            List<Booking> list = (List<Booking>)await restworker.GetAllObjectsAsync<Booking>(Datastructures.TableName.Booking);
            Bookings = new ObservableCollection<Booking>(list);
            return true;
        }

        //private async void DeleteBookingAsync()
        //{
        //    await DeleteBookingTask();
        //}

        //private async Task<bool> DeleteBookingTask()
        //{
        //    bool deleted = await restworker.DeleteObjectAsync<Booking>(SelectedBooking.OrderNo, Datastructures.TableName.Booking);
        //    Bookings.Remove(SelectedBooking);
        //    return deleted;
        //}

    }
}
