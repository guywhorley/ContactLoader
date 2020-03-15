using System;
using System.Collections.Generic;
using System.IO;

namespace ContactLoader
{
	/// <summary>Load contact data from a local CSV file.</summary>
	/// <seealso cref="IContactReader" />
	public class LocalCsvFileReader : IContactReader
	{
		private const string fileName = @"C:\Users\guy.whorley.CHERWELL\source\repos\ContactLoader\ContactLoader\Data\contacts.csv";

		/// <summary>Loads the contact data from specified filename.</summary>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException">Filename cannot be null.</exception>
		/// <exception cref="FileNotFoundException"></exception>
		public Contact[] LoadContactDataFromSource(string source = fileName)
		{
			if (string.IsNullOrEmpty(source))
				source = fileName; // Default to expected fileName.

			if (!File.Exists(source))
				throw new FileNotFoundException();

			var people = new List<Contact>();

			try
			{
				using var sr = new StreamReader(source);
				string line;
				// Read a file-line and assign it to line. If null then stop
				// Precondition - first line of file must be a header.
				sr.ReadLine();

				while ((line = sr.ReadLine()) != null)
				{
					// TODO: (gcw) Refactor?? Add checks for missing parts.
					var parts = line.Split(',');
					people.Add(new Contact
					{
						FirstName = parts[0].Trim(),
						LastName = parts[1].Trim(),
						PhoneNumber = parts[2].Trim()
					});
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