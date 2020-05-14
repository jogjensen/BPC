using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BPCMain.Utilities
{
    static class ConstraintMethods
    { 
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
