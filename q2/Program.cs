using System;
<<<<<<< HEAD

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
=======
using System.Diagnostics;

class Program
{
    static void Main()
    {
        const int n = 50_000_000;
        int[] arr = new int[n];
        long sum = 0;

        for (int i = 0; i < n; i++)
            arr[i] = i;

        Stopwatch sw = new Stopwatch();

        // 1. גישה רציפה
        sw.Start();
        for (int i = 0; i < n; i++)
        {
            sum += arr[i];
        }
        sw.Stop();
        Console.WriteLine("Sequential access: " + sw.ElapsedMilliseconds + " ms");

        // 2. גישה בקפיצות (Strided)
        sw.Reset();
        sw.Start();

        int stride = 1024;
        int index = 0;

        for (int i = 0; i < n; i++)
        {
            sum += arr[index];
            index = (index + stride) % n;
        }

        sw.Stop();
        Console.WriteLine("Strided access:   " + sw.ElapsedMilliseconds + " ms");

        // 3. גישה אקראית
        Random rnd = new Random();
        sw.Reset();
        sw.Start();

        for (int i = 0; i < n; i++)
        {
            int randomIndex = rnd.Next(n);
            sum += arr[randomIndex];
        }

        sw.Stop();
        Console.WriteLine("Random access:    " + sw.ElapsedMilliseconds + " ms");

        Console.WriteLine("sum = " + sum);
>>>>>>> 57f3d73 (Add project files.)
    }
}
