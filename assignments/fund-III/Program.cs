static void PrintList(List<string> MyList)
{
    for (int i = 0; i < MyList.Count; i++)
    {
        Console.WriteLine(MyList[i]);

    }
}
List<string> TestStringList = new List<string>() { "Harry", "Steve", "Carla", "Jeanne" };
PrintList(TestStringList);

static void SumOfNumbers(List<int> IntList)
{
    int Sum = 0;
    for (int i = 0; i < IntList.Count; i++)
    {
        Sum += IntList[i];
    }
    Console.WriteLine($"Sum: {Sum}");

}
List<int> TestIntList = new List<int>() { 2, 7, 12, 9, 3 };
// You should get back 33 in this example
SumOfNumbers(TestIntList);

static int FindMax(List<int> IntList)
{
    int maxNum = 0;
    for (int i = 0; i < IntList.Count; i++)
    {
        if (maxNum < IntList[i])
        {
            maxNum = IntList[i];
        }
    }
    return maxNum;

}
List<int> TestIntList2 = new List<int>() { -9, 12, 10, 3, 17, 5 };
// You should get back 17 in this example
Console.WriteLine($"Max: {FindMax(TestIntList2)}");



static List<int> SquareValues(List<int> IntList)
{
    List<int> returnList = new List<int>();
    for (int i = 0; i < IntList.Count; i++)
    {
        returnList.Add(IntList[i] * IntList[i]);
    }
    return returnList;

}
List<int> TestIntList3 = new List<int>() { 1, 2, 3, 4, 5 };
List<int> squaredList = SquareValues(TestIntList3);
// You should get back [1,4,9,16,25], think about how you will show that this worked
Console.WriteLine($"Squared: [{string.Join(",", squaredList)}]");



static int[] NonNegatives(int[] IntArray)
{
    int[] returnArray = new int[IntArray.Length];

    for (int i = 0; i < IntArray.Length; i++)
    {
        if (IntArray[i] > 0)
        {
            returnArray[i] = IntArray[i];
        }
        else
        {
            returnArray[i] = 0;
        }
    }
    return returnArray;
}
int[] TestIntArray = new int[] { -1, 2, 3, -4, 5 };
// You should get back [0,2,3,0,5], think about how you will show that this worked
int[] NonNegList = NonNegatives(TestIntArray);
Console.WriteLine($"Non Negatives: [{string.Join(",", NonNegList)}]");




static void PrintDictionary(Dictionary<string, string> MyDictionary)
{
    foreach (KeyValuePair<string, string> item in MyDictionary)
    {
        Console.WriteLine($"Key: {item.Key} || Value: {item.Value}");
    }
}
Dictionary<string, string> TestDict = new Dictionary<string, string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);


static bool FindKey(Dictionary<string, string> MyDictionary, string SearchTerm)
{
    if (MyDictionary.ContainsKey(SearchTerm))
    {
        return true;
    }
    else
    {
        return false;
    }
}
// Use the TestDict from the earlier example or make your own
// This should print true
Console.WriteLine(FindKey(TestDict, "RealName"));
// This should print false
Console.WriteLine(FindKey(TestDict, "Name"));

