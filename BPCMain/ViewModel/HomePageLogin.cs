using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private RelayCommand _userLogin;
        private NavigationService _navigation = new NavigationService();
        #endregion

        #region Constructor

        public HomePageLogin()
        {
            _faqCommand = new RelayCommand(NavigateToFaq, null);
            _aboutBpcCommand = new RelayCommand(NavigateToAboutBpc, null);
            _createUserCarCommand = new RelayCommand(NavigateToCreateUserCar, null);
            _createUserCompanyCommand = new RelayCommand(NavigateToCreateUserCompany, null);
            _userLogin = new RelayCommand(CheckUserInfo, null);
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

        public RelayCommand UserLogin
        {
            get { return _userLogin; }
            set { _userLogin = value; }
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

        private void CheckUserInfo()
        {

        }
        #endregion
    }
}
