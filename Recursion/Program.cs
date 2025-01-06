namespace Recursion;

class Program
{
    public static void Main(string[] args)
    {
        Item key = new() { IsKey = true };
        Item innerBox = new() { IsBox = true, Contents = [key] };
        Item outerBox = new() { IsBox = true, Contents = [innerBox] };
        // Qutilarda kalitni qidiramiz
        LookForKey(key);
        LookForKey(innerBox);
        LookForKey(outerBox);

        static void LookForKey(Item box)
        {
            foreach (var item in box.Contents)
            {
                if (item.IsBox)
                {
                    LookForKey(item);
                }
                else if (item.IsKey)
                {
                    Console.WriteLine("Found the key!");
                    return;
                }
            }
        }
    }
}

class Item
{
    public bool IsBox { get; set; } // Element qutimi?
    public bool IsKey { get; set; } // Element kalitmi?
    public List<Item> Contents { get; set; } = [];
}