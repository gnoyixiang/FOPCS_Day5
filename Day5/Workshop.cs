using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
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

            while (integer != 0)
            {
                hex = hexArray[integer % 16] + hex;
                integer /= 16;
            }
            return hex;
        }

        public static string Substitute(string s, char c1, char c2)
        {
            string replace = "";
            for (int i = 0; i < s.Length; i++)
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

            if (colsA != rowsB)
                throw new InvalidMatrixException("Matices do not multiply");
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

            if (colsA != rowsB)
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
                    Console.Write("{0,-5}", arr[i, j]);
                }
                Console.WriteLine("|");
            }
        }

        public static char ReadChar(string message)
        {
            char c;
            do
            {
                Console.Write(message);
            } while (!char.TryParse(Console.ReadLine(), out c));
            return c;
        }

        public static int[] GetArray(string message)
        {
            int[] arr;
            bool valid = true;
            string input;
            string[] strArr;
            int arrCount;
            do
            {
                arrCount = 0;
                Console.Write(message);
                input = Console.ReadLine();
                strArr = input.Split(' ', ',');
                arr = new int[strArr.Length];
                for (int i = 0; i < strArr.Length; i++)
                    if (strArr[i] != "" && int.TryParse(strArr[i], out arr[arrCount]))
                        arrCount++;
                if (arrCount == 0) valid = false;
            } while (!valid);
            int[] arrCopy = arr;
            arr = new int[arrCount];
            for (int i = 0; i < arrCount; i++)
                arr[i] = arrCopy[i];
            return arr;
        }

        public static int[] GetArray(string message, int arrSize)
        {
            int[] arr = new int[arrSize];
            bool valid = true;
            string input;
            string[] strArr;
            int arrCount;
            do
            {
                arrCount = 0;
                Console.Write(message);
                input = Console.ReadLine();
                strArr = input.Split(' ', ',');
                //if (strArr.Length != arrSize) valid = false;
                for (int i = 0; i < strArr.Length; i++)
                    if (strArr[i] != "" && int.TryParse(strArr[i], out arr[arrCount]))
                        arrCount++;
                if (arrCount == arrSize)
                    valid = true;
                else valid = false;
            } while (!valid);
            return arr;
        }

        public static void RemoveNullInArray<T>(ref T[] arr)
        {
            T[] arr1 = arr;
            int count = 0;
            for (int i = 0; i < arr1.Length; i++)
                if (arr1[i] != null) count++;
            arr = new T[count];
            count = 0;
            for (int i = 0; i < arr1.Length; i++)
                if (arr1[i] != null) { arr[count] = arr1[i]; count++; }
        }
    }

    class InvalidMatrixException : Exception
    {
        public InvalidMatrixException(string message) : base(message)
        {
          
        }
    }
    
}
