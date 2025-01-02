using System.Globalization;

int[] myArr = [1, 3, 5, 7, 9];
Console.WriteLine(BinarySearch(myArr, 11));

static int BinarySearch(int[] arr, int item)
{
    var low = 0;
    var high = arr.Length - 1;

    while (low <= high)
    {
        int midd = (low + high) / 2;
        int guess = arr[midd];
        if (guess == item)
        {
            return midd;
        }
        else if (guess > item)
        {
            high = midd - 1;
        }
        else
        {
            low = midd + 1;
        }
    }
    return -1;
}

// Exercise 1.You have a name, and you want to find the person’s phone number in the phone book.
// Since I don't know the order of phone numbers, i'll need to perform a LINEAR SEARCH -->

Dictionary<string,string> phoneBook = new()
{
    { "Alice", "12345" },
    { "Bob", "67890" },
    { "Charlie", "54321" }
};

string targetNumber = "12345";
string foundName = null!;

foreach(var entry in phoneBook)
{
    if(entry.Value == targetNumber)
    {
        foundName = entry.Key;
        break;
    }
}

if(foundName != null)
{
    Console.WriteLine($"The phone number {targetNumber} belongs to {foundName}.");
}
else
{
    Console.WriteLine("Phone number not found.");
}


// Exercise 2. Read All Numbers in the Phone Book

Dictionary<string,string> phoneBook2 = new()
{
    { "Alice", "12345" },
    { "Bob", "67890" },
    { "Charlie", "54321" }
};

Console.WriteLine("All phone numbers in the phone book");
foreach(var entry in phoneBook2)
{
    Console.WriteLine($"{entry.Key} : {entry.Value}");
}

// Exercise 3. Read Numbers of Just the 'A's

Dictionary<string,string> phoneBook3 = new()
{
    { "Alice", "12345" },
    { "Bob", "67890" },
    { "Charlie", "54321" }
};

Console.WriteLine("Phone numbers for people whose names starts with 'A'");
foreach(var entry in phoneBook3)
{
    if(entry.Key.StartsWith('A'))
    {
        Console.WriteLine($"{entry.Key} : {entry.Value}");
    }
}

Dictionary<string, string> phoneBook4 = new()
{
    { "Alice", "12345" },
    { "Alan", "54321" },
    { "Bob", "67890" },
    { "Charlie", "98765" },
    { "Dan", "1234567890" }
};
Console.WriteLine("Reversed phone book");
var reversed = ReversePhoneBook(phoneBook4);
foreach(var entry in reversed)
{
    Console.WriteLine($"{entry.Key} : {string.Join(",",entry.Value)}");
}

// TASK 1. Reverse Phone Book
static Dictionary<string,List<string>> ReversePhoneBook(Dictionary<string,string> phoneBook)
{
    var reversed = new Dictionary<string,List<string>>();
    foreach(var entry in phoneBook)
    {
        if(!reversed.ContainsKey(entry.Value))
        {
            reversed[entry.Value] = [];
        }
        reversed[entry.Value].Add(entry.Key);
    }
    return reversed;
}