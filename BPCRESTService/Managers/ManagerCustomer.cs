using BPCClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BPCRESTService.Managers
{

	//Philip koder 

	public class ManagerCustomer
	{
		private const string connString = "Server=tcp:bpc-dbserver.database.windows.net,1433;Initial Catalog=bpc-db;Persist Security Info=False;User ID=bpc-adm;Password=Secret1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

		#region GetAllCustomers
		public IList<Customer> GetAllCustomers()
		{
			List<Customer> customerList = new List<Customer>();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();

				using (SqlCommand command = new SqlCommand("Select * from Customer", conn))
				{
					SqlDataReader reader = command.ExecuteReader();
					while (reader.Read())
					{
						customerList.Add(ReadNextCustomer(reader));
					}
				}
			}
			return customerList;
		}
		#endregion

		#region GetCustomerFromName
		public Customer GetCustomerFromName(string companyName)
		{
			Customer customer = new Customer();

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();

				using (SqlCommand command = new SqlCommand("Select * from Customer where CompanyName = @CompanyName", conn))
				{
					command.Parameters.AddWithValue("@CompanyName", companyName);
					SqlDataReader reader = command.ExecuteReader();
					if (reader.Read())
					{
						customer = ReadNextCustomer(reader);
					}
				}
			}
			return customer;
		}
		#endregion

		#region CreateCustomer
		public bool CreateCustomer(Customer customer)
		{
			bool created = false;

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();

				using (SqlCommand command = new SqlCommand("Insert into Customer (CompanyName, CvrNo, Email, TelephoneNo, MobileNo, Address, PostalCode, Country, Password, Truckdriver) values(@CompanyName, @CvrNo, @EMail, @TelephoneNo, @MobileNo, @Address, @PostalCode, @Country, @Password, @Truckdriver)", conn))
				{
					command.Parameters.AddWithValue("@Companyname", customer.CompanyName);
					command.Parameters.AddWithValue("@CvrNo", customer.CvrNo);
					command.Parameters.AddWithValue("@EMail", customer.EMail);
					command.Parameters.AddWithValue("@TelephoneNo", customer.TelephoneNo);
					command.Parameters.AddWithValue("@MobileNo", customer.MobileNo);
					command.Parameters.AddWithValue("@Address", customer.Address);
					command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
					command.Parameters.AddWithValue("@Country", customer.Country);
					command.Parameters.AddWithValue("@Password", customer.Password);
					command.Parameters.AddWithValue("@Truckdriver", customer.Truckdriver);

					int rows = command.ExecuteNonQuery();
					created = rows == 1;
				}
			}
			return created;
		}
		#endregion

		#region UpdateCustomer
		public bool UpdateCustomer(Customer customer, string companyName)
		{
			bool updated = false;

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();

				using (SqlCommand command = new SqlCommand("Update Customer set CvrNo = @CvrNo, Email = @EMail, TelephoneNo = @TelephoneNo, MobileNo = @MobileNo, Address = @Address, PostalCode = @PostalCode, Country = @Country, Password = @Password, Truckdriver = @Truckdriver where CompanyName = @companyName", conn))
				{
					command.Parameters.AddWithValue("@Companyname", customer.CompanyName);
					command.Parameters.AddWithValue("@CvrNo", customer.CvrNo);
					command.Parameters.AddWithValue("@EMail", customer.EMail);
					command.Parameters.AddWithValue("@TelephoneNo", customer.TelephoneNo);
					command.Parameters.AddWithValue("@MobileNo", customer.MobileNo);
					command.Parameters.AddWithValue("@Address", customer.Address);
					command.Parameters.AddWithValue("@PostalCode", customer.PostalCode);
					command.Parameters.AddWithValue("@Country", customer.Country);
					command.Parameters.AddWithValue("@Password", customer.Password);
					command.Parameters.AddWithValue("@Truckdriver", customer.Truckdriver);

					int rows = command.ExecuteNonQuery();
					updated = rows == 1;
				}
			}
			return updated;
		}
		#endregion

		#region DeleteCustomer
		public Customer DeleteCustomer(string companyName)
		{
			Customer customer = GetCustomerFromName(companyName);

			using (SqlConnection conn = new SqlConnection(connString))
			{
				conn.Open();

				using (SqlCommand command = new SqlCommand("Delete from Customer where companyName = @companyName", conn))
				{
					command.Parameters.AddWithValue("@companyName", companyName);
					command.ExecuteNonQuery();
				}
			}
			return customer;
		}
		#endregion

		private Customer ReadNextCustomer(SqlDataReader reader)
		{
			Customer customer = new Customer();

			customer.CompanyName = reader.GetString(0);
			customer.CvrNo = reader.GetInt32(1);
			customer.EMail = reader.GetString(2);
			customer.TelephoneNo = reader.GetString(3);
			customer.MobileNo = reader.GetString(4);
			customer.Address = reader.GetString(5);
			customer.PostalCode = reader.GetString(6);
			customer.Country = reader.GetString(7);
			customer.Password = reader.GetString(8);
			customer.Truckdriver = reader.GetInt32(9);

			return customer;
		}
	}
}
