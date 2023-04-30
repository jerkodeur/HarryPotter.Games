using LinqTraining;
using LinqTraining.Extensions;

#region Test Linqs
List<int> counters = new()
{
    1,2,3,4,5,6,7,8,9,10,11,12,13
};

int[] counters2 = new[]
{
    1,2,3,4,5,6,7,8,9,10,11,12,13
};

// Pour chaque élément de ma liste, je le sélectionne (parcoure les éléments de la liste)
// /!\ Non executé (ne créer que la requête)
var query =
    from item in counters
    where item <= 10
    select item;

var query_2 =
    from item in query
    where item > 5
    orderby item descending
    select item;

// La requête est exécutée ici !
foreach (var item in query_2)
{
    Console.Write(item + " ");
}

Console.WriteLine();

var newList = counters
    .Where(item => item <= 10)
    .OrderByDescending(item => item)
    .Skip(2) // Ne prends pas en compte les 2 premiers éléments
    .Take(6) // Ne prends en compte que les deux premiers éléments
    .TakeWhile(i => i % 2 == 0); // Prends en compte tous les éléments de la séquence tant que le prédicat n'est pas trouvé

foreach (var item in newList)
{
    Console.Write(item + " ");
}

Console.WriteLine();

var filterList = counters.ToList(); // Permet de se déconnecter de l'executeur (isole la liste, n'est plus dépendante des actions passées qui sont libérées de la mémoire)
Console.WriteLine(String.Format("Premier élément de la liste la liste: {0}", filterList.First()));
Console.WriteLine(String.Format("Dernier élément de la liste: {0}", filterList.Last()));
Console.WriteLine(String.Format("Nombre d'éléments dans la liste: {0}", filterList.Count()));
Console.WriteLine(String.Format("Valeur la plus petite: {0}", filterList.Min())); // +13 surcharges
Console.WriteLine(String.Format("Valeur la plus grande: {0}", filterList.Max())); // +13 surcharges
Console.WriteLine(String.Format("Somme des éléments: {0}", filterList.Sum())); // +10 surchages 
#endregion

#region Wizards
Wizard harry = new();
Wizard voldemort = new Wizard();

harry.Attack(voldemort);
voldemort.Defend(harry);

List<Wizard> wizards = new List<Wizard>()
{
    new Wizard( "Tom Jedusor", 200, true, 1 ),
    new Wizard( "Harry Potter", 100, 1 ),
    new Wizard( "Harmony Gringer", 150, 2),
    new Wizard( "Darco Malfoy", 150, true, 3),
};

#region Ne récupère qu'une propriété des objects filtrés
var wizardIsNotDarkByNameQuery = from wizard in wizards
                                 where !wizard.IsDark
                                 select wizard.Name;

// Même requête réalisée avec les méthodes d'extension
var wizardIsNotDarkByNameQueryWithExtension = wizards
    .Where(wizard => !wizard.IsDark)
    .Select(wizard => wizard.Name);

foreach (var name in wizardIsNotDarkByNameQuery)
{
    Console.WriteLine(name);
}
// Harry Potter
// Harmony Gringer 
#endregion

#region Créer un nouvel objet à la volée afin de ne renvoyer que les propriétés désirées
var wizardIsNotDarkByNameAndLifePointsQuery =
from wizard in wizards
where !wizard.IsDark
select new { name = wizard.Name, points = wizard.LifePoints };

foreach (var wizard in wizardIsNotDarkByNameAndLifePointsQuery)
{
    Console.WriteLine($"Name: {wizard.name}, LifePoints: {wizard.points}");
}
// Name: Harry Potter, LifePoints: 100
// Name: Harmony Gringer, LifePoints: 150 
#endregion

#region Créer des variables temporaires dans les queries
var wizardIsNotDarkAndNameIsBiggerThan5CharsQuery = from wizard in wizards
                                                    let splittedName = wizard.Name.Split(' ')
                                                    let lastname = splittedName[0].ToUpper()
                                                    where !wizard.IsDark && lastname.Length > 3
                                                    orderby lastname.Length descending
                                                    select lastname;

foreach (var name in wizardIsNotDarkAndNameIsBiggerThan5CharsQuery)
{
    Console.WriteLine(name);
}
// HARMONY
// HARRY
#endregion

#region Joindre plusieurs ensemble
List<MagicWand> magicWands = new()
{
    new(1, "Fire wand"),
    new(2, "Water wand"),
    new(3, "Air wand")
};

// Inner join (jointure forte) -> ne récupère que les correspondances
var moreInfoOnWizardsQuery = from wizard in wizards
                             join magicWand in magicWands on wizard.WandId equals magicWand.Id
                             select new { wizard, magicWand };

foreach (var item in moreInfoOnWizardsQuery)
{
    Console.WriteLine($"{item.wizard.Name} à comme baguette {item.magicWand.Label}");
}
#endregion
#endregion
#region Test record
var piece = new MoneyPiece(1);
var piece2 = new MoneyPiece(1);
var piece3 = new MoneyPiece(3);

Console.WriteLine(piece == piece2);
#endregion
IEnumerable<int> GetList()
{
    yield return 1;
    yield return 2;
    yield return 3;
    yield return 4;
    yield return 10;
}

var myIteratorList = GetList().ToList(); // Devient une liste de int

// Equivaut à
List<int> myIntList = new() { 1, 2, 3, 4, 10 };

Console.Write("Get list build with an iterator (yield): ");
foreach (var item in GetList())
{
    Console.Write(item + " ");
}

// Création d'une query basée sur l'itérateur GetList()
var queryYield = from item in GetList()
                 where item % 2 == 0
                 select item;

Console.WriteLine();
Console.Write("Get query list build with linq: ");

foreach (var item in queryYield)
{
    Console.Write(item + " ");
}
