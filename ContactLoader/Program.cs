using System;
using System.Collections.Generic;
using System.IO;

namespace ContactLoader
{
	class Program
	{
		private static Contact[] contacts;

		static void Main(string[] args)
		{
			InitializeAllContacts();
			DisplayEachContact();
		}

		private static void InitializeAllContacts()
		{
			IContactLoader loader = new ConcreteContactLoader(new LocalCsvFileReader());
			contacts = loader.LoadContacts();
		}

		private static void DisplayEachContact()
		{
			foreach (var person in contacts)
			{
				Console.WriteLine($"Person: {person}");
			}
		}
	}
}
