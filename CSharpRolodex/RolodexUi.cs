using System;

namespace CSharpRolodex
{
	public class RolodexUi
	{
		public static void Header (string page)
		{
			Console.Clear ();
			Console.BackgroundColor = ConsoleColor.White;
			PrintInColor ("****************************", ConsoleColor.Cyan);
			PrintInColor ("       >>>ROLODEX<<<", ConsoleColor.Cyan);
			PrintInColor ("..." + page.ToUpper () + "...   ", ConsoleColor.Blue);
			PrintInColor ("****************************", ConsoleColor.Cyan);

		}

		public static void MainMenu ()
		{
			PrintInColor ("\nWhat do you want to do!", ConsoleColor.Green);
			PrintInColor ("1. Search Contact", ConsoleColor.Green);
			PrintInColor ("2. Add Contact", ConsoleColor.Green);
			PrintInColor ("3. Delete Contact", ConsoleColor.Green);
			PrintInColor ("4. EXIT\n", ConsoleColor.Green);
		}

		public static void ApplicationLoop ()
		{
			RolodexUi.Header ("MainMenu");
			RolodexUi.MainMenu ();
			RolodexAi.MenuSelectionRedirect ();
		}

		public static void EndOfProcess ()
		{
			PrintInColor ("\n Please hit any key to Continue!", ConsoleColor.Green);
			Console.ReadKey ();
			ApplicationLoop ();
		}

		public static void PrintInColor (string textToPrint, ConsoleColor color)
		{
			Console.ForegroundColor = color;
			Console.WriteLine (textToPrint);
			Console.ResetColor ();
		}
	}
}

