using DesignPatternV3.Controllers;
using DesignPatternV3.View.Extensions;
using Unity;
using static DesignPatternV3.View.ConsoleHelper;
using static System.Console;

IUnityContainer unitycontainer = new UnityContainer().AddServices();

EmployeController employeController = unitycontainer.Resolve<EmployeController>();

int choice;

do
{
    choice = DisplayMenu("Gestion D'employées",
    [
        "Ajouter un employé",
        "Afficher les employées",
        "Récupérer un employé par son Id"
    ]);

    switch (choice)
    {
        case 1:
            AddEmployee();
            break;
        case 2:
            DisplayEmployees();
            break;
        case 3:
            GetEmployeeById();
            break;
        default:
            break;
    }
} while (choice != 0);

void AddEmployee()
{
    var firstName = GetStringFromConsole("Entrez son prénom : ");
    var lastName = GetStringFromConsole("Entrez son nom : ");
    var salary = GetIntFromConsole("Entrez son salaire : ");

	var result = employeController.AddEmployee(firstName, lastName, salary);

    WriteLine(result);

    ReadKey();
}

void DisplayEmployees()
{
    WriteLine(employeController.GetAllEmployees());

    ReadKey();
}

void GetEmployeeById()
{
    var id = GetIntFromConsole("Entrez l'id de l'employée : ");
    WriteLine(employeController.GetEmployee(id));

    ReadKey();
}