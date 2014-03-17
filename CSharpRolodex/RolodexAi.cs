using System;
using System.Threading;

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
			RolodexUi.Header (page);

			switch (page) {
				case "Add":
				AddContact();
				break;
				case "Search":
				SearchContact();
				break;
			case "Quit":
				QuitRolodex ();
				break;
			case "Error":
				ErrorNotify ();
			default:
				break;
			}

		}

		public static void AddContact()
		{
			Console.Write ("\nFirst Name: ");
			string firstName = Console.ReadLine ().ToUpper();
			Console.Write ("Last Name: ");
			string lastName = Console.ReadLine ().ToUpper();
			Console.Write ("Phone Number: ");
			string phoneNumber = Console.ReadLine ();
			AddressBook.WriteToAddressBook(firstName +","+lastName+","+phoneNumber);
			Console.WriteLine ("\nA new contact "+firstName.ToUpperInvariant()+" has been added!");
			RolodexUi.EndOfProcess ();
		}

		static void SearchContact ()
		{
			Console.WriteLine("\nWho you looking for?");
			string contactToSearch = Console.ReadLine().ToUpper();
			string[] AllContactsList = AddressBook.ReturnAllContacts ();
			foreach (string contact in AllContactsList) {
				if (contact.Contains (contactToSearch)) {
					Console.WriteLine (contact);
				}
			}
			RolodexUi.EndOfProcess ();
		}

		static void QuitRolodex ()
		{
			Console.WriteLine ("\nBye Bye !");
			Thread.Sleep(1000);
			//Environment.Exit(0);
		}

		static void ErrorNotify ()
		{
			Console.WriteLine ("\n Really! That was not even an option!\n Type a number as a selection!");
			RolodexUi.EndOfProcess ();
		}
	}
}

