using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            Dictionary<string, int> dic = new Dictionary<string, int>();

            try
            {
                using(StreamReader sr = new StreamReader(path))
                {                       
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string candidate = line[0];
                        int votes = int.Parse(line[1]);
                        if(!dic.ContainsKey(candidate))
                        dic.Add(candidate, votes);
                        else
                        {                            
                            dic[candidate] += votes;
                        }                        
                    }
                }                

                foreach(var item in dic)
                {
                    Console.WriteLine(item.Key + ": " + item.Value);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Error when reading the file: " + e.Message);
            }
        }
    }
}
