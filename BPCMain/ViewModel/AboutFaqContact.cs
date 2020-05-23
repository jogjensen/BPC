using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPCMain.Utilities;
using BPCMain.View;

namespace BPCMain.ViewModel
{
    class AboutFaqContact
    {
		#region Instance Fields

        private RelayCommand _backCommand;
        private RelayCommand _faqCommand;
        private RelayCommand _aboutBpcCommand;
        private RelayCommand _contactBpcCommand;
        private NavigationService _navigation = new NavigationService();
        #endregion

        #region Constructor

        public AboutFaqContact()
        {
            _faqCommand = new RelayCommand(NavigateToFaq, null);
            _aboutBpcCommand = new RelayCommand(NavigateToAboutBpc, null);
            _contactBpcCommand = new RelayCommand(NavigateToContactBpc, null);
            _backCommand = new RelayCommand(GoBack, null);
        }

        #endregion

        #region Properties

        public RelayCommand BackCommand
        {
            get { return _backCommand; }
        }

        public RelayCommand FAQCommand
        {
            get { return _faqCommand; }
        }

        public RelayCommand AboutBpcCommand
        {
            get { return _aboutBpcCommand; }
        }

        public RelayCommand ContactBpcCommand
        {
            get { return _contactBpcCommand; }
        }
        #endregion

        #region Methods

        public void GoBack()
        {
            _navigation.GoBack();
        }

        private void NavigateToContactBpc()
        {
            _navigation.Navigate(typeof(ContactBPC));
        }

        private void NavigateToFaq()
        {
            _navigation.Navigate(typeof(Faq));
        }

        private void NavigateToAboutBpc()
        {
            _navigation.Navigate(typeof(AboutUs));
        }
        #endregion
    }
}
