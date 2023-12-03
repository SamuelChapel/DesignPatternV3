using DesignPatternV3.Controllers;
using DesignPatternV3.View.Extensions;
using Unity;
using static System.Console;
using static DesignPatternV3.View.Helpers.ConsoleHelper;

IUnityContainer unitycontainer = new UnityContainer().AddServices();

EmployeController employeController = unitycontainer.Resolve<EmployeController>();

int choice;

do
{
	choice = DisplayMenu("Gestion D'employées",
		"Ajouter un employé",
		"Mettre à jour un employé",
		"Afficher un employé par son Id",
		"Afficher tous les employées");

	switch (choice)
	{
		case 1:
			await AddEmployee();
			break;
		case 2:
			await UpdateEmployee();
			break;
		case 3:
			await GetEmployeeById();
			break;
		case 4:
			await DisplayEmployees();
			break;
		default:
			break;
	}
} while (choice != 0);

async Task AddEmployee()
{
	var firstName = GetStringFromConsole("Entrez son prénom : ");
	var lastName = GetStringFromConsole("Entrez son nom : ");
	var salary = GetIntFromConsole("Entrez son salaire : ");

	var result = await employeController.AddEmployee(firstName, lastName, salary);

	WriteLine(result);

	ReadKey();
}

async Task UpdateEmployee()
{
	var id = GetIntFromConsole("Entrez l'id de l'employée : ");
	var firstName = GetStringFromConsole("Entrez son prénom : ");
	var lastName = GetStringFromConsole("Entrez son nom : ");
	var salary = GetIntFromConsole("Entrez son salaire : ");

	WriteLine(await employeController.UpdateEmployee(id, firstName, lastName, salary));

	ReadKey();
}

async Task DisplayEmployees()
{
	WriteLine(await employeController.GetAllEmployees());

	ReadKey();
}

async Task GetEmployeeById()
{
	var id = GetIntFromConsole("Entrez l'id de l'employée : ");
	WriteLine(await employeController.GetEmployee(id));

	ReadKey();
}