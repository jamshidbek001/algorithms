int[] numbers = [5,3,6,2,10,1,0,34,43];
// int smallestIndex = FindSmallest(numbers);
// Console.WriteLine($"The smallest element is at index : {smallestIndex}");

List<int> sortedNumbers = SelectionSort(numbers);
Console.WriteLine($"Sorted Numbers:" + string.Join(",", sortedNumbers));

TestReverseArray();

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
}

// TASK 2. Find second largest element
// TASK 3. Merge two sorted array
// TASK 4. Check if array contains duplicates
// TASK 5. // TASK 4. Check if array contains duplicates
// Linked List Tasks
// TASK 6.Implement a Singly Linked List
// TASK 7. Find the Middle Node
// TASK 8. Reverse a Linked List
// TASK 9. Detect a Cycle in a Linked List
// TASK 10. Merge Two Sorted Linked Lists
