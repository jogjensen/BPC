using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using BPCMain.Utilities;
using BPCClassLibrary;
using BPCMain.Persistency;

namespace BPCMain.ViewModel
{
    class NewUserCompany : BaseVM
	{
        #region Instance Fields
        private string _companyName;
        private int _cvrNo;
        private string _eMail;
        private string _telephoneNo;
        private string _mobileNo;
        private string _address;
        private string _postalCode;
        private string _country;
        private string _password;
        private int _truckdriver;
        private RelayCommand _createCompany;
        private string _errorMessage;
        private NavigationService navigation = new NavigationService();
        private RestWorker restWorker = new RestWorker();
        #endregion

        #region Properties

        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; }
        }

        public int CvrNo
        {
            get { return _cvrNo; }
            set
            { _cvrNo = value; }
        }

        public string EMail
        {
            get { return _eMail; }
            set
            { _eMail = value; }
        }

        public string TelephoneNo
        {
            get { return _telephoneNo; }
            set
            { _telephoneNo = value; }
        }

        public string MobileNo
        {
            get { return _mobileNo; }
            set { _mobileNo = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public int Truckdriver
        {
            get { return _truckdriver; }
            set { _truckdriver = value; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; OnPropertyChanged(); }

        }

        #endregion

        #region RelayCommands

        public RelayCommand CreateCompany
        {
            get { return _createCompany; }
            set
            {
                _createCompany = value;
	                Customer newCustomer = new Customer(CompanyName, CvrNo, EMail, TelephoneNo, MobileNo, Address, PostalCode, Country, Password);
                if (ConstraintMethods.CreateUserCheck(newCustomer))
                {
                    navigation.Navigate(typeof(BPCMain.View.DisplayBookingCompany));
                }
                else
                {
                    ErrorMessage = "Fejl i oplysninger";
                }
            }
        }

        #endregion
    }
}
