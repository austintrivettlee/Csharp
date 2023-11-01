using System.Linq;

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");


Eruption firstChileEruption = eruptions.FirstOrDefault(e => e.Location == "Chile");
Console.WriteLine("First Chile:");
System.Console.WriteLine(firstChileEruption);

Eruption firstHawaiian = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");
if (firstHawaiian == null)
{
    System.Console.WriteLine("No Hawaiian Eruptions Found!");
}
else
{
    Console.WriteLine("First Hawaiian:");
    System.Console.WriteLine(firstHawaiian);
}

Eruption firstGreenland = eruptions.FirstOrDefault(e => e.Location == "Greenland");
if (firstGreenland == null)
{
    System.Console.WriteLine("No Greenland Eruptions Found!");
}
else
{
    Console.WriteLine("First Greenland:");
    System.Console.WriteLine(firstGreenland);
}

Eruption firstYearandNZ = eruptions.FirstOrDefault(e => e.Location == "New Zealand" && e.Year > 1900);
if (firstYearandNZ == null)
{
    System.Console.WriteLine("No YearfirstYearandNZ Eruptions Found!");
}
else
{
    Console.WriteLine("First YearfirstYearandNZ:");
    System.Console.WriteLine(firstYearandNZ);
}


IEnumerable<Eruption> elevationOver = eruptions.Where(e => e.ElevationInMeters > 2000);
PrintEach(elevationOver, "Elevation Over 2000m:");
IEnumerable<Eruption> startingWithL = eruptions.Where(e => e.Volcano.StartsWith("L"));
PrintEach(startingWithL, "Starts With L:");
int largestElevation = eruptions.Max(e => e.ElevationInMeters);
System.Console.WriteLine(largestElevation);
Eruption largestElevationVolc = eruptions.FirstOrDefault(e => e.ElevationInMeters == largestElevation);
System.Console.WriteLine(largestElevationVolc);
IEnumerable<Eruption> sortedAlphabetically = eruptions.OrderBy(e => e.Volcano);
PrintEach(sortedAlphabetically);
int sumOfElevation = eruptions.Sum(e => e.ElevationInMeters);
System.Console.WriteLine(sumOfElevation);
bool eruptedAfter2000 = eruptions.Any(e => e.Year > 2000);
System.Console.WriteLine(eruptedAfter2000);
IEnumerable<Eruption> stratoVols = eruptions.Where(e => e.Type == "Stratovolcano").Take(3);
PrintEach(stratoVols, "First 3 Stratovolcanos:");
IEnumerable<Eruption> priorEruptions = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano);
PrintEach(priorEruptions, "Prior to Year 1000:");
var priorEruptionsNames = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).Select(e => e.Volcano).ToList();
foreach (var name in priorEruptionsNames)
{
    System.Console.WriteLine(name);
}

static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}
