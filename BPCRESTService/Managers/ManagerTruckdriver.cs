using BPCClassLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BPCRESTService.Managers
{
    public class ManagerTruckdriver
    {
        private const string connString = "Server=tcp:bpc-dbserver.database.windows.net,1433;Initial Catalog=bpc-db;Persist Security Info=False;User ID=bpc-adm;Password=Secret1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //private const string connString = "Data Source=bpc-dbserver.database.windows.net;Initial Catalog=bpc-db;User ID=bpc-adm;Password=Secret1234;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IList<Truckdriver> GetAllTruckdrivers()
        {
            List<Truckdriver> truckdriverList = new List<Truckdriver>();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("Select * from Truckdriver", conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        truckdriverList.Add(ReadNextTruckdriver(reader));
                    }
                }
            }
            return truckdriverList;
        }

        public Truckdriver GetDriverFromId(int id)
        {
            Truckdriver truckdriver = new Truckdriver();

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("Select * from Truckdriver where telephoneNo = @Id", conn))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        truckdriver = ReadNextTruckdriver(reader);
                    }
                }
            }
            return truckdriver;
        }

        public bool CreateDriver(Truckdriver truckdriver)
        {
            bool created = false;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("Insert into Truckdriver (TruckdriverId, TelephoneNo, EMail) values(@Id, @TelephoneNo, @EMail)", conn))
                {
                    command.Parameters.AddWithValue("@Id", truckdriver.TruckdriverId);
                    command.Parameters.AddWithValue("@TelephoneNo", truckdriver.TelephoneNo);
                    command.Parameters.AddWithValue("@EMail", truckdriver.EMail);

                    int rows = command.ExecuteNonQuery();
                    created = rows == 1;
                }
            }
            return created;
        }

        public bool UpdateTruckdriver(Truckdriver truckdriver, int id)
        {
            bool updated = false;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                
                using (SqlCommand command = new SqlCommand("Update Truckdriver set EMail = @Mail, TruckdriverId = @TDID where TelephoneNo = @Id", conn))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@TDID", truckdriver.TruckdriverId);
                    command.Parameters.AddWithValue("@Mail", truckdriver.EMail);

                    int rows = command.ExecuteNonQuery();
                    updated = rows == 1;
                }
            }
            return updated;
        }

        public Truckdriver DeleteDriver(int id)
        {
            Truckdriver truckdriver = GetDriverFromId(id);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                using (SqlCommand command = new SqlCommand("Delete from Truckdriver where telephoneNo = @Id", conn))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
            return truckdriver;
        }

        private Truckdriver ReadNextTruckdriver(SqlDataReader reader)
        {
            Truckdriver truckdriver = new Truckdriver();

            truckdriver.TruckdriverId = reader.GetInt32(0);
            truckdriver.TelephoneNo = reader.GetInt32(1);
            truckdriver.EMail = reader.GetString(2);
            
            return truckdriver;
        }
    }
}
