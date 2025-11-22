using System;

class Program
{
    static int counter = 0;

    struct PointStruct
    {
        public int X;
        public int Y;
    }

    static void Recursion()
    {
         //int[] arr = new int[5];
        //int[] arr = new int[10];
       int[] arr = new int[100];


        PointStruct p1, p2, p3, p4;
        PointStruct p5, p6, p7, p8;//האחרון היה 7961

        PointStruct p9, p10, p11, p12;//הוספתי בידקה נוספת האחרון היה 6826
      //  PointStruct p13, p14, p15, p16, p17, p18, p19, p20;//ועוד בדיקה והאחרון היה 5133
        counter++;
        Console.WriteLine($"counter={counter}");
        Recursion();
    }

    static void Main()
    {
        Recursion();
    }
}
