#region PROPERTIES
// Game general info

using JerkoLibs.Core.Console.Menu;
using Display = JerkoLibs.Core.Console.Display;
using HarryPotter.Games.Core.Models;
using JerkoLibs.Core.Common;
using JerkoLibs.Core.DataLayers.Interfaces;
using JerkoLibs.Core.DataLayers;

const string TITLE = "Harry Potter";
const string SUBTITLE = "Un jeu épique !";

// Game initial values
Grid2D gameGrid = new(new Position(0, 500), new Position(0, 300));
const int MIN_AGE = 12;

// Player infos
Player player;
Ennemy ennemy = new Ennemy("Comte Doku");

#endregion PROPERTIES
#region ACTIONS
//DisplayGameInfos();
GetPlayerInfos();
PlayerActions();
GetPlayerGameMainMenuSelection();
GetPlayerForce();
GetPlayerDefaultWeapon();
GetPlayerInfoInXml();
//InitializeGameGrid();
//DisplayCredits();

#endregion ACTIONS
#region METHODS
void DisplayGameInfos()
{
    ConsoleLine.WriteLine($"{TITLE}, {SUBTITLE.Substring(0, SUBTITLE.Length - 2)}", ConsoleColor.Yellow);
}

void GetPlayerInfos()
{
    //string playerName = GetPlayerName();
    //player = new Player(playerName, GetPlayerBirthday());
    player = new Player("Jéjé", DateOnly.Parse("16/12/1977"));

    if (!HasRequiredAge())
    {
        throw new Exception($"\nTu n'as pas l'age requis pour jouer à ce jeu vidéo {player.Name}, reviens Quand tu seras plus grand !");
    }

    //player.Name = "Jéjé";

}

string GetPlayerName()
{
    string inputName = CoreConsole.GetUserInput("Quel est ton nom ?");

    return inputName;
}

DateOnly GetPlayerBirthday()
{
    string inputBirthday = CoreConsole.GetUserInput("Quel est ta date de naissance ? (jj/mm/aaaa)");
    DateOnly playerBirthday;

    if (!DateOnly.TryParseExact(inputBirthday, "d/M/yyyy", out playerBirthday))
    {
        ConsoleErrorLine.WriteLine("Le format de la date de naissance n'est pas au bon format, veuillez recommencer.");
        return GetPlayerBirthday();
    }

    return playerBirthday;
}

void GetPlayerGameMainMenuSelection()
{

    Menu mainMenu = new("Quelle action souhaitez-vous réaliser ?");

    mainMenu.Add(0, "nouvelle partie");
    mainMenu.Add(1, "charger partie");
    mainMenu.Add(2, "crédits");
    mainMenu.Add(3, "quitter");

    int menuItemSelectedByPlayer = MenuHelper.GetMenuSelection(mainMenu);
    string selectedItem = mainMenu.Items[menuItemSelectedByPlayer].GetSelectedItem();
    ConsoleConfirmationLine.WriteLine(selectedItem);
}

void GetPlayerForce()
{
    Force playerForceSelection = Force.GetPlayerSideForce();
    string selectedItem = playerForceSelection.item.GetSelectedItem();
    ConsoleConfirmationLine.WriteLine(selectedItem);

    player.Force = playerForceSelection;
}

void GetPlayerDefaultWeapon()
{
    Menu weaponMenu = new("Avec quel arme souhaitez-vous commencez la partie ?");

    weaponMenu.Add(0, "gun");
    weaponMenu.Add(1, "bow");
    weaponMenu.Add(2, "crossbow");
    weaponMenu.Add(3, "machinegun");
    weaponMenu.Add(4, "axe");

    int menuItemSelectedByPlayer = MenuHelper.GetMenuSelection(weaponMenu);
    string selectedItem = weaponMenu.Items[menuItemSelectedByPlayer].GetSelectedItem();
    ConsoleConfirmationLine.WriteLine(selectedItem);
}

void GetPlayerInfoInXml()
{
    IDataLayer saveEnnemy = new DataLayerSerialization(@"C:\Users\jerom\OneDrive\Documents\Dev\Test", "player", "xml");
    saveEnnemy.Write(ennemy);
    var @object = saveEnnemy.Read(typeof(Ennemy));
    Display.WriteLineWithTextColor(@object.ToString(), ConsoleColor.Green);
}
bool HasRequiredAge()
{
    return player.Age.CompareTo(MIN_AGE) >= 0;
}

void DisplayCredits()
{
    ConsoleLine.WriteLine("=======================================", ConsoleColor.Green);
    ConsoleLine.WriteLine("Jérôme Potié alias Jéjé. Copyright 2023", ConsoleColor.Yellow);
    ConsoleLine.WriteLine("=======================================", ConsoleColor.Green);
}

void PlayerActions()
{
    Console.WriteLine("\n");

    Display.WriteLineWithTextColor(player.CurrentPosition.ToString(), ConsoleColor.Yellow);
    player.Move(new PlayerPosition(2,4));
    player.Attack(ennemy, 20);
    ennemy.Attack(player, 50);
    player.Move(new RandomPositionCalculator(gameGrid.X, gameGrid.Y));
    player.Move(new StaticPositionCalculator());
    Display.WriteLineWithTextColor(player.CurrentPosition.ToString(), ConsoleColor.Yellow);
}

#endregion Methods
#region TESTS
// ---------------  PARTIE TESTS -----------------------------
ConsoleErrorLine.WriteLine("\nTests...\n\n");

// Déclarer une décimale
//decimal gunPower = 10.5m;

// Convertit implicitement un décimal en int et l'arrondi à la valeur inférieure
//! ATTENTION, un int à un min et max inférieur à un décimal, un erreur peut se produire
//int decimalToInt = (int)gunPower;
//Console.WriteLine(gunPower);

//Console.WriteLine($"Le tableau est composé de {gameGrid.GetLength(0)} lignes et de {gameGrid.GetLength(1)} colonnes");
#endregion
