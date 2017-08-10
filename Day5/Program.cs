using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            //Quiz.Run();

            //Console.WriteLine(Workshop.ReadInteger("Please enter an integer: "));

            //int[] arr = new int[] { 3, 4, 5, 6, 0, 9, 8, 7, 2, 1 };
            //Workshop.PrintArray(arr);

            //string s1 = "Hello how are you?";
            //string s2 = "HoW are YOu";

            //if (Workshop.InString(s1, s2))
            //    Console.WriteLine("\"{0}\" is in \"{1}\"", s2, s1);
            //else
            //    Console.WriteLine("\"{0}\" is not in \"{1}\"", s2, s1);

            //Console.WriteLine(Workshop.FindWord(s1, s2));

            //Console.WriteLine(Workshop.ConvertToHex(1128));

            //int[] arr = new int[5];
            //Workshop.SetArray(arr, 10);
            //foreach (int i in arr) Console.WriteLine(i);
            //Console.WriteLine();
            //Workshop.ResizeArray(ref arr, 10);
            //foreach (int i in arr) Console.WriteLine(i);

            //for (int i = 5; i <= 1000; i++)
            //    if (Workshop.IsPrime(i)) Console.WriteLine(i);

            //int[,] arr1 = { { 2, 3 }, { 3, 4 }, { 4, 5 } };
            
            //int[,] arr2 = { { 5, 6, 7, 8 }, { 8, 7, 6, 5 }, { 8, 7, 6, 5 }, { 8, 7, 6, 5 } };
            //int[,] arr12 = Workshop.MatrixMultiply(arr1, arr2);
            //Workshop.PrintMatrix(arr12);
        }
    }

    class Quiz
    {
        public static void Run()
        {
            int[,] theArray = new int[,]
            {
                {5,3}, {2,9}, {2,9 },
                {5,1 }, {7,1 }, {8,3 },
                {0,3 }, {2,2 }, {9,7 }
            };

            int count = 0;

            Console.Write("Please enter a number (0-9): ");
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < theArray.GetLength(0); i++)
                for (int j = 0; j < theArray.GetLength(1); j++)
                    if (input == theArray[i, j])
                        count++;
            if (count != 0) Console.WriteLine("The number of {0} is {1}", input, count);
            else Console.WriteLine("Ther is no {0} in the array", input);

        }
    }

    class Workshop
    {
        public static int ReadInteger(string message)
        {
            int integer = -1;

            //do
            //{
            //    Console.Write(message);
            //} while (!int.TryParse(Console.ReadLine(), out integer));

            bool invalid;
            do
            {
                try
                {
                    Console.Write(message);
                    integer = Convert.ToInt32(Console.ReadLine());
                    invalid = false;
                }
                catch (FormatException e)
                {
                    invalid = true;
                }                
            }
            while (invalid);
            return integer;
        }

        public static void PrintArray(int[] arr)
        {
            string output = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                    output += arr[i];
                else
                    output += arr[i] + ", ";
            }
            Console.WriteLine(output);
        }

        public static bool InString(string s1, string s2)
        {
            bool inString;

            //if (s1.ToUpper().IndexOf(s2.ToUpper()) == -1) inString = false;
            //else inString = true;
            //return inString;

            int count = 0;
            inString = false;
            for (int i = 0; i < s1.Length; i++)
            {
                if (count == s2.Length)
                {
                    inString = true;
                    break;
                }
                else count = 0;
                for (int j = 0; j < s2.Length; j++)
                    if (Char.ToUpper(s1[i + j]) == Char.ToUpper(s2[j]))
                        count++;
            }
            return inString;
        }

        public static int FindWord(string s1, string s2)
        {
            int index = -1;

            //index = s1.ToUpper().IndexOf(s2.ToUpper());
            //return index;

            int count = 0;
            for (int i = 0; i < s1.Length; i++)
            {
                if (count == s2.Length)
                {
                    index = i - 1;
                    break;
                }
                else count = 0;
                for (int j = 0; j < s2.Length; j++)
                    if (Char.ToUpper(s1[i + j]) == Char.ToUpper(s2[j]))
                        count++;
            }
            return index;
        }

        public static string ConvertToHex(int integer)
        {
            string hex = "";
            char[] hexArray = new char[] 
            {'0', '1', '2', '3',
             '4', '5', '6', '7',
             '8', '9', 'A', 'B',
             'C', 'D', 'E', 'F'};
            
            while (integer!=0)
            {
                hex = hexArray[integer % 16] + hex;
                integer /= 16;
            }
            return hex;
        }

        public static string Substitute(string s, char c1, char c2)
        {
            string replace = "";
            for(int i = 0; i<s.Length;i++)
                if (s[i] == c1) replace += c2;
                else replace += s[i];
            return replace;
        }

        public static void SetArray(int[] arr, int value)
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] = value;
        }

        public static void ResizeArray(ref int[] arr, int newSize)
        {
            int[] arrCopy = arr;
            arr = new int[newSize];
            for (int i = 0; i < arrCopy.Length; i++)
                arr[i] = arrCopy[i];
        }

        public static bool IsPrime(int n)
        {
            bool prime = true;
            for (int i = 2; i < n; i++)
                if (n % i == 0)
                {
                    prime = false;
                    break;
                }
            return prime;
        }

        public static int[,] MatrixMultiply(int[,] A, int[,] B)
        {
            int rowsA = A.GetLength(0), colsA = A.GetLength(1);
            int rowsB = B.GetLength(0), colsB = B.GetLength(1);
                                   
            int[,] AB = new int[rowsA, colsB];
            
            
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (int c = 0; c < colsA; c++)
                        AB[i, j] += A[i, c] * B[c, j];                    
                }                    
            }
            return AB;
        }

        public static bool TryMatrixMultiply(int[,] A, int[,] B, out int[,] AB)
        {
            bool valid = true;

            int rowsA = A.GetLength(0), colsA = A.GetLength(1);
            int rowsB = B.GetLength(0), colsB = B.GetLength(1);

            AB = new int[rowsA, colsB];

            if (colsA!=rowsB)
            {
                valid = false;
            }
            else
            {
                AB = MatrixMultiply(A, B);
            }
            return true;
        }

        public static void PrintMatrix(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write("| ");
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j]);
                    if (j != arr.GetLength(1) - 1) Console.Write(" , ");
                }
                Console.WriteLine(" |");                
            }
        }        
        
        
        
    }
}
