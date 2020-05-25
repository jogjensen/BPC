using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using BPCClassLibrary;
using BPCMain.Persistency;
using BPCMain.Utilities;
using BPCMain.View;
using System.Threading;

namespace BPCMain.ViewModel
{
    class HomePageLogin : BaseVM
    {
        #region Instance Fields

        private string _errorMessage;
        private bool _loginSuccess = false;

        private RelayCommand _faqCommand;
        private RelayCommand _aboutBpcCommand;
        private RelayCommand _contactBpcCommand;
        private RelayCommand _createUserCarCommand;
        private RelayCommand _createUserCompanyCommand;
        private RelayCommand _tryLogin;

        private SharedUser _shared;

        private NavigationService _navigation = new NavigationService();
        private RestWorker restWorker = new RestWorker();
        #endregion

        #region Constructor

        public HomePageLogin()
        {
            _shared = SharedUser.Instance;
            _faqCommand = new RelayCommand(NavigateToFaq, null);
            _aboutBpcCommand = new RelayCommand(NavigateToAboutBpc, null);
            _contactBpcCommand = new RelayCommand(NavigateToContactBpc, null);
            _createUserCarCommand = new RelayCommand(NavigateToCreateUserCar, null);
            _createUserCompanyCommand = new RelayCommand(NavigateToCreateUserCompany, null);
            _tryLogin = new RelayCommand(CheckUserInfo, null);
        }
        #endregion

        #region Properties

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public SharedUser Shared
        {
            get { return _shared; }
        }
        #endregion

        #region RelayCommands

        public RelayCommand FAQCommand
        {
            get { return _faqCommand; }
        }

        public RelayCommand AboutBpcCommand
        {
            get { return _aboutBpcCommand; }
        }

        public RelayCommand CreateCarCommand
        {
            get { return _createUserCarCommand; }
        }

        public RelayCommand CreateCompanyCommand
        {
            get { return _createUserCompanyCommand; }
        }

        public RelayCommand ContactBpcCommand
        {
            get { return _contactBpcCommand; }
        }

        public RelayCommand TryLogin
        {
            get { return _tryLogin; }
        }
        #endregion

        #region Navigation Methods
        // Navigation methods - To target page
        private void NavigateToFaq()
        {
            _navigation.Navigate(typeof(Faq));
        }

        private void NavigateToAboutBpc()
        {
            _navigation.Navigate(typeof(AboutUs));
        }

        private void NavigateToCreateUserCar()
        {

            _navigation.Navigate(typeof(BPCMain.View.NewUserCar));

        }

        private void NavigateToCreateUserCompany()
        {
            _navigation.Navigate(typeof(BPCMain.View.NewUserCompany));
        }

        private void NavigateToContactBpc()
        {
            _navigation.Navigate(typeof(ContactBPC));
        }
        #endregion

        #region Login Logic

        // Reads through a car list from the DB, through REST worker and checks if information is similar to input
        public async void CheckUserInfoCar()
        {
            List<Car> carList = (List<Car>)await restWorker.GetAllObjectsAsync<Car>(tableName: Datastructures.TableName.Car);
            foreach (var car in carList)
            {
                if (_shared.UserUser == car.CvrNo)
                {
                    if (_shared.UserPass.Equals(car.Password))
                    {
                        _loginSuccess = true;
                        _navigation.Navigate(typeof(View.DisplayBookingCar));
                    }
                }
            }
        }

        private async void CheckUserInfoCustomer()
        {
            Customer customer = await restWorker.GetObjectFromIdAsync<Customer>(Shared.UserUser, Datastructures.TableName.Customer);
            if (Shared.UserPass.Equals(customer.Password))
            {
                _loginSuccess = true;
                _navigation.Navigate(typeof(View.CreateBookingCompany));
            }
        }

        // Reads through a customer list from the DB, through REST worker and checks if information is similar to input
        //public async void CheckUserInfoCustomer()
        //{
        //    List<Customer> customerList = (List<Customer>)await restWorker.GetAllObjectsAsync<Customer>(tableName: Datastructures.TableName.Customer);
        //    foreach (var customer in customerList)
        //    {
        //        if (_shared.UserUser == customer.CvrNo)
        //        {
        //            if (_shared.UserPass.Equals(customer.Password))
        //            {
        //                _loginSuccess = true;
        //                _navigation.Navigate(typeof(View.CreateBookingCompany));
        //            }
        //        }
        //    }
         
        //}
        //uskønt admin hack
        private void AdminLogin(int name, string psw)
        {
            if (Shared.UserUser == name && Shared.UserPass.Equals(psw))
                _navigation.Navigate(typeof(View.DisplayBookingAdmin));
        }


        // Method runs both aforementioned methods and is stored in a RelayCommand which is bound to the login button
        public void CheckUserInfo()
        {
            AdminLogin(2020, "Admin");
            
            CheckUserInfoCar();
            CheckUserInfoCustomer();
            if (!_loginSuccess)
                ErrorMessage = "Fejl i login.";
        }
        #endregion
    }
}
