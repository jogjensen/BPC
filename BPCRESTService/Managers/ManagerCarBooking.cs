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

				using (SqlCommand command = new SqlCommand("Insert into CarBooking ( OrderNo) values( @OrderNo)", conn))
				{
					//command.Parameters.AddWithValue("@CarBookingId", carBooking.CarBookingId);
					command.Parameters.AddWithValue("@OrderNo", carBooking.OrderNo);
					command.Parameters.AddWithValue("@CarId", carBooking.CarId);

					int rows = command.ExecuteNonQuery();
					created = rows == 1;
				}
			}
			return created;
		}

		public bool UpdateCarBooking(CarBooking carBooking, int id)
		{
			bool updated = false;

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();

				using (SqlCommand command = new SqlCommand("Update CarBooking set CarId = @Car, OrderNo = @OrderNo where CarBookingId = @Id", conn))
				{
					command.Parameters.AddWithValue("@Id", id);
					command.Parameters.AddWithValue("@Car", carBooking.CarId);
					command.Parameters.AddWithValue("@OrderNo", carBooking.OrderNo);

					int rows = command.ExecuteNonQuery();
					updated = rows == 1;
				}
			}
			return updated;
		}

		public CarBooking DeleteCarBooking(int id)
		{
			CarBooking carBooking = GetCarBookingFromId(id);

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();

				using (SqlCommand command = new SqlCommand("Delete from CarBooking where CarBookingId = @Id", conn))
				{
					command.Parameters.AddWithValue("@Id", id);
					command.ExecuteNonQuery();
				}
			}
			return carBooking;
		}

		private CarBooking ReadNextCarBooking(SqlDataReader reader)
		{
			CarBooking carBooking = new CarBooking();

			carBooking.CarBookingId = reader.GetInt32(0);
			carBooking.OrderNo = reader.GetInt32(1);
			carBooking.CarId = reader.GetInt32(2);

			return carBooking;
		}
	}
}
