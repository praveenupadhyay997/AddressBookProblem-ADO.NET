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
        public static AddressBookModel bookModel = new AddressBookModel();
        /// <summary>
        /// Method to take the input for the new records
        /// </summary>
        public static void TakeInputOfRecords()
        {
            Console.WriteLine("Enter the First Name :");
            bookModel.firstName = Console.ReadLine();
            Console.WriteLine("Enter the Second Name :");
            bookModel.secondName = Console.ReadLine();
            Console.WriteLine("Enter the Address :");
            bookModel.address = Console.ReadLine();
            Console.WriteLine("Enter the City :");
            bookModel.city = Console.ReadLine();
            Console.WriteLine("Enter the State :");
            bookModel.state = Console.ReadLine();
            Console.WriteLine("Enter the Zip :");
            bookModel.zip = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter the Phone Number :");
            bookModel.phoneNumber = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Enter the email-id :");
            bookModel.emailId = Console.ReadLine();
            Console.WriteLine("Enter the contact type :");
            bookModel.contactType = Console.ReadLine();
            Console.WriteLine("Enter the address book name :");
            bookModel.addressBookName = Console.ReadLine();
        }
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
            /// UC2 -- Insert a record to the address book
            TakeInputOfRecords();
            /// Testing for the success of the insertion to the table
            Console.WriteLine(repository.AddDataToTable(bookModel)? "Inserted Successfully": "Insert failed");
        }
    }
}
