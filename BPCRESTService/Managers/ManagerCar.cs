﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BPCClassLibrary;

namespace BPCRESTService.Managers
{
	public class ManagerCar
	{
        private const string connString = "SData Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BPCDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		#region Get/Post/Put/Delete

		public IList<Car> GetAllCars()
		{
			List<Car> carList = new List<Car>();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();

				using (SqlCommand command = new SqlCommand("Select * from Car", conn))
				{
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						carList.Add(ReadNextCar(reader));
					}
				}
			}
			return carList;
		}

		public Car GetCarFromName(int id)
		{
			Car car = new Car();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
						
				using (SqlCommand command = new SqlCommand("Select * from Car where CarId = @Id", conn))
				{
					command.Parameters.AddWithValue("@Id", id);
					SqlDataReader reader = command.ExecuteReader();
					if (reader.Read())
					{
						car = ReadNextCar(reader);
					}
				}
			}

			return car;
		}

		public bool CreateCar(Car car)
		{
			bool created = false;

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				
				using (SqlCommand command = new SqlCommand("Insert into Car (FirstName, LastName, CvrNo, Email, TelephoneNo, MobileNo, Address, Postalcode, City, Country, Password) " +
																	"values (@FirstName, @LastName, @CvrNo, @Email, @TelephoneNo, @MobileNo, @Address, @PostalCode, @City, @Country, @Password)", conn))
				{
					//command.Parameters.AddWithValue("@Id", car.Id);
					command.Parameters.AddWithValue("@FirstName", car.FirstName);
					command.Parameters.AddWithValue("@LastName", car.LastName);
					command.Parameters.AddWithValue("@CvrNo", car.CvrNo);
					command.Parameters.AddWithValue("@Email", car.EMail);
					command.Parameters.AddWithValue("@TelephoneNo", car.TelephoneNo);
					command.Parameters.AddWithValue("@MobileNo", car.MobileNo);
					command.Parameters.AddWithValue("@Address", car.Address);
					command.Parameters.AddWithValue("@PostalCode", car.PostalCode);
					command.Parameters.AddWithValue("@City", car.City);
					command.Parameters.AddWithValue("@Country", car.Country);
					command.Parameters.AddWithValue("@Password", car.Password);

					int rows = command.ExecuteNonQuery();
					created = rows == 1;
				}
			}

			return created;
		}

		public bool UpdateCar(Car car, int id)
		{
			bool updated = false;

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();
				
				using (SqlCommand command = new SqlCommand("Update Car set Password = @Password, Country = @Country, City = @City, " +
															"CvrNo = @CvrNo, Email = @EMail, TelephoneNo = @TelephoneNo, MobileNo = @MobileNo, " +
															"Address = @Address, Postalcode = @PostalCode where CarId = @Id", conn))
				{
					command.Parameters.AddWithValue("@Id", id);
					command.Parameters.AddWithValue("@FirstName", car.FirstName);
					command.Parameters.AddWithValue("@LastName", car.LastName);
					command.Parameters.AddWithValue("@CvrNo", car.CvrNo);
					command.Parameters.AddWithValue("@EMail", car.EMail);
					command.Parameters.AddWithValue("@TelephoneNo", car.TelephoneNo);
					command.Parameters.AddWithValue("@MobileNo", car.MobileNo);
					command.Parameters.AddWithValue("@Address", car.Address);
					command.Parameters.AddWithValue("@PostalCode", car.PostalCode);
					command.Parameters.AddWithValue("@City", car.City);
					command.Parameters.AddWithValue("@Country", car.Country);
					command.Parameters.AddWithValue("@Password", car.Password);

					int rows = command.ExecuteNonQuery();
					updated = rows == 1;
				}
			}
			return updated;
		}

		public Car DeleteCar(int id)
		{
			Car car = GetCarFromName(id);

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();

				using (SqlCommand command = new SqlCommand("Delete from Car where CarId = @Id", conn))
				{
					command.Parameters.AddWithValue("@Id", id);
					command.ExecuteNonQuery();
				}
			}
			return car;
		}

		private Car ReadNextCar(SqlDataReader reader)
		{
			Car car = new Car();

			car.Id = reader.GetInt32(0);
			car.FirstName = reader.GetString(1);
			car.LastName = reader.GetString(2);
			car.CvrNo = reader.GetInt32(3);
			car.EMail = reader.GetString(4);
			car.TelephoneNo = reader.GetString(5);
			car.MobileNo = reader.GetString(6);
			car.Address = reader.GetString(7);
			car.PostalCode = reader.GetString(8);
			car.City = reader.GetString(9);
			car.Country = reader.GetString(10);
			car.Password = reader.GetString(11);

			return car;
		}
		#endregion
	}
}
