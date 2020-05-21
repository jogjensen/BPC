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

namespace BPCMain.ViewModel
{
	class HomePageLogin : BaseVM
	{
        #region Instance Fields

        private string _errorMessage;

        private RelayCommand _faqCommand;
        private RelayCommand _aboutBpcCommand;
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
            _createUserCarCommand = new RelayCommand(NavigateToCreateUserCar, null);
            _createUserCompanyCommand = new RelayCommand(NavigateToCreateUserCompany, null);
            _tryLogin = new RelayCommand(CheckUserInfo, null);
        }
        #endregion

        #region Properties

        public string ErrorMessage1
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
            get { return _createUserCarCommand; }
        }

        public RelayCommand TryLogin
        {
            get { return _tryLogin; }
        }
        #endregion

        #region Navigation Methods

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
            _navigation.Navigate(typeof(NewUserCar));
        }

        private void NavigateToCreateUserCompany()
        {
            _navigation.Navigate(typeof(NewUserCompany));
        }
        #endregion

        #region Login Logic

        public async void CheckUserInfoCar()
        {
            IList<Car> carList = await restWorker.GetAllObjectsAsync<Car>(tableName: Datastructures.TableName.Car);
            foreach (var car in carList)
            {
                if (_shared.UserUser == car.CvrNo)
                {
                    if (_shared.UserPass == car.Password)
                    {
                        _navigation.Navigate(typeof(AboutUs));
                    }
                }
                else
                {
                    string ErrorMessage = "Fejl i login";
                }
            }
        }

        public async void CheckUserInfoCustomer()
        {
            IList<Customer> customerList = await restWorker.GetAllObjectsAsync<Customer>(tableName: Datastructures.TableName.Customer);
            foreach (var customer in customerList)
            {
                if (_shared.UserUser == customer.CvrNo)
                {
                    if (_shared.UserPass == customer.Password)
                    {
                        _navigation.Navigate(typeof(AboutUs));
                    }
                }
                else
                {
                    string ErrorMessage = "Fejl i login";
                }
            }
        }

        public async void CheckUserInfo()
        {
            CheckUserInfoCar();
            CheckUserInfoCustomer();
        }
        #endregion
    }
}
