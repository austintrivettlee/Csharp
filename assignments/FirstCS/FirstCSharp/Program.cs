// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

for (int i = 1; i < 256; i++)
{
    Console.WriteLine(i);
}

Random rand = new Random();
int total = 0;
for (int i = 0; i <= 6; i++)
{
    total = total + (rand.Next(10, 21));
}

Console.WriteLine(total);

for (int i = 1; i < 101; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("FizzBuzz");
    }
    if (i % 3 == 0)
    {
        Console.WriteLine("fizz");
    }
    if (i % 5 == 0)
    {
        Console.WriteLine("buzz");
        
    }
}
