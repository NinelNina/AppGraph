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

            StreamReader input;

            try
            {
                input = new StreamReader("input.txt");
            }
            catch
            {
                Console.WriteLine("Ошибка! Файл не найден.");
                return;
            }

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

            Dictionary<string, List<string>> values = new Dictionary<string, List<string>>();
            
            for (int i = 0; i < N; i++)
            {
                if (!values.ContainsKey(currency[i, 0]))
                {
                    values[currency[i, 0]] = new List<string>();
                }
                values[currency[i, 0]].Add(currency[i, 1]);
            }

            Queue<string> queue = new Queue<string>();
            queue.Enqueue(source);
            HashSet<string> visited = new HashSet<string>();
            Dictionary<string, string> route = new Dictionary<string, string>();

            bool found = false;
            while (queue.Count != 0)
            {
                var i = queue.Dequeue();
                visited.Add(i);

                if (i == dest)
                {
                    found = true;
                    break;
                }
                else
                {
                    if (values.ContainsKey(i))
                    {
                        foreach (var child in values[i])
                        {
                            if (!visited.Contains(child))
                            {
                                route[child] = i;
                                queue.Enqueue(child);
                            }
                        }
                    }
                }
                    
            }

            List<string> result = new List<string>();
            if (found)
            {
                string key = dest;
                while (route.ContainsKey(key))
                {
                    result.Add(key);
                    key = route[key];
                }
            }

            result.Add(source);

            StreamWriter output = new StreamWriter("output.txt");

            for (int i = N-1; i >= 0; i--)
            {
                output.Write(result[i] + " ");
            }

            Console.WriteLine("Файл output.txt сформирован.");

            Console.ReadKey();
        }
    }
}
