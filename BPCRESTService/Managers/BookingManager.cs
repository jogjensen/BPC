using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BPCClassLibrary;


namespace BPCRESTService.Managers
{
	public class BookingManager
	{
		private const string connString = "Server=tcp:bpc-dbserver.database.windows.net,1433;Initial Catalog=bpc-db;Persist Security Info=False;User ID=bpc-adm;Password=Secret1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public IList<Booking> GetAllBookings()
      {
         List<Booking> bookingList = new List<Booking>();

         using (SqlConnection conn = new SqlConnection(connString))
         {
            conn.Open();

            using (SqlCommand command = new SqlCommand("Select * from Booking", conn))
            {
               SqlDataReader reader = command.ExecuteReader();
               while (reader.Read())
               {
                  bookingList.Add(ReadNextBooking(reader));
               }
            }
         }
         return bookingList;
      }

      public Booking GetBookingFromId(int bookingId)
      {
         Booking booking = new Booking();

         using (SqlConnection conn = new SqlConnection(connString))
         {
            conn.Open();

            using (SqlCommand command = new SqlCommand("Select * from Booking where OrderNo = @Id", conn))
            {
               command.Parameters.AddWithValue("@Id", bookingId);
               SqlDataReader reader = command.ExecuteReader();
               if (reader.Read())
               {
                  booking = ReadNextBooking(reader);
               }
            }
         }
         return booking;
      }

      public bool CreateBooking(Booking booking)
      {
         bool created = false;

         using (SqlConnection conn = new SqlConnection(connString))
         {
            conn.Open(); //åbner forbindelse til databasen

            using (SqlCommand command = new SqlCommand("Insert into Booking (Status, CompanyCvrNo, NumOfCarsNeeded, Comment, TypeOfGoods, TotalWidth, TotalLength, TotalHeight, TotalWeight, StartDate, StartAddress, StartPostalCode, StartCountry, EndDate, EndAddress, EndPostalCode, EndCountry, TruckdriverId, ContactPerson, StartCity, EndCity) " +
                                                                    "values(@Status, @CompanyCvrNo, @NumOfCarsNeeded, @Comment, @TypeOfGoods, @TotalWidth, @TotalLength, @TotalHeight, @TotalWeight, @StartDate, @StartAddress, @StartPostalCode, @StartCountry, @EndDate, @EndAddress, @EndPostalCode, @EndCountry, @Truckdriver, @ContactPerson, @StartCity, @EndCity)", conn))
            {
	            //command.Parameters.AddWithValue("@OrderNo", booking.OrderNo);
	            command.Parameters.AddWithValue("@Status", (int)booking.Status);
	            command.Parameters.AddWithValue("@CompanyCvrNo", booking.CompanyCvrNo);
	            command.Parameters.AddWithValue("@NumOfCarsNeeded", booking.NumOfCarsNeeded);
	            command.Parameters.AddWithValue("@Comment", booking.Comment);
	            command.Parameters.AddWithValue("@TypeOfGoods", booking.TypeOfGoods);
	            command.Parameters.AddWithValue("@TotalWidth", booking.TotalWidth);
	            command.Parameters.AddWithValue("@TotalLength", booking.TotalLength);
	            command.Parameters.AddWithValue("@TotalHeight", booking.TotalHeight);
	            command.Parameters.AddWithValue("@TotalWeight", booking.TotalWeight);
	            command.Parameters.AddWithValue("@StartDate", booking.StartDate);
	            command.Parameters.AddWithValue("@StartAddress", booking.StartAddress);
	            command.Parameters.AddWithValue("@StartPostalCode", booking.StartPostalCode);
	            command.Parameters.AddWithValue("@StartCountry", booking.StartCountry);
	            command.Parameters.AddWithValue("@EndDate", booking.EndDate);
	            command.Parameters.AddWithValue("@EndAddress", booking.EndAddress);
	            command.Parameters.AddWithValue("@EndPostalCode", booking.EndPostalCode);
	            command.Parameters.AddWithValue("@EndCountry", booking.EndCountry);
	            command.Parameters.AddWithValue("@Truckdriver", booking.TruckDriverId);
	            command.Parameters.AddWithValue("@ContactPerson", booking.ContactPerson);
                command.Parameters.AddWithValue("@StartCity", booking.StartCity);
                command.Parameters.AddWithValue("@EndCity", booking.EndCity);

               int rows = command.ExecuteNonQuery(); //Eksekvering af NonQuery (SQL command)
               created = rows == 1; //sand hvis ændrede rækker i databasen er 1.
            }
         }
         return created;
      }

