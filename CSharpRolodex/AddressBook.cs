using System;
using System.IO;

namespace CSharpRolodex
{
	public class AddressBook
	{
		public static string AddressBookFileLocation = @"/Users/TheIdleMonk/code/Xamarine/CSharpRolodex/CSharpRolodex/AddressBook.txt";
		public static void WriteToAddressBook(string lineToWrite)
		{
			//	File.WriteAllText (AddressBookFileLocation, lineToWrite);
			using (StreamWriter w = File.AppendText(AddressBookFileLocation))
			{
				w.WriteLine(lineToWrite);
			}
		}

		public static string[] ReturnAllContacts()
		{
			return File.ReadAllLines (AddressBookFileLocation);
		}
	}
}

