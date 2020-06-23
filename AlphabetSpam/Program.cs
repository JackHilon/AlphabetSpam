using System;

namespace AlphabetSpam
{
    class Program
    {
        static void Main(string[] args)
        {
            // AlphabetSpam
            // https://open.kattis.com/problems/alphabetspam 
            // -- check char isLower/isUpper/isSymbol --

            var mySeq = EnterLineCharArray();

            var result = ArrayStatistics(mySeq);

            var normalizedResult = ArrayDivideByNum(result, mySeq.Length);

            normalizedResult = MyArrayOperation(normalizedResult);

            PrintArray(normalizedResult);

        }
        private static double[] MyArrayOperation(double[] arr)
        {
            // this function is instead of --> part{*}  ... look below \|/ in CheckChar(char mychar) )
            arr[3] = 1 - (arr[0] + arr[1] + arr[2]);
            return arr;
        }


        private static int[] ArrayStatistics(char[] Sequence)
        {
            var result = new int[4] { 0, 0, 0, 0 };
            for (int i = 0; i < Sequence.Length; i++)
            {
                result = TwoArraySum(result, CheckChar(Sequence[i]));
            }
            return result;
        }

        private static void PrintArray(double[] myArray)
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                Console.WriteLine(myArray[i]);
            }
        }

        private static double[] ArrayDivideByNum(int[] arr, int n)
        {
            var res = new double[arr.Length];
            try
            {
                if (n == 0)
                    throw new DivideByZeroException();
                for (int i = 0; i < arr.Length; i++)
                {
                    res[i] = (double)arr[i] / n;
                    //res[i] = Math.Round(res[i],6);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return res;
            }
            return res;
        }
        private static int[] CheckChar(char myChar)
        {
            // whitespace characters, lowercase letters, uppercase letters, and symbols 

            var answer = new int[4] { 0, 0, 0, 0 };
            if (myChar == '_')
            {
                answer[0] = 1;
                return answer;
            }
            else if (char.IsLower(myChar))
            {
                answer[1] = 1;
                return answer;
            }
            else if (char.IsUpper(myChar))
            {
                answer[2] = 1;
                return answer;
            }                            // ======= Part {*} ================*#
            else if ((char.IsSymbol(myChar)||char.IsPunctuation(myChar))) //|*#
            {                                                             //|*#
                answer[3] = 1;                                            //|*#
                return answer;                                            //|*#
            } // ============================================================*#
            else 
                return answer;
        }
        
        private static char[] EnterLineCharArray()
        {
            string str = Console.ReadLine();
            int n = str.Length;
            char[] res= new char[n];
            try
            {
                res = str.ToCharArray();
                if (res.Length < 1 || res.Length > 100000)
                    throw new ArgumentException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return EnterLineCharArray();
            }
            return res;
        }
        private static int[] TwoArraySum(int[] a, int[] b)
        {
            var res = new int[a.Length];
            try
            {
                if (a.Length != b.Length)
                    throw new IndexOutOfRangeException();
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = a[i] + b[i];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = 0;
                }
                return res;
            }
            return res;
        }
    }
}
