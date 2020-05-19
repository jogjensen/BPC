using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BPCClassLibrary;

namespace BPCRESTService.Managers
{
    public class ManagerCarBooking
    {
        private const string connString = "Server=tcp:bpc-dbserver.database.windows.net,1433;Initial Catalog=bpc-db;Persist Security Info=False;User ID=bpc-adm;Password=Secret1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

		public IList<CarBooking> GetAllCarBookings()
		{
			List<CarBooking> carBookingList = new List<CarBooking>();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();

				using (SqlCommand command = new SqlCommand("Select * from CarBooking", conn))
				{
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						carBookingList.Add(ReadNextCarBooking(reader));
					}
				}
			}
			return carBookingList;
		}

		public CarBooking GetCarBookingFromId(int id)
		{
			CarBooking carBooking = new CarBooking();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();

				using (SqlCommand command = new SqlCommand("Select * from CarBooking where CarBookingId = @Id", conn))
				{
					command.Parameters.AddWithValue("@Id", id);
					SqlDataReader reader = command.ExecuteReader();
					if (reader.Read())
					{
						carBooking = ReadNextCarBooking(reader);
					}
				}
			}
			return carBooking;
		}

		public bool CreateCarBooking(CarBooking carBooking)
		{
			bool created = false;

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();

				using (SqlCommand command = new SqlCommand("Insert into CarBooking (CarBookingId, OrderNo) values(@CarBookingId, @OrderNo)", conn))
				{
					command.Parameters.AddWithValue("@CarBookingId", carBooking.Id);
					command.Parameters.AddWithValue("@TelephoneNo", truckdriver.TelephoneNo);

					int rows = command.ExecuteNonQuery();
					created = rows == 1;
				}
			}
			return created;
		}

		private CarBooking ReadNextCarBooking(SqlDataReader reader)
		{
			CarBooking carBooking = new CarBooking();

			carBooking.Id = reader.GetInt32(0);
			carBooking.OrderNo = reader.GetInt32(1);
			carBooking.Car = reader.GetInt32(2);

			return carBooking;
		}
	}
}
