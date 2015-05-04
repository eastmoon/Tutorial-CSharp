using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Collection class
            // ref : https://msdn.microsoft.com/zh-tw/library/ybcx56wz.aspx#BKMK_Collections
            Program root = new Program();
            root.OperateArray();
            root.OperateArrayList();
            root.OperateHashtable();
            root.ComparePerformanceArrayList();
            //root.ComparePerformanceHashtable();
        }

        public void OperateArray()
        {
            // ref : https://msdn.microsoft.com/zh-tw/library/system.array%28v=vs.110%29.aspx
            Console.WriteLine("\n----- Array -----");
            int i = 0, j = 0, k = 0;

            // Create
            Console.WriteLine(">> Create");
            int[] a1 = new int[5] {1,2,3,4,5};
            for( i = 0 ; i < a1.Length ; i++ )
            {
                Console.Write(a1[i] + "\t");
            }
            Console.Write("\n");
            // 
            Console.WriteLine(">> Create by instance");
            Array a2 = Array.CreateInstance(typeof(Int32), a1.Length);
            for( i = 0 ; i < a2.Length ; i++ )
            {
                a2.SetValue(a1[i], i);
                Console.Write(a2.GetValue(i) + "\t");
            }
            Console.Write("\n");
        }

        public void OperateArrayList()
        {
            // ref : https://msdn.microsoft.com/zh-tw/library/system.collections.arraylist.aspx
            Console.WriteLine("\n----- ArrayList -----");
            int i = 0, j = 0, k = 0;

            // Create
            Console.WriteLine(">> Create");
            ArrayList a1 = new ArrayList();

            for (i = 0; i < 5; i++)
            {
                // Insert
                a1.Add(i + 1);
                Console.Write(a1[i] + "\t");
            }
            Console.Write("\n");
        }

        public void OperateHashtable()
        {
            // ref : https://msdn.microsoft.com/zh-tw/library/system.collections.hashtable.aspx
            Console.WriteLine("\n----- Hashtable -----");
            int i = 0, j = 0, k = 0;

            // Create
            Console.WriteLine(">> Create");
            Hashtable a1 = new Hashtable();

            for( i = 0 ; i < 5 ; i++ )
            {
                // Insert
                a1.Add(i.ToString(), (i + 1));
                Console.Write(a1[i.ToString()] + "\t");
            }
            Console.Write("\n");
        }

        public void ComparePerformanceArrayList(int loop = 10000000)
        {
            Console.WriteLine("\n----- Compare Performance Array and ArrayList -----");
            int i = 0, j = 0, k = 0;
            Stopwatch timer = new Stopwatch();
            TimeSpan timespan;
            // Create Array
            int[] array = new int[5] { 1, 1, 1, 1, 1 };
            // Create ArrayList
            ArrayList arrayList = new ArrayList();
            for (i = 0; i < 5; i++)
                arrayList.Add(1);

            // Performace calculation : Array
            timer.Restart();
            for (k = 0, i = 0; i < loop; i++)
            {
                k += array[i % array.Length];
            }
            timer.Stop();
            timespan = timer.Elapsed;
            Console.WriteLine("Array Calculate : {0}", k);
            Console.WriteLine("Total time : {0:00}:{1:00}:{2:000}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds);

            // Performace calculation : ArrayList
            timer.Restart();
            for (k = 0, i = 0; i < loop; i++)
            {
                k += (int)arrayList[i % arrayList.Count];
            }
            timer.Stop();
            timespan = timer.Elapsed;
            Console.WriteLine("ArrayList Calculate : {0}", k);
            Console.WriteLine("Total time : {0:00}:{1:00}:{2:000}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds);

        }

        public void ComparePerformanceHashtable(int loop = 10000000)
        {
            Console.WriteLine("\n----- Compare Performance ArrayList and Hasttable -----");
            int i = 0, j = 0, k = 0;
            Stopwatch timer = new Stopwatch();
            TimeSpan timespan;

            // Create hashtable
            Hashtable hashtable = new Hashtable();
            for( i = 0 ; i < 5 ; i++ )
                hashtable.Add(i.ToString(), new Unit());

            // Create arrayList
            ArrayList index = new ArrayList();
            ArrayList value = new ArrayList();
            for (i = 0; i < 5; i++)
            {
                index.Add(i.ToString());
                value.Add(new Unit());
            }

            // Performace calculation : hashtable
            timer.Restart();
            for (k = 0, i = 0; i < loop; i++)
            {
                k += ((Unit)hashtable[(i % hashtable.Count).ToString()]).GetValue();
            }
            timer.Stop();
            timespan = timer.Elapsed;
            Console.WriteLine("Hashtable Calculate : {0}", k);
            Console.WriteLine("Total time : {0:00}:{1:00}:{2:000}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds);

            // Performace calculation : ArrayList
            timer.Restart();
            for (k = 0, i = 0; i < loop; i++)
            {
                for (j = 0; j < index.Count; j++)
                {
                    if (((string)index[j]) == (i % index.Count).ToString())
                    {
                        k += ((Unit)value[j]).GetValue();
                        break;
                    }
                }
            }
            timer.Stop();
            timespan = timer.Elapsed;
            Console.WriteLine("ArrayList Calculate : {0}", k);
            Console.WriteLine("Total time : {0:00}:{1:00}:{2:000}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds);

        }
    }

    class Unit
    {
        public int GetValue()
        {
            return 1;
        }
    }
}
