using System;
using System.Collections.Generic;

namespace CSharpRolodex
{
	public class RolodexAi
	{
		TextFileWriter addressBook = new TextFileWriter (@"../../AddressBook.txt");

		public List<string> AllContacts ()
		{
			List<string> allContacts = new List<string> ();
			string[] allContactsList = addressBook.ReturnAllLines ();
			foreach (string contact in allContactsList) {
				allContacts.Add (contact);
			}
			return allContacts;
		}

		public void Add (string firstName, string  lastName, string phoneNumber)
		{
			addressBook.WriteToFile (firstName.ToUpper () + "," + lastName.ToUpper () + "," + phoneNumber);
		}

		public List<string> Search (string contactToSearch)
		{
			List<string> foundContacts = new List<string> ();
			string[] allContactsList = addressBook.ReturnAllLines ();
			foreach (string contact in allContactsList) {
				if (contact.Contains (contactToSearch.ToUpper ())) {
					foundContacts.Add (contact);
				}
			}
			return foundContacts;
		}

		public void Delete (string contactToDelete)
		{
			addressBook.DeleteFromFile (contactToDelete);
		}
	}
}

