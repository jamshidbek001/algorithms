using System.Text.Json;

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

Dictionary<string, string> phoneBook = new()
{
    { "Alice", "12345" },
    { "Bob", "67890" },
    { "Charlie", "54321" }
};

string targetNumber = "12345";
string foundName = null!;

foreach (var entry in phoneBook)
{
    if (entry.Value == targetNumber)
    {
        foundName = entry.Key;
        break;
    }
}

if (foundName != null)
{
    Console.WriteLine($"The phone number {targetNumber} belongs to {foundName}.");
}
else
{
    Console.WriteLine("Phone number not found.");
}


// Exercise 2. Read All Numbers in the Phone Book

Dictionary<string, string> phoneBook2 = new()
{
    { "Alice", "12345" },
    { "Bob", "67890" },
    { "Charlie", "54321" }
};

Console.WriteLine("All phone numbers in the phone book");
foreach (var entry in phoneBook2)
{
    Console.WriteLine($"{entry.Key} : {entry.Value}");
}

// Exercise 3. Read Numbers of Just the 'A's

Dictionary<string, string> phoneBook3 = new()
{
    { "Alice", "12345" },
    { "Bob", "67890" },
    { "Charlie", "54321" }
};

Console.WriteLine("Phone numbers for people whose names starts with 'A'");
foreach (var entry in phoneBook3)
{
    if (entry.Key.StartsWith('A'))
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
foreach (var entry in reversed)
{
    Console.WriteLine($"{entry.Key} : {string.Join(",", entry.Value)}");
}

Console.WriteLine("\nCount of initials:");
CountInitials(phoneBook4);

Console.WriteLine("\nLongest Name:");
Console.WriteLine(FindLongestName(phoneBook4));

Console.WriteLine("\nPhone book without duplicates:");
RemoveDuplicates(phoneBook4);

Console.WriteLine("\nGroup by phone number length:");
GroupByPhoneNumberLength(phoneBook4);

Console.WriteLine("\nSearch by partial name (Example : 'af'):");
var matches = SearchByPartialName(phoneBook, "Al");
foreach (var match in matches)
{
    Console.WriteLine(match);
}

Console.WriteLine("\nCheck for invalid phone number:");
CheckInvalidPhoneNumber(phoneBook4);

Console.WriteLine("\nTop 2 names:");
ListTopNames(phoneBook4, 2);

Console.WriteLine("\nPhone Book as Json:");
Console.WriteLine(ConvertToJson(phoneBook4));

// TASK 1. Reverse Phone Book
static Dictionary<string, List<string>> ReversePhoneBook(Dictionary<string, string> phoneBook)
{
    var reversed = new Dictionary<string, List<string>>();
    foreach (var entry in phoneBook)
    {
        if (!reversed.ContainsKey(entry.Value))
        {
            reversed[entry.Value] = [];
        }
        reversed[entry.Value].Add(entry.Key);
    }
    return reversed;
}

// TASK 2. Count the people with same initial -->
void CountInitials(Dictionary<string, string> phoneBook)
{
    var counts = new Dictionary<char, int>();
    foreach (var name in phoneBook.Keys)
    {
        char initial = name[0];
        if (!counts.ContainsKey(initial))
        {
            counts[initial] = 0;
        }
        counts[initial]++;
    }
    foreach (var entry in counts)
    {
        Console.WriteLine($"{entry.Key} : {entry.Value}");
    }
}

// TASK 3. Find the longest name
static string? FindLongestName(Dictionary<string, string> phoneBook) =>
    phoneBook.Keys.OrderByDescending(name => name.Length).FirstOrDefault();

// TASK 4.Remove duplicates
static void RemoveDuplicates(Dictionary<string, string> phoneBook)
{
    var uniquPhoneBook = phoneBook.GroupBy(entry => new { entry.Key, entry.Value })
        .Select(group => group.First())
        .ToDictionary(entry => entry.Key, entry => entry.Value);

    foreach (var entry in uniquPhoneBook)
    {
        Console.WriteLine($"{entry.Key} : {entry.Value}");
    }
}


// TASK 5.Group by phone number length
static void GroupByPhoneNumberLength(Dictionary<string, string> phoneBook)
{
    var grouped = phoneBook.GroupBy(entry => entry.Value.Length)
        .ToDictionary(group => group.Key, group => group.Select(entry => entry.Key).ToList());

    foreach (var group in grouped)
    {
        Console.WriteLine($"Length {group.Key} : {string.Join(",", group.Value)}");
    }
}

// TASK 6.Search with partial name match
static List<string> SearchByPartialName(Dictionary<string, string> phoneBook, string substring)
    => phoneBook.Keys.Where(name => name.Contains(substring, StringComparison.OrdinalIgnoreCase)).ToList();

// TASK 7.Check for Invalid Phone Number
static void CheckInvalidPhoneNumber(Dictionary<string, string> phoneBook)
{
    foreach (var entry in phoneBook)
    {
        if (!entry.Value.All(char.IsDigit) || entry.Value.Length != 10)
        {
            Console.WriteLine($"{entry.Key} has an invalid phone number : {entry.Value}");
        }
    }
}

// TASK 8.List Top N names
static void ListTopNames(Dictionary<string, string> phoneBook, int n)
{
    var topNames = phoneBook.Keys.OrderBy(name => name).Take(n);
    foreach (var name in topNames)
    {
        Console.WriteLine(name);
    }
}

// TASK 9.Convert to JSON
static string ConvertToJson(Dictionary<string, string> phoneBook)
    => JsonSerializer.Serialize(phoneBook);