using System;
using System.IO;

namespace CSharpRolodex
{
	public class AddressBook
	{
		private static string AddressBookFileLocation;

		public AddressBook (string filePath)
		{
			AddressBookFileLocation = filePath;
		}

		public void WriteToAddressBook (string lineToWrite)
		{
			using (StreamWriter w = File.AppendText (AddressBookFileLocation)) {
				w.WriteLine (lineToWrite);
			}
		}

		public string[] ReturnAllContacts ()
		{
			return File.ReadAllLines (AddressBookFileLocation);
		}

		public void DeleteFromAddressBook (string contactToDelete)
		{
			string[] allContacts = ReturnAllContacts ();
			File.WriteAllText (AddressBookFileLocation, string.Empty);
			foreach (string contact in allContacts) {
				if (!contact.Contains (contactToDelete.ToUpper ())) {
					WriteToAddressBook (contact);
				}
			}

		}
	}
}

