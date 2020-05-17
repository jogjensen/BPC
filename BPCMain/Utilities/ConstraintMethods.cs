using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.SmartCards;
using Windows.UI.Composition;

namespace BPCMain.Utilities
{
	public static class ConstraintMethods
	{

		public static bool CreateCarCheck(string firstName, string lastName, int cvrNo, string eMail, string telephoneNo, string mobileNo, string address, string postalCode, string country, string password)
		{
			if (!OnlyNumbersCheck(telephoneNo) ||
				 !OnlyNumbersCheck(mobileNo) ||
				 !OnlyNumbersCheck(postalCode) ||
				 //!OnlyNumbersCheck(cvrNo) ||
				 !StringLengthCheck(firstName, 2, 30) ||
				 !StringLengthCheck(lastName, 2, 30) ||
				 !CheckNumber(cvrNo, 10000000, 99999999) ||
				 !StringLengthCheck(eMail, 10, 30) ||
				 !StringLengthCheck(telephoneNo, 8, 8) ||
				 !StringLengthCheck(mobileNo, 8, 8) ||
				 !StringLengthCheck(address, 5, 30) ||
				 !StringLengthCheck(postalCode, 4, 4) ||
				 !StringLengthCheck(country, 2, 30) ||
				 !StringLengthCheck(password, 6, 16)) return false;
			return true;

		}

        public static bool CreateUserCheck(string CompanyName, int CvrNo, string Email, string TelephoneNo,
            string MobileNo, string Address, string PostalCode, string Country, string Password)
        {
            if (
                !StringLengthCheck(CompanyName,2,50)||
				!CheckNumber(CvrNo,100000,999999999)||
                !StringLengthCheck(Email,6,50)||
				!StringLengthCheck(TelephoneNo,6,16)||
                !OnlyNumbersCheck(TelephoneNo) ||
				!StringLengthCheck(MobileNo,6,16)||
				!OnlyNumbersCheck(MobileNo)||
				!StringLengthCheck(Address,10,80)||
				!StringLengthCheck(PostalCode,4,10)||
				!OnlyNumbersCheck(PostalCode)||
				!StringLengthCheck(Country,2,40)||
				!StringLengthCheck(Password,6,30)) return false;
            return true;

		}

		public static bool CheckNumber(int number, int min, int max)
		{
			if (number >= min && number <= max) return true;
			return false;
		}


		public static bool StringLengthCheck(string str, int minLength, int maxLength)
		{
			if (str.Length >= minLength && str.Length <= maxLength) return true;
			return false;
		}

		public static bool OnlyNumbersCheck(string str)
		{
			bool isOnlyNumbers = true;
			foreach (char c in str)
			{
				int unicode = c;
				if (unicode < 48 || unicode > 57) isOnlyNumbers = false;
			}
			return isOnlyNumbers;
		}

		//Mangler at blive testet
		public static bool IsEmailValid(string eMail)
		{
			//MailAddress kaster exceptions hvis addressen ikke er valid, derfor try/catch.
			try
			{
				MailAddress address = new MailAddress(eMail);
				return address.Address == eMail;
			}
			catch
			{
				return false;
			}
		}
	}
}
