using System;
using System.Threading;

namespace CSharpRolodex
{
	public class RolodexAi
	{
		public static void MenuSelectionRedirect ()
		{
			string selectedMenuItem = Console.ReadLine ();
			if (selectedMenuItem == "1") {
				OpenPage ("Search");
			} else if (selectedMenuItem == "2") {
				OpenPage ("Add");
			} else if (selectedMenuItem == "3") {
				OpenPage ("Quit");
			} else {
				OpenPage ("Error");
			}

		}

		public static void OpenPage (string page)
		{ 
			RolodexUi.Header (page);

			switch (page) {
			case "Add":
				AddContact ();
				break;
			case "Search":
				SearchContact ();
				break;
			case "Quit":
				QuitRolodex ();
				break;
			case "Error":
				ErrorNotify ();
				break;
			default:
				break;
			}

		}

		public static void AddContact ()
		{
			Console.Write ("\nFirst Name: ");
			string firstName = Console.ReadLine ().ToUpper ();
			Console.Write ("Last Name: ");
			string lastName = Console.ReadLine ().ToUpper ();
			Console.Write ("Phone Number: ");
			string phoneNumber = Console.ReadLine ();
			AddressBook.WriteToAddressBook (firstName + "," + lastName + "," + phoneNumber);
			RolodexUi.PrintInColor ("\nA new contact " + firstName.ToUpper () + " has been added!",ConsoleColor.Cyan);
			RolodexUi.EndOfProcess ();
		}

		static void SearchContact ()
		{
			RolodexUi.PrintInColor ("\nWho you looking for?",ConsoleColor.Cyan);
			string contactToSearch = Console.ReadLine ().ToUpper ();
			string[] AllContactsList = AddressBook.ReturnAllContacts ();
			bool isAContactPresent = false;
			foreach (string contact in AllContactsList) {
				if (contact.Contains (contactToSearch)) {
					RolodexUi.PrintInColor ("\n"+contact,ConsoleColor.DarkCyan);
					isAContactPresent = true;
				}
 
			}
			if (!isAContactPresent){
				RolodexUi.PrintInColor("\n Oops! No such contact exists!",ConsoleColor.Red);
			}
			RolodexUi.EndOfProcess ();
		}

		static void QuitRolodex ()
		{
			RolodexUi.PrintInColor ("\nBye Bye !",ConsoleColor.Cyan);
			Thread.Sleep (1000);
			//Environment.Exit(0);
		}

		static void ErrorNotify ()
		{
			RolodexUi.PrintInColor ("\n Really! That was not even an option!\n Type a number as a selection!",ConsoleColor.Red);
			RolodexUi.EndOfProcess ();
		}
	}
}

