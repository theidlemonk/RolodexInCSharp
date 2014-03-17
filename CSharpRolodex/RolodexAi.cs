using System;

namespace CSharpRolodex
{
	public class RolodexAi
	{
		public static void MenuSelectionRedirect ()
		{
			string selectedMenuItem = Console.ReadLine();
			if (selectedMenuItem == "1")
			{
				OpenPage("Search");
			}
			else if (selectedMenuItem == "2")
			{
				OpenPage("Add");
			}
			else if (selectedMenuItem == "3")
			{
				OpenPage("Quit");
			}
			else
			{
				OpenPage("Error");
			}

		}

		public static void OpenPage(string page)
		{ 
			Console.Clear ();
			RolodexUi.Header (page);

			switch (page) {
				case "Add":
				AddContact();
				break;
				case "Search":
				SearchContact();
				break;
			default:
				break;
			}

		}

		public static void AddContact()
		{
			Console.Write ("First Name: ");
			string firstName = Console.ReadLine ().ToUpper();
			Console.Write ("Last Name: ");
			string lastName = Console.ReadLine ().ToUpper();
			Console.Write ("Phone Number: ");
			string phoneNumber = Console.ReadLine ();
			AddressBook.WriteToAddressBook(firstName +","+lastName+","+phoneNumber);
			Console.WriteLine ("\nA new contact "+firstName.ToUpperInvariant()+" has been added!");
		}

		static void SearchContact ()
		{
			Console.WriteLine("Who you looking for?");
			string contactToSearch = Console.ReadLine().ToUpper();
			string[] AllContactsList = AddressBook.ReturnAllContacts ();
			foreach (string contact in AllContactsList) {
				if (contact.Contains (contactToSearch)) {
					Console.WriteLine (contact);
				}
			}
			 
		}
	}
}

