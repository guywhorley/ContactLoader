using System;
using System.Collections.Generic;
using System.IO;

namespace ContactLoader
{
	class Program
	{
		private static Contact[] contacts;
		private const string fileName = @"C:\Users\guy.whorley.CHERWELL\source\repos\ContactLoader\ContactLoader\Data\contacts.csv";

		static void Main(string[] args)
		{
			InitializeAllContacts();
			foreach (Contact person in contacts)
			{
				Console.WriteLine($"Person: {person}");
			}
		}

		private static void InitializeAllContacts()
		{
			// TODO: (gcw) Refactor for test supportability.
			contacts = GetContactsFromCsvFile(fileName);
		}

		private static Contact[] GetContactsFromCsvFile(string fileName)
		{
			if (String.IsNullOrEmpty(fileName))
				throw new ArgumentNullException("Filename cannot be null.");

			if (File.Exists(fileName)==false)
				throw new FileNotFoundException();

			List<Contact> people = new List<Contact>();

			try
			{
				using (StreamReader sr = new StreamReader(fileName))
				{
					string line;
					// Read a file-line and assign it to line. If null then stop
					// Precondition - first line of file must be a header.
					sr.ReadLine();

					while ( (line = sr.ReadLine()) != null )
					{
						// TODO: (gcw) Refactor?? Add checks for missing parts.
						string[] parts = line.Split(',');
						people.Add(new Contact
						{
							FirstName = parts[0].Trim(),
							LastName = parts[1].Trim(),
							PhoneNumber = parts[2].Trim()
						});
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"File could not be read! {ex.Message}");
			}

			// TODO: (gcw) Refactor? Do I need an array?
			return people.ToArray();
		}
	}
}
