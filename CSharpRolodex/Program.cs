using System;

namespace CSharpRolodex
{
	class MainClass
	{
		public static void Main (string[] args)
		{   
			RolodexUi.Header("MainMenu");
			RolodexUi.MainMenu();
			RolodexAi.MenuSelectionRedirect();
		}


	}
}
