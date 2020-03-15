using ContactLoader;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactLoaderTests
{
	[TestClass()]
	public class ConcreteContactLoaderTests
	{
		private IContactReader reader;
		private ConcreteContactLoader ccLoader;

		[TestInitialize]
		public void SetupBeforeEachTest()
		{
			// Arrange
			reader = A.Fake<IContactReader>();
			A.CallTo(() => reader.LoadContactDataFromSource("")).Returns(GetTestContactData());
			ccLoader = new ConcreteContactLoader(reader);
		}

		[TestCleanup]
		public void CleanupAfterEachTest()
		{
			reader = null;
			ccLoader = null;
		}

		[TestMethod]
		public void ConcreteLoader_LoadContacts_CallToReader_Occured()
		{
			// Act
			Contact[] contacts = ccLoader.LoadContacts();

			// Assert
			A.CallTo(() => reader.LoadContactDataFromSource("")).MustHaveHappened();
		}


		[TestMethod()]
		public void ConcreteLoader_LoadContacts_HasCorrectCount()
		{
			// Act
			Contact[] contacts = ccLoader.LoadContacts();

			// Assert
			Assert.AreEqual(2, contacts.Length);
		}

		#region Utilities

		private Contact[] GetTestContactData()
		{
			return new[]
			{
				new Contact() {FirstName = "A",LastName =  "1", PhoneNumber = "111-111-1111"},
				new Contact() {FirstName = "B", LastName = "2", PhoneNumber = "222-222-2222"}
			};
		}

		#endregion
	}
}