using System;

namespace CSharpRolodex
{
	public class RolodexUi
	{
		public static void Header (string page)
		{
			Console.WriteLine ("****************************");
			Console.WriteLine ("       >>>ROLODEX<<<");
			Console.WriteLine ("..." + page.ToUpper () + "...   ");
			Console.WriteLine ("****************************");
		}

		public static void MainMenu ()
		{
			Console.WriteLine ("What do you want to do!");
			Console.WriteLine ("1. Search Contact");
			Console.WriteLine ("2. Add Contact");
			Console.WriteLine ("3. EXIT");
		}


	}
}

