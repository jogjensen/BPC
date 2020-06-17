using System;
using System.Collections.Generic;
using System.Text;

namespace BPCClassLibrary
{
    public class Customer
    {
        #region Instance fields

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
        #endregion

        #region Constructors

        public Customer()
        {

        }

        public Customer(string companyName, int cvrNo, string eMail, string telephoneNo, string mobileNo, string address, string postalCode, string country, string password)
        {
	        _companyName = companyName;
	        _cvrNo = cvrNo;
	        _eMail = eMail;
	        _telephoneNo = telephoneNo;
	        _mobileNo = mobileNo;
	        _address = address;
	        _postalCode = postalCode;
	        _country = country;
	        _password = password;
        }

        #endregion

        #region Properties

        public string CompanyName
        {
            get => _companyName;
            set => _companyName = value;
        }

        public int CvrNo
        {
            get => _cvrNo;
            set => _cvrNo = value;
        }

        public string EMail
        {
            get => _eMail;
            set => _eMail = value;
        }

        public string TelephoneNo
        {
            get => _telephoneNo;
            set => _telephoneNo = value;
        }

        public string MobileNo
        {
            get => _mobileNo;
            set => _mobileNo = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public string PostalCode
        {
            get => _postalCode;
            set => _postalCode = value;
        }

        public string Country
        {
	        get => _country;
	        set => _country = value;
        }

      public string Password
        {
            get => _password;
            set => _password = value;
        }

        public int Truckdriver
        {
	        get => _truckdriver;
	        set => _truckdriver = value;
        }
      #endregion
   }
}
