using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        static bool run = true;
        static void Main(string[] args)
        {           
            string s1, s2;
            int[] arr, array;
            int[,] arr1, arr2;

            do
            { 
                Console.WriteLine("1. Quiz");
                Console.WriteLine("2. ReadInteger");
                Console.WriteLine("3. PrintArray");
                Console.WriteLine("4. InString");
                Console.WriteLine("5. FindWord");
                Console.WriteLine("6. ConvertToHex");
                Console.WriteLine("7. Substitute");
                Console.WriteLine("8. SetArray");
                Console.WriteLine("9. ResizeArray");
                Console.WriteLine("10. IsPrime");
                Console.WriteLine("11. MatrixMultiply");

                int choice = Workshop.ReadInteger("Please enter the number for the method you want to test (Enter 0 to exit): ");

                switch (choice)
                {
                    case 1:
                        Quiz.Run();
                        break;
                    case 2:
                        Console.WriteLine(Workshop.ReadInteger("Please enter an integer: ") + " is entered correctly");
                        break;
                    case 3:
                        int arrSize = Workshop.ReadInteger("Enter the size of your array: ");                        
                        arr = Workshop.GetArray("Enter the array of integers seperated by ',': ", arrSize);
                        Workshop.PrintArray(arr);
                        break;
                    case 4:
                        //s1 = "Hello how are you?";
                        //s2 = "HoW are YOu";
                        Console.Write("Enter main string: ");
                        s1 = Console.ReadLine();
                        Console.Write("Enter what you want to search: ");
                        s2 = Console.ReadLine();
                        
                        if (Workshop.InString(s1, s2))
                            Console.WriteLine("\"{0}\" is in \"{1}\"", s2, s1);
                        else
                            Console.WriteLine("\"{0}\" is not in \"{1}\"", s2, s1);
                        break;
                    case 5:
                        Console.Write("Enter main string: ");
                        s1 = Console.ReadLine();
                        Console.Write("Enter what you want to search: ");
                        s2 = Console.ReadLine();
                        Console.WriteLine("Your search appears at index " + Workshop.FindWord(s1, s2));
                        break;
                    case 6:
                        int dec = Workshop.ReadInteger("Enter Decimal value to convert to Hex: ");
                        Console.WriteLine(Workshop.ConvertToHex(dec));
                        break;
                    case 7:
                        Console.Write("Enter main string: ");
                        s1 = Console.ReadLine();                        
                        char c1 = Workshop.ReadChar("Enter char to replace: ");
                        char c2 = Workshop.ReadChar("Replace with?: ");
                        Console.WriteLine(Workshop.Substitute(s1, c1, c2));
                        break;
                    case 8:
                        bool isArr = true;
                        arrSize = Workshop.ReadInteger("Enter size of array: ");
                        int value = Workshop.ReadInteger("Enter a value for all elements: ");
                        array = new int[arrSize];
                        Workshop.SetArray(array, value);
                        foreach (int i in array) Console.WriteLine(i);
                        break;
                    case 9:
                        isArr = true;
                        array = Workshop.GetArray("Enter the array of integers seperated by ',': ");
                        arrSize = Workshop.ReadInteger("Enter size of array to resize: ");
                        Workshop.ResizeArray(ref array, arrSize);
                        foreach (int i in array) Console.Write(i + ",");
                        Console.WriteLine("\b ");
                        break;
                    case 10:
                        Console.WriteLine("Prime numbers between 5 and 1000 are: ");
                        for (int i = 5; i <= 1000; i++)
                            if (Workshop.IsPrime(i)) Console.WriteLine(i);
                        break;
                    case 11:
                        arr1 = new int[,] { { 1, 2 ,3}, { 3, 4, 5 }, { 5, 6, 7 } };
                        arr2 = new int[,] { { 6, 7, 8, }, { 9, 8, 7, }, { 9, 8, 7 } };
                        try
                        {
                            int[,] arr12 = Workshop.MatrixMultiply(arr1, arr2);
                            Console.WriteLine("array 1: ");
                            Workshop.PrintMatrix(arr1);
                            Console.WriteLine("array 2: ");
                            Workshop.PrintMatrix(arr2);
                            Console.WriteLine("array 1 * array 2: ");
                            Workshop.PrintMatrix(arr12);
                        }
                        catch (InvalidMatrixException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 0:
                        run = false;
                        break;
                }
                Console.WriteLine();
            } while (run);
                    
        }
    }
}


                
        
    

