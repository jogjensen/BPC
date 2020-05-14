using System;
using System.Collections.Generic;
using System.Text;

namespace BPCClassLibrary
{
    public class Car
    {
        #region Instance fields

        private int _id;
        private string _firstName;
        private string _lastName;
        private int _cvrNo;
        private string _eMail;
        private string _telephoneNo;
        private string _mobileNo;
        private string _address;
        private string _postalCode;
        private string _country;
        private string _password;
        #endregion

        #region Constructors

        public Car()
        {

        }
        #endregion

        #region Properties

        public int Id
        {
	        get => _id;
	        set => _id = value;
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
