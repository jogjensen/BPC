using BPCClassLibrary;
using BPCMain.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BPCMain.Utilities.ConstraintMethods;
using BPCMain;
using BPCMain.Persistency;
using System.Reflection.Metadata.Ecma335;

namespace BPCMain.ViewModel
{
	class CreateBookingCompany : BookingVM
	{
		private RelayCommand _createBookingCompany;

		public CreateBookingCompany()
		{
			//Denne relaycommand tager en command som parameter/argument og kriteriet for at denne relaycommand kan køre/aktiveres?
				_createBookingCompany = new RelayCommand(NewBooking, null);

		}

		#region functions

		public async void NewBooking()
		{
			//Opretninng af Booking objekt
			Booking newBooking = new Booking(0, _shared.UserUser, NumOfCarsNeeded, TypeOfGoods, TotalWidth, TotalLength, TotalHeight, TotalWeight, DateTime.Now, StartAddress, StartPostalCode, StartCity, StartCountry, DateTime.Now, EndAddress, EndPostalCode, EndCity, EndCountry, TruckdriverId, Contactperson, Comment);
			//opretning af Truckdriver objekt
			Truckdriver truckdriver = new Truckdriver(Shared.UserUser, TruckdriverId, TruckdriverEMail);


			if (CreateBookingCheck(newBooking)) //Check af indtastning. f.eks. 8 tal i et telefonnummer og KUN tal.
			{
				await CreateTruckdriver(truckdriver); //kalder metoden som kalder Restworkeren.
				await CreateNewBooking(newBooking); //kalder metoden som kalder Restworkeren.
				await GetAllBookingAsync(); //Henter alle Bookings

				newBooking = GetNewBooking(_shared.UserUser); //Henter den nyoprettede Booking
				await NewCarBooking(newBooking.OrderNo); //kalder metode som opretter ny(e) CarBooking objekter.
				navigation.Navigate(typeof(View.DisplayBookingCompany));


			}
		}

		//Beskidt. Men det eneste unikke vi kender til, indtil den er hentet, er tidspunktet, da ordernummer bliver genereret i DB. Dårlig planlægning. 
		//Generering af primærnøgle i programmet i stedet for databasen ville det være nemmere at finde den Booking man lige har oprettet.
		private Booking GetNewBooking(int cvrNo)
		{
			Booking newBooking = new Booking();
			DateTime date = DateTime.MinValue;
			foreach (Booking booking in Bookings)
			{
				if (booking.CompanyCvrNo == cvrNo && booking.StartDate > date)
				{
					newBooking = booking;
					date = booking.StartDate;
				}
			}
			
			return newBooking;
		}

		private async Task<bool> NewCarBooking(int orderNo)
		{
			bool created = false;
			for (int i = 0; i < NumOfCarsNeeded; i++)
			{
				CarBooking newCarBooking = new CarBooking(orderNo); //opretter CarBooking med nuværende ordrenummer

				newCarBooking.CarId = 1; //Dummy Car bliver sat på nuværende Booking

				created = await CreateNewCarBooking(newCarBooking); //Kalder Restworker for at gemme nyt CarBooking objekt på databasen.

			}
			return created;
		}

		private async Task<bool> CreateNewBooking(Booking newBooking)
		{
			bool created = await restworker.CreateObjectAsync<Booking>(newBooking, Datastructures.TableName.Booking);
			return created;
		}

		private async Task<bool> CreateTruckdriver(Truckdriver truckdriver)
		{
			bool created = await restworker.CreateObjectAsync<Truckdriver>(truckdriver, Datastructures.TableName.Truckdriver);
			return created;
		}

		private async Task<bool> CreateNewCarBooking(CarBooking newCarBooking)
		{
			bool created = await restworker.CreateObjectAsync<CarBooking>(newCarBooking, Datastructures.TableName.CarBooking);
			return created;
		}

		#endregion

		#region RelayCommands
		public RelayCommand CreateBookingCompanyRC
		{
			get { return _createBookingCompany; }
		}

		#endregion
	}
}
