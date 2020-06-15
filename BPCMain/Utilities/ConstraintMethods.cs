using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.SmartCards;
using Windows.Media.Protection.PlayReady;
using Windows.UI.Composition;
using Windows.UI.Xaml.Controls;
using BPCClassLibrary;


namespace BPCMain.Utilities
{
	public static class ConstraintMethods
	{
	
		public static bool CreateCarCheck(Car car)
		{
			if (!OnlyNumbersCheck(car.TelephoneNo) ||
				 !OnlyNumbersCheck(car.MobileNo) ||
				 !OnlyNumbersCheck(car.PostalCode) ||
				 !StringLengthCheck(car.FirstName, 2, 50) ||
				 !StringLengthCheck(car.LastName, 2, 50) ||
				 !CheckNumber(car.CvrNo, 10000000, 99999999) ||
				 !StringLengthCheck(car.EMail, 3, 50) ||
				 !StringLengthCheck(car.TelephoneNo, 8, 8) ||
				 !StringLengthCheck(car.MobileNo, 0, 8) ||
				 !StringLengthCheck(car.Address, 1, 30) ||
				 !StringLengthCheck(car.PostalCode, 4, 4) ||
				 !StringLengthCheck(car.Country, 1, 30) ||
				 !StringLengthCheck(car.Password, 6, 16)) return false;
			return true;

		}

		public static bool CreateUserCheck(Customer newCustomer)
		{
			if (
				!StringLengthCheck(newCustomer.CompanyName, 2, 50) ||
				!CheckNumber(newCustomer.CvrNo, 10000000, 99999999) ||
				!StringLengthCheck(newCustomer.EMail, 3, 50) ||
				!StringLengthCheck(newCustomer.TelephoneNo, 8, 8) ||
				!OnlyNumbersCheck(newCustomer.TelephoneNo) ||
				!StringLengthCheck(newCustomer.MobileNo, 0, 16) ||
				!OnlyNumbersCheck(newCustomer.MobileNo) ||
				!StringLengthCheck(newCustomer.Address, 6, 80) ||
				!StringLengthCheck(newCustomer.PostalCode, 4, 10) ||
				!OnlyNumbersCheck(newCustomer.PostalCode) ||
				!StringLengthCheck(newCustomer.Country, 2, 40) ||
				!StringLengthCheck(newCustomer.Password, 6, 30)) return false;
			return true;
		}

		public static bool CreateBookingCheck(Booking booking) 
		{
			if (
				!CheckNumber(booking.CompanyCvrNo, 10000000, 99999999) ||
				!CheckNumber(booking.NumOfCarsNeeded, 1, 4)) return false;
			return true;
		}

		public static bool CreatetruckdriverCheck(Truckdriver truckdriver)
		{
			if (
				!StringLengthCheck(truckdriver.EMail, 3, 50) ||
				!CheckNumber(truckdriver.TelephoneNo, 10000000, 99999999)) return false;
			return true;
		}

		public static bool CheckNumber(int number, int min, int max) //Returnerer True hvis number er mellem min og max.
		{
			if (number >= min && number <= max) return true;
			return false;
		}


		public static bool StringLengthCheck(string str, int minLength, int maxLength) //Returnerer True hvis længden af str er mellem minLength og maxLength
		{
			if (str.Length >= minLength && str.Length <= maxLength) return true;
			return false;
		}

		public static bool OnlyNumbersCheck(string str) //Returnerer True hvis str kun består af tal.
		{
			bool isOnlyNumbers = true;
			if (str.Equals("N/A")) return true;
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
