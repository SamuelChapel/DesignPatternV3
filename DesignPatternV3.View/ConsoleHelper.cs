using static System.Console;

namespace DesignPatternV3.View;

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

	public static int GetIntFromConsole(string label = "Entrez la valeur", int? min = null)
	{
		var input = GetStringFromConsole(label);
		int inputNumber;
		do
		{
			if (!int.TryParse(input, out inputNumber))
				WriteLine("Ce n'est pas un nombre, veuilllez réessayer");
			else  if (min != null && inputNumber < min)
				WriteLine($"Le nombre doit être supérieur à {min - 1}");

			input = ReadLine();
		} while (!int.TryParse(input, out inputNumber) || (min != null && inputNumber < min));

		return inputNumber;
	}

	public static int DisplayMenu(string title, string[] options, bool clearScreen = true)
	{
		if (clearScreen)
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
