using System;
using System.Collections.Generic;
using System.Text;

namespace ContactLoader
{
	/// <summary>The class responsible for reading contacts from the contact data source.</summary>
	/// <seealso cref="ContactLoader.IContactLoader" />
	public class ConcreteContactLoader : IContactLoader
	{
		private readonly IContactReader _contactReader;

		/// <summary> Initializes a new instance of the <see cref="ConcreteContactLoader"/> class.</summary>
		/// <param name="contactReader"><see cref="IContactReader"/></param>
		public ConcreteContactLoader(IContactReader contactReader)
		{
			_contactReader = contactReader;
		}

		public Contact[] LoadContacts(string source = "")
		{
			return _contactReader.LoadContactDataFromSource(source);

		}
	}
}
