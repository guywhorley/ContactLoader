using System.Collections.Generic;

namespace ContactLoader
{
	/// <summary>Interface responsible for initiating the fetching of contact data.</summary>
	public interface IContactReader
	{
		/// <summary>Loads the contact data from source.</summary>
		/// <param name="source">The source.</param>
		/// <returns></returns>
		Contact[] LoadContactDataFromSource(string source);
	}
}