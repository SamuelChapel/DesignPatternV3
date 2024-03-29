﻿using static System.Console;

namespace DesignPatternV3.View.Helpers;

public static class ConsoleHelper
{
	public static string GetStringFromConsole(string label = "Entrez la valeur")
	{
		WriteLine(label);
		var input = ReadLine();

		while (string.IsNullOrWhiteSpace(input))
		{
			WriteLine("Entrée incorrecte, veuilllez réessayer");
			input = ReadLine();
		}

		return input;
	}

	public static int GetIntFromConsole(string label = "Entrez la valeur")
	{
		Write(label + " : ");
		int inputNumber;

		while (!int.TryParse(ReadLine(), out inputNumber))
		{
			Write("Ce n'est pas un nombre, veuillez réessayer : ");
		}

		return inputNumber;
	}

	public static int DisplayMenu(string title, params string[] options)
	{
		Clear();

		WriteLine("----- " + title + " -----\n");
		for (int i = 0; i < options.Length; i++)
		{
			WriteLine($"  {i + 1} : {options[i]}");
		}

		WriteLine("  0 : Quitter");

		int choice;
		do
		{
			var input = ReadLine();
			if (!int.TryParse(input, out choice))
				choice = -1;
		} while (choice == -1 || choice < 0 || choice > options.Length);

		return choice;
	}
}
