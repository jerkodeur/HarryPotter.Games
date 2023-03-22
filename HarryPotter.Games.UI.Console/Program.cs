#region PROPERTIES
// Game general info
const string TITLE = "Harry Potter";
const string SUBTITLE = "Un jeu épique !";
string[] menuItems = { "nouvelle partie", "charger partie", "crédits", "quitter"};
string[] menuWeapons = { "gun", "bow", "crossbow", "machinegun"};

// Game initial values
int[,] gameGrid = new int[20, 20];
const int MIN_AGE = 12;

// Player infos
Player player;

#endregion PROPERTIES
#region ACTIONS
DisplayGameInfos();
GetPlayerInfos();
PlayerActions();
//GetPlayerGameMainMenuSelection();
//GetPlayerDefaultWeapon();
//InitializeGameGrid();
//DisplayCredits();

#endregion ACTIONS
#region METHODS
void DisplayGameInfos()
{
    Console.WriteLineWithColors($"{TITLE}, {SUBTITLE.Substring(0, SUBTITLE.Length - 2)}", ConsoleColor.Yellow);
}

void GetPlayerInfos()
{
    player = new Player(GetPlayerBirthday());

    if (!HasRequiredAge())
    {
        throw new Exception($"\nTu n'as pas l'age requis pour jouer à ce jeu vidéo {player.Name}, reviens Quand tu seras plus grand !");
    }

    player.Name = GetPlayerName();

}

string GetPlayerName()
{
    string inputName = GetPlayerInput("\nQuel est ton nom ?");

    return inputName;
}

DateOnly GetPlayerBirthday()
{
    string inputBirthday = GetPlayerInput("\nQuel est ta date de naissance ? (jj/mm/aaaa)");
    DateOnly playerBirthday;

    if (!DateOnly.TryParseExact(inputBirthday, "d/M/yyyy", out playerBirthday))
    {
        Console.WriteErrorLine("Le format de la date de naissance n'est pas au bon format, veuillez recommencer.");
        return GetPlayerBirthday();
    }

    return playerBirthday;
}

void GetPlayerGameMainMenuSelection()
{
    int menuItemSelectedByPlayer = GetPlayerMenuChoice("Quelle action souhaitez-vous réaliser ? [0-3]", menuItems);
    Console.WriteConfirmationLine($"Vous avez choisi {menuItems[menuItemSelectedByPlayer]}");
}

void GetPlayerDefaultWeapon()
{
    player.DefaultWeapon = menuWeapons[GetPlayerMenuChoice("Avec quelle arme souhaitez-vous démarrer la partie ? [0-3]", menuWeapons)];
    Console.WriteConfirmationLine($"Vous avez choisi {player.DefaultWeapon} pour débuter la partie\n");
}

int GetPlayerMenuChoice(string question, string[] items)
{
    string playerChoiceInput;
    int playerSelectedIndex;

    DisplayMenu(items);

    playerChoiceInput = GetPlayerInput(question);

    if (!int.TryParse(playerChoiceInput, out playerSelectedIndex))
    {
        Console.WriteErrorLine("Le format de l'index n'est pas valide, veuillez recommencer.");
        return GetPlayerMenuChoice(question, items);
    } 
    else if(playerSelectedIndex < 0 || playerSelectedIndex > menuItems.Length -1)
    {
        Console.WriteErrorLine("L'index sélectionné n'est pas un index valide, veuillez recommencer.");
        return GetPlayerMenuChoice(question, items);
    }

    return playerSelectedIndex;
}

string GetPlayerInput(string question = "")
{
    string input = "";

    do
    {
        if (!string.IsNullOrEmpty(question))
        {
            Console.WriteQuestionLine(question);
        }

        input = Console.ReadLineWithColors();
    }
    while (string.IsNullOrWhiteSpace(input));

    return input;
}

bool HasRequiredAge()
{
    return player.Age.CompareTo(MIN_AGE) >= 0;
}

void InitializeGameGrid()
{
    const int IS_FREE_LOCATION = -1;

    {
        for (int i = 0; i < gameGrid.GetLength(0); i++)
        {

            for (int j = 0; j < gameGrid.GetLength(1); j++)
            {
                gameGrid[i, j] = IS_FREE_LOCATION;
            }
        }
    }
}

void DisplayCredits()
{
    Console.WriteLineWithColors("=======================================", ConsoleColor.Green);
    Console.WriteLineWithColors("Jérôme Potié alias Jéjé. Copyright 2023", ConsoleColor.Yellow);
    Console.WriteLineWithColors("=======================================", ConsoleColor.Green);
}

void DisplayMenu(string[] menuItems)
{
    DotNetConsole.WriteLine("\n");

    foreach (var item in menuItems.Select((value, i) => (value, i)))
    {
        Console.WriteMenuItemsLine(item.i, item.value);
    }
}

void PlayerActions()
{
    DotNetConsole.WriteLine("\n");
    Ennemy ennemy = new Ennemy("Dark Vador");

    player.Move();
    player.Attack(ennemy, 20);
}

#endregion Methods
#region TESTS
// ---------------  PARTIE TESTS -----------------------------
DotNetConsole.WriteLine("\nTests...\n\n");

// Déclarer une décimale
//decimal gunPower = 10.5m;

// Convertit implicitement un décimal en int et l'arrondi à la valeur inférieure
//! ATTENTION, un int à un min et max inférieur à un décimal, un erreur peut se produire
//int decimalToInt = (int)gunPower;
//DotNetConsole.WriteLine(gunPower);

//DotNetConsole.WriteLine($"Le tableau est composé de {gameGrid.GetLength(0)} lignes et de {gameGrid.GetLength(1)} colonnes");
#endregion
