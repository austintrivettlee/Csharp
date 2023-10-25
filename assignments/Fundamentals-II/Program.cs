int[] numArray = new int[5];
int[] firstArray = {0,1,2,3,4,5,6,7,8,9};

for (int i = 0; i < firstArray.Length; i++)
{
Console.WriteLine(firstArray[i]);
}

Console.WriteLine("----------------------");

string[] names = new string[] {"Tim", "Martin", "Nikki", "Sara"};

for (int i = 0; i < names.Length; i++)
{
Console.WriteLine(names[i]);
}

Console.WriteLine("----------------------");
bool[] boolArray = new bool[10];

for (int i = 0; i < boolArray.Length; i++)
{
    boolArray[i] = i % 2 == 0;
}
for (int i = 0; i < boolArray.Length; i++)
{
    Console.WriteLine(boolArray[i]);
}
Console.WriteLine("----------------------");
    
List<string> iceCreamFlav = new List<string> {"Mint", "Vanilla", "Chocolate", "Strawberry", "Mango"};

Console.WriteLine(iceCreamFlav.Count);
Console.WriteLine(iceCreamFlav[2]);

iceCreamFlav.RemoveAt(2);
Console.WriteLine("----------------------");

for (int i = 0; i < iceCreamFlav.Count; i++)
{
    Console.WriteLine(iceCreamFlav[i]);
}
Console.WriteLine("----------------------");
Console.WriteLine(iceCreamFlav.Count);
Console.WriteLine("----------------------");

Dictionary<string,string> favIceCream = new Dictionary<string, string>();
Random rand = new Random();
for (int i = 0; i < names.Length; i++)
{
    favIceCream.Add(names[i], iceCreamFlav[rand.Next(0,4)]);
}

foreach(KeyValuePair<string,string> entry in favIceCream)
{
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}