using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPCMain.Utilities;

namespace BPCMain.ViewModel
{
    class AboutFaqContact
    {
		#region Instance Fields

        private RelayCommand _backCommand;
        private NavigationService _navigation = new NavigationService();
        #endregion

        #region Constructor

        public AboutFaqContact()
        {
            _backCommand = new RelayCommand(GoBack, null);
        }

        #endregion

        #region Properties



        #endregion

        #region RelayCommands

        public RelayCommand BackCommand
        {
            get { return _backCommand; }
        }
        #endregion

        #region Methods

        public void GoBack()
        {
            _navigation.GoBack();
        }
        #endregion
    }
}
