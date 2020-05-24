using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPCMain.Utilities;
using BPCMain.View;
using BPCMain.ViewModel;

namespace BPCMain.Persistency
{
    class SharedUser : BaseVM
    {
        #region Instance Fields

        private int _userUser;
        private string _userPass;

        private RelayCommand _backCommand;
        private RelayCommand _faqCommand;
        private RelayCommand _aboutBpcCommand;
        private RelayCommand _contactBpcCommand;
        private RelayCommand _displayBookingAdminCommand;
        private RelayCommand _displayBookingCarCommand;
        private RelayCommand _displayBookingCompanyCommand;

        private NavigationService _navigation = new NavigationService();
        #endregion

        #region Constructor

        public SharedUser()
        {
            _backCommand = new RelayCommand(GoBack, null);
            _faqCommand = new RelayCommand(NavigateToFAQ, null);
            _aboutBpcCommand = new RelayCommand(NavigateToAbout, null);
            _contactBpcCommand = new RelayCommand(NavigateToContact, null);
            _displayBookingAdminCommand = new RelayCommand(NavigateToBookingAdmin, null);
            _displayBookingCarCommand = new RelayCommand(NavigateToBookingCar, null);
            _displayBookingCompanyCommand = new RelayCommand(NavigateToBookingCompany, null);
        }
        #endregion

        #region Properties

        public int UserUser
        {
            get { return _userUser; }
            set { _userUser = value; }
        }

        public string UserPass
        {
            get { return _userPass; }
            set { _userPass = value; }
        }

        public RelayCommand BackCommand
        {
            get { return _backCommand; }
        }

        public RelayCommand FAQCommand
        {
            get { return _faqCommand; }
        }

        public RelayCommand AboutBpcCommand
        {
            get { return _aboutBpcCommand; }
        }

        public RelayCommand ContactBpcCommand
        {
            get { return _contactBpcCommand; }
        }

        public RelayCommand DisplayBookingAdminCommand
        {
            get { return _displayBookingAdminCommand; }
        }

        public RelayCommand DisplayBookingCarCommand
        {
            get { return _displayBookingCarCommand; }
        }

        public RelayCommand DisplayBookingCompanyCommand
        {
            get { return _displayBookingCompanyCommand; }
        }
        #endregion

        #region Methods

        public void GoBack()
        {
            _navigation.GoBack();
        }

        public void NavigateToFAQ()
        {
            _navigation.Navigate(typeof(Faq));
        }

        public void NavigateToAbout()
        {
            _navigation.Navigate(typeof(AboutUs));
        }

        public void NavigateToContact()
        {
            _navigation.Navigate(typeof(ContactBPC));
        }

        public void NavigateToBookingAdmin()
        {
            _navigation.Navigate(typeof(DisplayBookingAdmin));
        }

        public void NavigateToBookingCar()
        {
            _navigation.Navigate(typeof(View.DisplayBookingCar));
        }

        public void NavigateToBookingCompany()
        {
            _navigation.Navigate(typeof(View.DisplayBookingCompany));
        }
        #endregion

        #region Singleton

        private static SharedUser _instance = new SharedUser();

        public static SharedUser Instance
        {
            get { return _instance; }
        }
        #endregion
    }
}
