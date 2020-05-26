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
    class BookingAdminVM : DisplayBookingCar
    {
        #region Instance Fields

        private RelayCommand _deleteBooking;
        private RelayCommand _backCommand;
        private RelayCommand _displayAllBookingsCommand;
        private RelayCommand _displayAllCarsCommand;

        private NavigationService _navigation;
        private Car _selectedCar;
        #endregion

        #region Constructor

        public BookingAdminVM()
        {
            GetCarAsync();
            _navigation = new NavigationService();
            _backCommand = new RelayCommand(GoBack, null);
            _displayAllBookingsCommand = new RelayCommand(NavigateToDisplayAllBookings, null);
            _displayAllCarsCommand = new RelayCommand(NavigateToDisplayAllCars, null);
        }
        #endregion

        private async void GetCarAsync()
        {
            _ = await GetAllCarTask();
        }

        private async Task<bool> GetAllCarTask()
        {
            List<Car> list = (List<Car>)await restworker.GetAllObjectsAsync<Car>(Datastructures.TableName.Car);
            CarsList = new ObservableCollection<Car>(list);
            return true;
        }

        protected override async Task<bool> GetAllBookingAsync()
        {
            List<Booking> list = (List<Booking>)await restworker.GetAllObjectsAsync<Booking>(Datastructures.TableName.Booking);
            Bookings = new ObservableCollection<Booking>(list);
            return true;
        }

        #region RelayCommands

        public RelayCommand BackCommand
        {
            get { return _backCommand; }
        }

        public RelayCommand DisplayAllCarsCommand
        {
            get { return _displayAllCarsCommand; }
        }

        public RelayCommand DisplayAllBookingsCommand
        {
            get { return _displayAllBookingsCommand; }
        }
        #endregion

        public Car SelectedCar
        {
            get => _selectedCar;
            set => _selectedCar = value;
        }

        #region Navigation Methods
        public void NavigateToDisplayAllCars()
        {
            _navigation.Navigate(typeof(BPCMain.View.DisplayAllCars));
        }

        public void NavigateToDisplayAllBookings()
        {
            _navigation.Navigate(typeof(BPCMain.View.DisplayBookingAdmin));
        }

        public void GoBack()
        {
            _navigation.GoBack();
        }
        #endregion
       
    }
}
