using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CSharpRolodex
{
	public class RolodexUi
	{
//		RolodexAi rolodexAi = new RolodexAi ();
		private RolodexAi rolodexAi;

		public RolodexUi(){
			rolodexAi = new RolodexAi ();
		}

		public void Header (string page)
		{
			Console.Clear ();
			PrintInColor ("****************************", ConsoleColor.Cyan);
			PrintInColor ("       >>>ROLODEX<<<", ConsoleColor.Cyan);
			PrintInColor ("..." + page.ToUpper () + "...   ", ConsoleColor.DarkYellow);
			PrintInColor ("****************************", ConsoleColor.Cyan);

		}

		public void MainMenu ()
		{
			PrintInColor ("\nWhat do you want to do!", ConsoleColor.Green);
			PrintInColor ("1. Search Contact", ConsoleColor.Green);
			PrintInColor ("2. Add Contact", ConsoleColor.Green);
			PrintInColor ("3. Delete Contact", ConsoleColor.Green);
			PrintInColor ("4. View All Contacts", ConsoleColor.Green);
			PrintInColor ("5. EXIT\n", ConsoleColor.Green);
		}

		public void ApplicationLoop ()
		{
			Header ("MainMenu");
			MainMenu ();
			MenuSelectionRedirect ();
		}

		public void MenuSelectionRedirect ()
		{
			string selectedMenuItem = Console.ReadLine ();
			int userSelection;
			int.TryParse (selectedMenuItem, out userSelection);
			OpenPage (((UserOptions)userSelection).ToString ());
		}

		public void OpenPage (string page)
		{
			Header (page);
			RolodexFunction (page);
			EndOfProcess ();
		}

		public void RolodexFunction (string page)
		{
			Type thisType = this.GetType ();
			MethodInfo Method = thisType.GetMethod (page);
			Method.Invoke (this, null);
		}

		public void Add ()
		{
			Console.Write ("\nFirst Name: ");
			string firstName = Console.ReadLine ();
			Console.Write ("Last Name: ");
			string lastName = Console.ReadLine ();
			Console.Write ("Phone Number: ");
			string phoneNumber = Console.ReadLine ();
			rolodexAi.Add (firstName, lastName, phoneNumber);
			PrintInColor ("\nA new contact " + firstName.ToUpper () + " has been added!", ConsoleColor.Cyan);
		}

		public void Search ()
		{
			PrintInColor ("\nWho you looking for?", ConsoleColor.Cyan);
			string contactToSearch = Console.ReadLine ();
			List<string> foundContactListings = new List<string> ();
			foundContactListings = rolodexAi.Search (contactToSearch);

			if (foundContactListings.Count () == 0) {
				PrintInColor ("\n Oops! No such contact exists!", ConsoleColor.Red);
			} else {
				foreach (string contact in foundContactListings) {
					PrintInColor ("\n" + contact, ConsoleColor.DarkCyan);
				}
			}
		}

		public void Delete ()
		{
			PrintInColor ("\n Who would you like to delete!", ConsoleColor.DarkCyan);
			string contactToDelete = Console.ReadLine ();
			rolodexAi.Delete (contactToDelete);
			PrintInColor ("\n " + contactToDelete.ToUpper () + " has been removed from your Rolodex!", ConsoleColor.Red);
		}

		public void AllContacts ()
		{
			List<string> allContacts = rolodexAi.AllContacts ();
			foreach (var contact in allContacts) {
				Console.WriteLine (contact);
			}

		}

		public void Exit ()
		{
			PrintInColor ("\nBye Bye !", ConsoleColor.Cyan);
			Thread.Sleep (1000);
			Environment.Exit (0);
		}

		public void Error ()
		{
			PrintInColor ("\n Really! That was not even an option!\n Type a number as a selection!", ConsoleColor.Red);
		}

		public void EndOfProcess ()
		{
			PrintInColor ("\n Please hit any key to Continue!", ConsoleColor.Green);
			Console.ReadKey ();
			ApplicationLoop ();
		}

		public void PrintInColor (string textToPrint, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine (textToPrint);
			Console.ResetColor ();
		}
	}
}

