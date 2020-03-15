namespace ContactLoader
{
	/// <summary>
	/// Interface defining the top-level loading of contact data.
	/// </summary>
	public interface IContactLoader
	{

		/// <summary>Loads the contacts from specified source or default data source if source is not specified.</summary>
		/// <returns></returns>
		Contact[] LoadContacts(string source = "");
	}
}