using System;
using System.Collections;

namespace ContactLoader
{
	public class Contact
	{
		public Contact(string firstName = "not provided", string lastName = "not provided", string phoneNumber = "not provided")
		{
			FirstName = firstName;
			LastName = lastName;
			PhoneNumber = phoneNumber;
		}

		/// <summary>Contacts first name</summary>
		public string FirstName { get; set; }

		/// <summary>Contacts' last name.</summary>
		public string LastName { get; set; }

		/// <summary>Phone number.</summary>
		public string PhoneNumber { get; set; }

		/// <summary>Converts to string.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString()
		{
			return $"{{First:{FirstName}, Last:{LastName}, Phone:{PhoneNumber}}}";
		}
	}
}