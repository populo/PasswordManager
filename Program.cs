using System;
using System.Collections.Generic;

namespace PasswordManager
{
	class MainClass
	{

		public const double VERSION = 0.1;

		private List<Account> accounts;

		public static void Main (string[] args)
		{
			new MainClass ();
		}

		public MainClass()
		{
			loadInformation ();
			run ();
		}

		private void loadInformation () {
			accounts = new List<Account>();
		}

		public void addAccount() {
			write ("Enter name for new account: ");
			string name = Console.ReadLine ();
			write ("Enter username for account " + name + ": ");
			string username = Console.ReadLine ();
			write ("Enter password for account " + name + ": ");
			string password = Console.ReadLine ();
			accounts.Add (new Account (name, username, password));
			writeLine ("Added account " + name);
		}

		private void run() {
			bool quitting = false;
			Console.Title = "Password Manager v" + VERSION;
			writeLine ("Welcome to Chris's password manager v" + VERSION);
			while (!quitting) {
				writeLine ("Commands: h - help, q - quit, a - add account, l - list accounts");
				writeLine ("What would you like to do?");
				write ("> ");
				char entry = Console.ReadKey ().KeyChar;
				quitting = processCommand (entry);
			}
		}

		private bool processCommand(char c) {
			clearConsole ();
			bool quitting = false;
			if (c == 'h') {
				writeLine ("Showing Help");
			} else if (c == 'q') {
				writeLine ("Quitting...");
				quitting = true;
			} else if (c == 'a') {
				addAccount ();
			} else if (c == 'l') {
				writeLine ("Listing Accounts");
			} else {
				writeLine ("Invalid Entry.");
			}

			return quitting;
		}

		private void clearConsole() {
			Console.Clear ();
			writeLine("Welcome to Chris's password manager v" + VERSION);
		}

		private void writeLine(string line = "") {
			Console.WriteLine (line);
		}

		private void write(string line = "") {
			Console.Write (line);
		}
	}


	public class Account {
		public Account(string name, string username, string password) {
			Name = name;
			Username = username;
			Password = password;
		}

		public Account(string[] data) {
			Name = data [0];
			Username = data [1];
			Password = data [2];
		}

		public string Name { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public void printAccount() {
			Console.WriteLine ("Account: " + Name);
			Console.WriteLine ("Username > " + Username);
			Console.WriteLine ("Password > " + Password);
		}
	}
}
