
Console.WriteLine("Hello, World!");

int[] numbers = [5,3,6,2,10,1,0,34,43];
// int smallestIndex = FindSmallest(numbers);
// Console.WriteLine($"The smallest element is at index : {smallestIndex}");

List<int> sortedNumbers = SelectionSort(numbers);
Console.WriteLine($"Sorted Numbers:" + string.Join(",", sortedNumbers));

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

