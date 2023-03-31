using HarryPotter.Games.Core.Menus;

#region ACTIONS
GetPlayerGameMainMenuSelection();
//GetClassInfoInXml();
#endregion ACTIONS
#region METHODS

void GetPlayerGameMainMenuSelection()
{
    GameMenu gameMenu = new();

    gameMenu.PromptUserToSelectOption();
}

#endregion Methods
#region TESTS
// ---------------  PARTIE TESTS -----------------------------

//ConsoleErrorLine.WriteLine("\nTests...\n\n");
// Déclarer une décimale
//decimal gunPower = 10.5m;

// Convertit implicitement un décimal en int et l'arrondi à la valeur inférieure
//! ATTENTION, un int à un min et max inférieur à un décimal, un erreur peut se produire
//int decimalToInt = (int)gunPower;
//Console.WriteLine(gunPower);

//Console.WriteLine($"Le tableau est composé de {gameGrid.GetLength(0)} lignes et de {gameGrid.GetLength(1)} colonnes");
#endregion
