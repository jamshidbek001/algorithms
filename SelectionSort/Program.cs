namespace Algorithms.SelectionSort;

class Program
{
    public static void Main(string[] args)
    {
        // int[] numbers = [5,3,6,2,10,1,0,34,43];
        // // int smallestIndex = FindSmallest(numbers);
        // // Console.WriteLine($"The smallest element is at index : {smallestIndex}");

        // List<int> sortedNumbers = SelectionSort(numbers);
        // Console.WriteLine($"Sorted Numbers:" + string.Join(",", sortedNumbers));

        TestReverseArray();
        TestFindSecondLargest();
        TestMergedSortArrays();
        TestContainsDuplicates();
        TestRotateArray();
    }
        static int FindSmallest(List<int> arr)
        {
        int smallest = arr[0];
        int smallestIndex = 0;

        for(int i =1; i < arr.Count; i++)
        {
        if(arr[i] < smallest)
        {
        smallest = arr[i];
        smallestIndex = i;
        }
        }
        return smallestIndex;
        }

        static List<int> SelectionSort(int[] arr)
        {
        List<int> newArr = [];
        List<int> copiedArr = [.. arr];

        for(int i = 0; i < arr.Length; i++)
        {
        int smallestIndex = FindSmallest(copiedArr);
        newArr.Add(copiedArr[smallestIndex]);
        copiedArr.RemoveAt(smallestIndex);
        }
        return newArr;
        }


        // TASK 1. Reverse an array
        static void ReverseArray(int[] arr)
        {
        int i = 0,j = arr.Length - 1;
        while(i < j)
        {
        (arr[j], arr[i]) = (arr[i], arr[j]);
        i++;
        j--;
        }
        }

        static void TestReverseArray()
        {
        int[] array = [1,2,3,4,5];
        Console.WriteLine($"Original array : " + string.Join(",",array));
        ReverseArray(array);
        Console.WriteLine($"Reversed array : " + string.Join(",",array));
        Console.WriteLine("----------------------------------------");
        }

        // TASK 2. Find second largest element
        static int FindSecondLargest(int[] arr)
        {
        int largest = int.MinValue,secondLargest  = int.MinValue;
        foreach(int num in arr)  // num = 10
        {
        if(num > largest)    // true
        {
        secondLargest = largest;
        largest = num;   // 
        }
        else if(num > secondLargest && num != largest)
        {
        secondLargest = num;
        }
        }
        return secondLargest;
        }

        static void TestFindSecondLargest()
        {
        int[] arr = [10];
        Console.WriteLine($"Second largest element in array : " + FindSecondLargest(arr));
        Console.WriteLine("----------------------------------------");
        }
        // TASK 3. Merge two sorted array
        static int[] MergeSortedArrays(int[] arr1,int[] arr2)
        {
        int i = 0,j = 0;
        List<int> merged = [];

        while(i < arr1.Length && j < arr2.Length)
        {
        if(arr1[i] < arr2[j])
        {
        merged.Add(arr1[i]);
        i++;
        }
        else
        {
        merged.Add(arr2[j]);
        j++;
        }
        }
        while(i < arr1.Length) merged.Add(arr1[i++]);
        while(j < arr2.Length) merged.Add(arr2[j++]);

        return [.. merged];
        }

        static void TestMergedSortArrays()
        {
        int[] arr1 = [1, 3, 5];
        int[] arr2 = [2, 4, 6];
        Console.WriteLine($"First original array : " + string.Join(",",arr1));
        Console.WriteLine($"Second original array : " + string.Join(",",arr2));
        Console.WriteLine($"Merged array : " + string.Join(",", MergeSortedArrays(arr1,arr2)));
        Console.WriteLine("----------------------------------------");
        }

        // TASK 4. Check if array contains duplicates
        static bool ContainsDuplicates(int[] arr)
        {
        HashSet<int> seen = [];
        foreach(int num in arr)
        {
        if(seen.Contains(num)) return true;
        seen.Add(num);
        }
        return false;
        }

        static void TestContainsDuplicates()
        {
        int[] arr = [1, 2, 3,4,5,6];
        Console.WriteLine("Contains Duplicates: " + ContainsDuplicates(arr));
        Console.WriteLine("----------------------------------------");
        }
        // TASK 5. Rotate Array by K Positions
        static void RotateArray(int[] arr, int k)
        {
        k %= arr.Length;

        Reverse(arr, 0, arr.Length - 1);
        Reverse(arr, 0, k - 1);
        Reverse(arr, k, arr.Length - 1);
        }

        static void Reverse(int[] arr, int start, int end)
        {
        while (start < end)
        {
        (arr[end], arr[start]) = (arr[start], arr[end]);
        start++;
        end--;
        }
        }

        static void TestRotateArray()
        {
        int[] arr = [1, 2, 3, 4, 5];
        Console.WriteLine("Original Array: " + string.Join(", ", arr));
        RotateArray(arr, 2);
        Console.WriteLine("Rotated Array: " + string.Join(", ", arr));
        Console.WriteLine("----------------------------------------");
        }

        // Linked List Tasks
        // TASK 6.Implement a Singly Linked List
        class Node(int data)
        {
        public int Data { get; set; } = data;
        public Node Next { get; set; } = null!;
        }
        class LinkedListMy
        {
        private Node? head;

        public void Add(int data)
        {
        Node newNode = new Node(data);
        if(head == null)
        {
        head = newNode;
        }
        else
        {
        Node temp = head;
        while(temp.Next != null) temp = temp.Next;
        temp.Next = newNode;
        }
        }
        public void Print()
        {
        Node temp = head!;
        while (temp != null)
        {
        Console.Write(temp.Data + " -> ");
        temp = temp.Next;
        }
        Console.WriteLine("null");
        }
        }

        static void TestLinkedList()
        {
        LinkedListMy list = new();
        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Print();
        }
        // TASK 7. Find the Middle Node
        // TASK 8. Reverse a Linked List
        // TASK 9. Detect a Cycle in a Linked List
        // TASK 10. Merge Two Sorted Linked Lists
}