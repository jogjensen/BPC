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
	class HomePageLogin
	{
        #region Instance Fields

        private RelayCommand _faqCommand;
        private RelayCommand _aboutBpcCommand;
        private RelayCommand _createUserCarCommand;
        private RelayCommand _createUserCompanyCommand;
        private RelayCommand _tryLogin;

        private int _userUser;
        private string _userPass;

        private NavigationService _navigation = new NavigationService();
        private RestWorker restWorker = new RestWorker();
        #endregion

        #region Constructor

        public HomePageLogin()
        {
            _faqCommand = new RelayCommand(NavigateToFaq, null);
            _aboutBpcCommand = new RelayCommand(NavigateToAboutBpc, null);
            _createUserCarCommand = new RelayCommand(NavigateToCreateUserCar, null);
            _createUserCompanyCommand = new RelayCommand(NavigateToCreateUserCompany, null);
            _tryLogin = new RelayCommand(CheckUserInfo, null);
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
        #endregion

        #region Methods

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

        public async void CheckUserInfoCar()
        {
            IList<Car> carList = await restWorker.GetAllObjectsAsync<Car>(tableName: Datastructures.TableName.Car);
            foreach (var car in carList)
            {
                if (UserUser == car.CvrNo)
                {
                    if (UserPass == car.Password)
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
                if (UserUser == customer.CvrNo)
                {
                    if (UserPass == customer.Password)
                    {
                        LoginPopUp();
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

        private async void LoginPopUp()
        {
            try
            {
                ContentDialog dialogue = new ContentDialog()
                {
                    Title = "Log in",
                    Content = "Signed in successfully",
                    CloseButtonText = "Ok",
                };
                await dialogue.ShowAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
