using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // StringBuilder s = new StringBuilder("abcd_efgh_ijkl_mnop_qrsty_uwvxz");

            Merge(new List<int> {1 , 3 , 5 }, new List<int> { 2, 4, 6 });

            Console.ReadKey();
        }

        #region Functions

        static void Merge(List<int> a,List<int> b)
        {
            int i = 0;
            int j = 0;
            List<int> c = new List<int>();
            int end = a.Count < b.Count ? a.Count : b.Count ;
            while(i < end && j < end)
            {
                if(a[i] <= b[j])
                {
                    c.Add(a[i]);
                    i++;
                }
                if (i == a.Count)
                {
                    while(j < b.Count)
                    {
                        c.Add(b[j]);
                        j++;
                    }
                    break;
                }
                if(a[i] >= b[j])
                {
                    c.Add(b[j]);
                    j++;
                }
                
                if(j == b.Count)
                {
                    while(i < a.Count)
                    {
                        c.Add(a[i]);
                        i++;
                    }
                }
            }
            Console.ReadKey();
        }


        static int UniqueUnsortedList(List<int> unsortedList)
        {
            int unique = 0;
            Dictionary<int, int> table = new Dictionary<int, int>();
            
            for(int i = 0; i < unsortedList.Count; i++)
            {
                try
                {
                   table.Add(unsortedList[i], 1);
                }
                catch
                { 
                    table[unsortedList[i]]++;
                }
            }

            foreach(KeyValuePair<int,int> num in table)
            {
                if(num.Value == 1)
                {
                    unique++;
                }
            }
            
            return unique;
        }

        static bool IsOdd(int num)
        {
            bool result = true;
           
            for(int i = 2; i <= Math.Sqrt(num); i++)
            {
                if(num % i == 0)
                {
                    result = false;
                    break;
                }
                else
                {
                    result = true;
                }
            }
            return result;
        }


        static void ChangeOrder(ref StringBuilder s)
        {
            int wordstart = 0;
            int wordend = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '_')
                {
                    wordend = i;
                    Swap(ref s, ref wordstart, wordend);
                }
                if (i == s.Length - 1 && s[i] != '_')
                {
                    Swap(ref s, ref wordstart, s.Length);
                }
            }
        }

        static void Swap(ref StringBuilder s,ref int wordstart, int wordend)
        {
            for(int j = 0; j < (wordend-wordstart)/2; j++)
            {
                char holder = s[wordstart + j];
                s[wordstart + j] = s[wordend - j - 1];
                s[wordend - j - 1] = holder;
            }
            wordstart = wordend + 1;
        }
        #endregion
    }
}
