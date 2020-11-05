// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddressBookModel.cs" company="Bridgelabz">
//   Copyright © 2018 Company
// </copyright>
// <creator Name="Praveen Kumar Upadhyay"/>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookServices
{
    /// <summary>
    /// Class to map the relational data base model to a entity
    /// Contains fields mimicing the exact replica of that of the table level
    /// </summary>
    class AddressBookModel
    {
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public long zip { get; set; }
        public long phoneNumber { get; set; }
        public string emailId { get; set; }
        public string contactType { get; set; }
        public string addressBookName { get; set; }
    }
}
