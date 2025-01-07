using System.Diagnostics;

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
        Countdown(5);
        TestFactorial();
        TestIsPowerOfTwo();

        static void TestIsPowerOfTwo()
        {
            Stopwatch stopwatch = new();
            Console.WriteLine("Son kiriting: ");
            int i = int.Parse(Console.ReadLine()!);
            stopwatch.Start();
            bool result = IsPowerOfTwo(i);
            stopwatch.Stop();

            if(result)
                Console.WriteLine($"{i} ikkini darajasi!");
            else 
                Console.WriteLine($"{i} ikkini darajasi emas!");

            Console.WriteLine($"Vaqt : {stopwatch.ElapsedMilliseconds} millisekund");
        }

        static bool IsPowerOfTwo(int n)
        {
            if(n ==1 ) return true;
            if(n < 0 || n % 2 != 0) return false;
            
            return IsPowerOfTwo(n / 2);
        }

        static void TestFactorial()
        {
            Console.WriteLine("Factorialorialni hisbolash uchun son kiriting: ");
            int n = int.Parse(Console.ReadLine()!);
            int result = Factorial(n);
            Console.WriteLine($"{n}! == {result}");
        }

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

        static void Countdown(int i)
        {
            Console.WriteLine(i);

            if(i <= 1)
            {
                return;
            }
            else
            {
                Countdown(i - 1);
            }
        }

        static int Factorial(int x)
        {
            if(x == 1)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x -1);
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