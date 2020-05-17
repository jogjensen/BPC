using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.SmartCards;
using BPCClassLibrary;

namespace BPCMain.Utilities
{
	public static class ConstraintMethods
	{
		//string firstName, string lastName, int cvrNo, string eMail, string telephoneNo, string mobileNo, string address, string postalCode, string country, string password
		public static bool CreateCarCheck(Car car)
		{
			if (!OnlyNumbersCheck(car.TelephoneNo) ||
				 !OnlyNumbersCheck(car.MobileNo) ||
				 !OnlyNumbersCheck(car.PostalCode) ||
				 //!OnlyNumbersCheck(car.CvrNo) ||
				 !StringLengthCheck(car.FirstName, 2, 30) ||
				 !StringLengthCheck(car.LastName, 2, 30) ||
				 !CheckNumber(car.CvrNo, 10000000, 99999999) ||
				 !StringLengthCheck(car.EMail, 10, 30) ||
				 !StringLengthCheck(car.TelephoneNo, 8, 8) ||
				 !StringLengthCheck(car.MobileNo, 8, 8) ||
				 !StringLengthCheck(car.Address, 5, 30) ||
				 !StringLengthCheck(car.PostalCode, 4, 4) ||
				 !StringLengthCheck(car.Country, 2, 30) ||
				 !StringLengthCheck(car.Password, 6, 16)) return false;
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
