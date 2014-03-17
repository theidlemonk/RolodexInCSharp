using System;

namespace CSharpRolodex
{
	public class RolodexUi
	{
		public static void Header (string page)
		{
			Console.Clear ();
			Console.WriteLine ("****************************");
			Console.WriteLine ("       >>>ROLODEX<<<");
			Console.WriteLine ("..." + page.ToUpper () + "...   ");
			Console.WriteLine ("****************************");
		}

		public static void MainMenu ()
		{
			Console.WriteLine ("\nWhat do you want to do!");
			Console.WriteLine ("1. Search Contact");
			Console.WriteLine ("2. Add Contact");
			Console.WriteLine ("3. EXIT\n");
		}

		public static void ApplicationLoop()
		{
			RolodexUi.Header("MainMenu");
			RolodexUi.MainMenu();
			RolodexAi.MenuSelectionRedirect();
		}

		public static void EndOfProcess()
		{
			Console.WriteLine ("\n Please hit any key to Continue!");
			Console.ReadKey ();
			ApplicationLoop ();
		}

	}
}

