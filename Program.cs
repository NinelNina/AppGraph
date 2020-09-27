using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AppGraph
{
    class Program
    {
        static void Main()
        {
            string str, source, dest;
            int N;
            
            StreamReader input = new StreamReader("input.txt");

            str = input.ReadLine();
            source = str.Split(' ')[0];
            dest = str.Split(' ')[1];

            N = Convert.ToInt32(input.ReadLine());

            string[,] currency = new string[N, 2];

            for (int i = 0; i < N; i++)
            {
                str = input.ReadLine();
                for (int j = 0; j < 2; j++)
                {
                   currency[i, j] = str.Split(' ')[j];
                }
            }

            Dictionary<int, string> values = new Dictionary<int, string>(N);
            int k = 0;
            
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (values.ContainsValue(currency[i, j]) == false)
                    {
                        k++;
                        values.Add(k, currency[i, j]);
                    }

                }
            }

            Console.ReadKey();
        }
    }
}
