using FakeItEasy;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactLoader.Tests
{
	[TestClass()]
	public class ConcreteContactLoaderTests
	{
		private IContactReader reader;

		[TestInitialize]
		public void SetupBeforeEachTest()
		{
			// Arrange
			reader = A.Fake<IContactReader>();
			A.CallTo(() => reader.LoadContactDataFromSource("")).Returns(GetTestContactData());
		}

		[TestMethod]
		public void ConcreteLoader_LoadContacts_CallToReader_Occured()
		{
			// Arrange
			ConcreteContactLoader ccLoader = new ConcreteContactLoader(reader);

			// Act
			Contact[] contacts = ccLoader.LoadContacts();

			// Assert
			A.CallTo(() => reader.LoadContactDataFromSource("")).MustHaveHappened();
		}


		[TestMethod()]
		public void ConcreteLoader_LoadContacts_HasCorrectCount()
		{
			// Arrange
			ConcreteContactLoader ccLoader = new ConcreteContactLoader(reader);

			// Act
			Contact[] contacts = ccLoader.LoadContacts();

			// Assert
			Assert.AreEqual(2, contacts.Length);
		}

		#region Utilities

		private Contact[] GetTestContactData()
		{
			return new Contact[]
			{
				new Contact() {FirstName = "A",LastName =  "1", PhoneNumber = "111-111-1111"},
				new Contact() {FirstName = "B", LastName = "2", PhoneNumber = "222-222-2222"}
			};
		}

		#endregion
	}
}