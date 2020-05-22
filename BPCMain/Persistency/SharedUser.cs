using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPCMain.ViewModel;

namespace BPCMain.Persistency
{
    class SharedUser : BaseVM
    {
        #region Instance Fields

        private int _userUser;
        private string _userPass;
        #endregion

        #region Properties

        public int UserUser
        {
            get { return _userUser; }
            set { _userUser = value; }
        }

        public string UserPass
        {
            get { return _userPass; }
            set { _userPass = value; }
        }
        #endregion

        #region Singleton

        private static SharedUser _instance = new SharedUser();

        public static SharedUser Instance
        {
            get { return _instance; }
        }
        #endregion

    }
}
