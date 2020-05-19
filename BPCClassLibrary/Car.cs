using System;
using System.Collections.Generic;
using System.Text;

namespace BPCClassLibrary
{
    public class Car
    {
        #region Instance fields

        private int _carId;
        private string _firstName;
        private string _lastName;
        private int _cvrNo;
        private string _eMail;
        private string _telephoneNo;
        private string _mobileNo;
        private string _address;
        private string _postalCode;
        private string _city;
        private string _country;
        private string _password;
        #endregion

        #region Constructors

        public Car()
        {

        }

        public Car(string firstName, string lastName, int cvrNo, string eMail, string telephoneNo, string address, string postalCode, string country, string password, string city, string mobileNo = "N/A")
        {
	        _firstName = firstName;
	        _lastName = lastName;
	        _cvrNo = cvrNo;
	        _eMail = eMail;
	        _telephoneNo = telephoneNo;
	        _mobileNo = mobileNo;
	        _address = address;
	        _postalCode = postalCode;
            _city = city;
	        _country = country;
	        _password = password;
        }

        #endregion

      #region Properties

      public int Id
        {
	        get => _carId;
	        set => _carId = value;
      }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
	        get => _lastName;
	        set => _lastName = value;
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

        public string City
        {
            get => _city;
            set => _city = value;
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
        #endregion
    }
}