      public bool UpdateBooking(Booking booking, int id)
      {
         bool updated = false;

         using (SqlConnection conn = new SqlConnection(connString))
         {
            conn.Open();

            using (SqlCommand command = new SqlCommand("Update Booking set Status = @Status, CompanyCvrNo = @Company, NumOfCarsNeeded = @NumOfCarsNeeded, Comment = @Comment," +
                " TypeOfGoods = @TypeOfGoods, TotalWidth = @TotalWidth, TotalLength = @TotalLength, TotalHeight = @TotalHeight, TotalWeight = @TotalWeight," +
                " StartDate = @StartDate, StartAddress = @StartAddress, StartPostalCode = @StartPostalCode, StartCity = @StartCity, StartCountry = @StartCountry," +
                " EndDate = @EndDate, EndAddress = @EndAddress, EndPostalCode = @EndPostalCode, EndCity = @EndCity, EndCountry = @EndCountry, TruckdriverId = @Truckdriver, " +
                "ContactPerson = @ContactPerson where OrderNo = @OrderNo", conn))
            {
	            command.Parameters.AddWithValue("@OrderNo", id);
	            command.Parameters.AddWithValue("@Status", (int)booking.Status);
	            command.Parameters.AddWithValue("@Company", booking.CompanyCvrNo);
	            command.Parameters.AddWithValue("@NumOfCarsNeeded", booking.NumOfCarsNeeded);
	            command.Parameters.AddWithValue("@Comment", booking.Comment);

	            command.Parameters.AddWithValue("@TypeOfGoods", booking.TypeOfGoods);
	            command.Parameters.AddWithValue("@TotalWidth", booking.TotalWidth);
	            command.Parameters.AddWithValue("@TotalLength", booking.TotalLength);
	            command.Parameters.AddWithValue("@TotalHeight", booking.TotalHeight);
	            command.Parameters.AddWithValue("@TotalWeight", booking.TotalWeight);

	            command.Parameters.AddWithValue("@StartDate", booking.StartDate);
	            command.Parameters.AddWithValue("@StartAddress", booking.StartAddress);
	            command.Parameters.AddWithValue("@StartPostalCode", booking.StartPostalCode);
                command.Parameters.AddWithValue("@StartCity", booking.StartCity);
	            command.Parameters.AddWithValue("@StartCountry", booking.StartCountry);

	            command.Parameters.AddWithValue("@EndDate", booking.EndDate);
	            command.Parameters.AddWithValue("@EndAddress", booking.EndAddress);
	            command.Parameters.AddWithValue("@EndPostalCode", booking.EndPostalCode);
	            command.Parameters.AddWithValue("@EndCity", booking.EndCity);
	            command.Parameters.AddWithValue("@EndCountry", booking.EndCountry);

	            command.Parameters.AddWithValue("@Truckdriver", booking.TruckDriverId);
	            command.Parameters.AddWithValue("@ContactPerson", booking.ContactPerson);

               int rows = command.ExecuteNonQuery();
               updated = rows == 1;
            }
         }
         return updated;
      }

      public Booking DeleteBooking(int id)
      {
         Booking booking = GetBookingFromId(id);

         using (SqlConnection conn = new SqlConnection(connString))
         {
            conn.Open();

            using (SqlCommand command = new SqlCommand("Delete from Booking where OrderNo = @OrderNo", conn))
            {
               command.Parameters.AddWithValue("@OrderNo", id);
               command.ExecuteNonQuery();
            }
         }
         return booking;
      }

      private Booking ReadNextBooking(SqlDataReader reader)
      {
         Booking booking = new Booking();

         booking.OrderNo = reader.GetInt32(0);
         booking.Status = (Datastructures.Status) reader.GetInt32(1);
         booking.CompanyCvrNo = reader.GetInt32(2);
         booking.NumOfCarsNeeded = reader.GetInt32(3);

         booking.StartDate = reader.GetDateTime(4);
         booking.StartAddress = reader.GetString(5);
         booking.StartPostalCode = reader.GetString(6);
         booking.StartCity = reader.GetString(7);
         booking.StartCountry = reader.GetString(8);
         

         booking.TypeOfGoods = reader.GetString(9);
         booking.TotalWidth = reader.GetDouble(10);
         booking.TotalLength = reader.GetDouble(11);
         booking.TotalHeight = reader.GetDouble(12);
         booking.TotalWeight = reader.GetDouble(13);


         booking.EndDate = reader.GetDateTime(14);
         booking.EndAddress = reader.GetString(15);
         booking.EndPostalCode = reader.GetString(16);
         booking.EndCity = reader.GetString(17);
         booking.EndCountry = reader.GetString(18);

         booking.Comment = reader.GetString(19);
         
         booking.TruckDriverId = reader.GetInt32(20);
         booking.ContactPerson = reader.GetString(21);

         return booking;
      }
   }
}
