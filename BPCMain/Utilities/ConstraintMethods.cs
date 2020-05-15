using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.SmartCards;

namespace BPCMain.Utilities
{
    public static class ConstraintMethods
    {

		 public static bool CreateCarCheck(string firstName, string lastName, int cvrNo, string eMail, string telephoneNo, string mobileNo, string address, string postalCode, string country, string password)
	    {
			if (StringLengthCheck(firstName, 2, 30) == false ||
			    StringLengthCheck(lastName, 2, 30) == false ||
			    CheckNumber(cvrNo, 10000000, 99999999) == false ||
			    StringLengthCheck(eMail, 10, 30) == false ||
			    StringLengthCheck(telephoneNo, 8, 8) == false ||
			    StringLengthCheck(mobileNo, 8, 8) == false ||
			    StringLengthCheck(address, 5, 30) == false ||
			    StringLengthCheck(postalCode, 4, 4) == false ||
			    StringLengthCheck(country, 2, 30) == false ||
			    StringLengthCheck(password, 6, 16) == false)
			{
					return false;
			}
			else
			{
				return true;
			}
	    }

		 public static bool CheckNumber(int number, int min, int max)
		 {
			 if (number >= min && number <= max)
			 {
				 return true;
			 }
			 else
			 {
				 return false;
			 }
		 }


	    public static bool StringLengthCheck(string str, int minLength, int maxLength)
	    {
			    if (str.Length >= minLength && str.Length <= maxLength)
			    {
				    return true;
			    }
			    else
			    {
			    return false;
				 }
	    }

		 //public static bool OnlyNumbersCheck(string str)
		 //{

		 //}

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
