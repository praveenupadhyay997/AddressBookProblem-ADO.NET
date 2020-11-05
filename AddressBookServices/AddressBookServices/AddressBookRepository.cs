// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBookRepository.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AddressBookServices
{
    /// <summary>
    /// Class to execute the ado.net query implementation on the underlying sql database
    /// Using the Data.SqlClient package to establish connections
    /// Using Sql Connection as records are limited in number
    /// </summary>
    public class AddressBookRepository
    {
        // <summary>
        /// For ensuring the established connection using the Sql Connection specifying the property
        /// </summary>
        public static SqlConnection connectionToServer { get; set; }
        /// <summary>
        /// Method to check whether the connection is properly initialised or not
        /// </summary>
        public void EnsureDataBaseConnection()
        {
            /// Creates a new connection for every method to avoid "ConnectionString property not initialized" exception
            DBConnection dbc = new DBConnection();
            /// Calling the Get connection method to establish the connection to the Sql Server
            connectionToServer = dbc.GetConnection();
            using (connectionToServer)
            {
                Console.WriteLine("The Connection is created");
            }
            connectionToServer.Close();
        }
        /// <summary>
        /// UC1-- Getting all the stored records in the address book service table by fetching all the records
        /// </summary>
        public void GetAllRecords()
        {
            /// Creates a new connection for every method to avoid "ConnectionString property not initialized" exception
            DBConnection dbc = new DBConnection();
            /// Calling the Get connection method to establish the connection to the Sql Server
            connectionToServer = dbc.GetConnection();
            /// Creating the address book model class object
            AddressBookModel bookModel = new AddressBookModel();
            try
            {
                using (connectionToServer)
                {
                    /// Query to get all the data from the table
                    string query = @"select * from addressBookDatabase";
                    /// Impementing the command on the connection fetched database table
                    
                    SqlCommand command = new SqlCommand(query, connectionToServer);
                    /// Opening the connection to start mapping
                    connectionToServer.Open();
                    /// executing the sql data reader to fetch the records
                    SqlDataReader reader = command.ExecuteReader();
                    /// executing for not null
                    if (reader.HasRows)
                    {
                        /// Moving to the next record from the table
                        /// Mapping the data to the employee model class object
                        while (reader.Read())
                        {
                            bookModel.firstName = reader.GetString(0);
                            bookModel.secondName= reader.GetString(1);
                            bookModel.address = reader.GetString(2);
                            bookModel.city = reader.GetString(3);
                            bookModel.state = reader.GetString(4);
                            bookModel.zip = reader.GetInt64(5);
                            bookModel.phoneNumber = reader.GetInt64(6);
                            bookModel.emailId = reader.GetString(7);
                            bookModel.contactType = reader.GetString(8);
                            bookModel.addressBookName = reader.GetString(9);
                            Console.WriteLine($"First Name:{bookModel.firstName}\nSecond Name:{bookModel.secondName}\n" +
                                $"Address:{bookModel.address}, {bookModel.city}, {bookModel.state} PinCode: {bookModel.zip}\n" +
                                $" Phone Number: {bookModel.phoneNumber}\n Contact Type: {bookModel.contactType}\n Address Book Name : {bookModel.addressBookName}");
                            Console.WriteLine("\n\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found");
                    }
                    reader.Close();
                }
            }
            /// Catching the null record exception
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            /// Alway ensuring the closing of the connection
            finally
            {
                connectionToServer.Close();
            }
        }
    }
}
