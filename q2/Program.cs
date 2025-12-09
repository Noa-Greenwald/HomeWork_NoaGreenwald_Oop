using System;

struct SmallStruct
{
    public int x; // 4 bytes
}

struct LargeStruct
{
    public double a; // 8 bytes
    public double b; // 8 bytes
    public int c;    // 4 bytes
}

class SmallClass
{
    public int x; // 4 bytes
}

class LargeClass
{
    public double a; // 8 bytes
    public double b; // 8 bytes
    public int c;    // 4 bytes
}

class Program
{
    public static void MemoryAllocationExperiment()
    {
        // מעקב אחרי זיכרון ראשוני
        long baselineMemory = GC.GetAllocatedBytesForCurrentThread();

        // 1. מערך אינטים
        int[] intArray = new int[10000];
        long afterIntArray = GC.GetAllocatedBytesForCurrentThread();

        // 2. מערך דאבלים
        double[] doubleArray = new double[10000];
        long afterDoubleArray = GC.GetAllocatedBytesForCurrentThread();

        // 3. מערך סטרינגים
        string[] stringArray = new string[10000];
        long afterStringArray = GC.GetAllocatedBytesForCurrentThread();

        // 4. מערכים של struct
        SmallStruct[] smallStructArray = new SmallStruct[10000];
        long afterSmallStructArray = GC.GetAllocatedBytesForCurrentThread();

        LargeStruct[] largeStructArray = new LargeStruct[10000];
        long afterLargeStructArray = GC.GetAllocatedBytesForCurrentThread();

        // 5. מערכים של class
        SmallClass[] smallClassArray = new SmallClass[10000];
        // צריך גם ליצור מופעים בפועל של כל האובייקטים
        for (int i = 0; i < smallClassArray.Length; i++)
            smallClassArray[i] = new SmallClass();
        long afterSmallClassArray = GC.GetAllocatedBytesForCurrentThread();

        LargeClass[] largeClassArray = new LargeClass[10000];
        for (int i = 0; i < largeClassArray.Length; i++)
            largeClassArray[i] = new LargeClass();
        long afterLargeClassArray = GC.GetAllocatedBytesForCurrentThread();

        // הדפסת הזיכרונות
        Console.WriteLine($"Baseline Memory: {baselineMemory} bytes");
        Console.WriteLine($"Int Array Allocation: {afterIntArray - baselineMemory} bytes");
        Console.WriteLine($"Double Array Allocation: {afterDoubleArray - afterIntArray} bytes");
        Console.WriteLine($"String Array Allocation: {afterStringArray - afterDoubleArray} bytes");
        Console.WriteLine($"Small Struct Array Allocation: {afterSmallStructArray - afterStringArray} bytes");
        Console.WriteLine($"Large Struct Array Allocation: {afterLargeStructArray - afterSmallStructArray} bytes");
        Console.WriteLine($"Small Class Array Allocation: {afterSmallClassArray - afterLargeStructArray} bytes");
        Console.WriteLine($"Large Class Array Allocation: {afterLargeClassArray - afterSmallClassArray} bytes");
    }

    static void Main(string[] args)
    {
        MemoryAllocationExperiment();
    }
}
