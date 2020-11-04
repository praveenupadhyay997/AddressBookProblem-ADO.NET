// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
using System;

namespace AddressBookServices
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================================================");
            Console.WriteLine("Welcome to the Address Book Data Retrieval Program");
            Console.WriteLine("==================================================");
            AddressBookRepository repository = new AddressBookRepository();
            repository.EnsureDataBaseConnection();
            Console.ReadKey();
            /// UC1 -- Getting all the records from the address book table
            repository.GetAllRecords();
        }
    }
}
