// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Globalization;

string title = "Harry Potter";
string subtitle = "un jeu épique !";
string[] menuItems =
    {
        "Nouvelle partie",
        "Charger partie",
        "Crédits",
        "Quitter",
    };
int minAge = 12;

string playerName;
DateOnly playerBirthday;
int playerAge;

Console.WriteLine($"{title}, {subtitle.Substring(0, subtitle.Length - 2)}");

// ---- SAISIE INFORMATIONS JOUEURS / JOUEUSE ------
playerName = getPlayerName();
playerAge = getPlayerAge();

if (!hasRequiredAge())
{
    throw new Exception($"\nTu n'as pas l'age requis pour jouer à ce jeu vidéo {playerName}, reviens plus tard !");
}

playerBirthday = getPlayerBirthday();

int menuItemSelectedByPlayer = getPlayerMenuChoice();
Console.WriteLine($"\nVous avez choisi {menuItems[menuItemSelectedByPlayer]}");

// METHODS
string getPlayerName()
{
    string inputName = getPlayerInput("\nQuel est ton nom ?");

    return inputName;
}

int getPlayerAge()
{
    string inputAge = getPlayerInput("\nQuel est ton age ?");

    // Convertit une string en integer
    int playerAge = int.Parse(inputAge);

    return playerAge;
}

DateOnly getPlayerBirthday()
{
    string inputBirthday = getPlayerInput("\nQuel est ta date de naissance ?");

    return DateOnly.Parse(inputBirthday);
}

bool hasRequiredAge()
{
    return playerAge.CompareTo(minAge) >= 0;
}

string getPlayerInput(string question = null)
{
    string input = "";

    while (input == "")
    {
        if (question != null) Console.WriteLine(question);
        input = Console.ReadLine();
    }

    return input;
}

int getPlayerMenuChoice()
{
    string playerChoiceInput = "";
    string menuItemFormat = "{0} . {1}";

    Console.WriteLine("\n");

    foreach (var item in menuItems.Select((value, i) => (value, i)))
    {
        Console.WriteLine(menuItemFormat, item.i, item.value);
    }

    playerChoiceInput = getPlayerInput("\nQue souhaitez-vous faire ?");

    return int.Parse(playerChoiceInput);
}

// ------  Partie Test
Console.WriteLine("\nTests...\n\n");
// Déclarer une décimale
decimal gunPower = 10.5m;

// Convertit implicitement un décimal en int et l'arrondi à la valeur inférieure
//! ATTENTION, un int à un min et max inférieur à un décimal, un erreur peut se produire
int decimalToInt = (int)gunPower;

Console.WriteLine(gunPower);
