// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.ComponentModel;

namespace AddressBookServices
{
    class Program
    {
        public static AddressBookRepository repository = new AddressBookRepository();
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
        /// <summary>
        /// Method to take input to update the record inside the address book with help of name passed
        /// </summary>
        public static void UpdateCall()
        {
            Console.WriteLine("Enter the name of the record to edit.");
            string recordName = Console.ReadLine();
            Console.WriteLine("Enter the choice you want to update ===>");
            Console.WriteLine("1.Contact Type.");
            Console.WriteLine("2.Address Book Name.");
            int choice = Convert.ToInt32(Console.ReadLine());
            bool result = false;
            switch(choice)
            {
                case 1:
                    Console.WriteLine("Enter the new contact type (Friends,Family and Profession) -");
                    string type = Console.ReadLine();
                    result = repository.EditContactUsingName(recordName, type, choice);
                        break;
                case 2:
                    Console.WriteLine("Enter the address book name -");
                    string addressBookName = Console.ReadLine();
                    result = repository.EditContactUsingName(recordName, addressBookName, choice);
                    break;

                default:
                    Console.WriteLine("Entered choice is wrong.....");
                    break;
            }
            /// Testing for the success of the update to the table
                Console.WriteLine((result)? "Updated Successfully": "Update failed");
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
            Console.WriteLine(repository.AddDataToTable(bookModel) ? "Inserted Successfully" : "Insert failed");
            /// UC3 -- Update a record to the address book
            UpdateCall();
            /// UC4 -- Delete a record from the table
            Console.WriteLine(repository.DeleteContactUsingName() ? "Deleted Successfully" : "Delete failed");
        }
    }
}
