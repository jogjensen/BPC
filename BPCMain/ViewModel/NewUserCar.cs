using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using BPCClassLibrary;
using BPCMain.Utilities;
using static BPCMain.Utilities.ConstraintMethods;
using static BPCMain.Utilities.NavigationService;
using BPCMain.Persistency;

namespace BPCMain.ViewModel
{
	class NewUserCar : BaseVM
	{
		#region Instance Fields

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

		private string _errorMessage;

		private RelayCommand _createCar;

		private NavigationService navigation = new NavigationService();
		private RestWorker restworker = new RestWorker();

		#endregion

		#region Properties

		public string FirstName
		{
			get { return _firstName; }
			set
			{
				_firstName = value;
			}
		}

		public string LastName
		{
			get { return _lastName; }
			set { _lastName = value; }
		}

		public int CvrNo
		{
			get { return _cvrNo; }
			set { _cvrNo = value; }
		}

		public string EMail
		{
			get { return _eMail; }
			set { _eMail = value; }
		}

		public string TelephoneNo
		{
			get { return _telephoneNo; }
			set { _telephoneNo = value; }
		}

		public string MobileNo
		{
			get { return _mobileNo; }
			set { _mobileNo = value; }
		}

		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}

		public string PostalCode
		{
			get { return _postalCode; }
			set { _postalCode = value; }
		}

		public string Country
		{
			get { return _country; }
			set { _country = value; }
		}

		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}

		public string ErrorMessage
		{
			get { return _errorMessage; }
			set
			{
				_errorMessage = value;
				OnPropertyChanged();
			}
		}



		#endregion

		#region RelayCommands

		public RelayCommand CreateCar
		{
			get { return _createCar; }
			set
			{
				_createCar = value; //er denne linje nødvendig???
				Car newCar = new Car(FirstName, LastName, CvrNo, EMail, TelephoneNo, MobileNo, Address, PostalCode, Country, Password);
				if (CreateCarCheck(newCar)) //metode i ConstraintMethods
				{
					//save new Car in database
					CreateNewCar(newCar);
					navigation.Navigate(typeof(BPCMain.View.DisplayBookingCar));
				}
				else
				{
					ErrorMessage = "Fejl i oplysninger"; //evt. bruge header til fejlmeddelelser
				}
			}
		}

		#endregion

		#region Methods

		public async Task<bool> CreateNewCar<T>(T newCar)
		{
			var Task = await restworker.CreateObjectAsync(newCar, Datastructures.TableName.Car);
			var result = Task;
				return result;
		}

		#endregion
	}
}
