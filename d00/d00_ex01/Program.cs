using System;
using System.IO;

namespace ex01
{
    class Program
    {
        public static int LevenshteinDistance(string string1, string string2)
        {
            if (string1 == null) throw new ArgumentNullException("string1");
            if (string2 == null) throw new ArgumentNullException("string2");
            int diff;
            int[,] m = new int[string1.Length + 1, string2.Length + 1];

            for (int i = 0; i <= string1.Length; i++) { m[i, 0] = i; }
            for (int j = 0; j <= string2.Length; j++) { m[0, j] = j; }

            for (int i = 1; i <= string1.Length; i++)
            {
                for (int j = 1; j <= string2.Length; j++)
                {
                    diff = (string1[i - 1] == string2[j - 1]) ? 0 : 1;
                    m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1, m[i, j - 1] + 1), m[i - 1, j - 1] + diff);
                }   
            }       
            return m[string1.Length, string2.Length];
        }

        static bool SearchName(string name, string path)
        {
            FileStream fstream = File.OpenRead(path);
            byte[] array = new byte[fstream.Length];
            fstream.Read(array, 0, array.Length);
            string names = System.Text.Encoding.Default.GetString(array);
            //Console.WriteLine(names);
            string namen = name + '\n';
            if (names.IndexOf(namen) != -1)
            {
                Console.WriteLine("Hello, {0}!", name);
                return true;
            }
            string []namesArray =  names.Split('\n');
            foreach (string nameFromArray in namesArray)
            {
                if (LevenshteinDistance(nameFromArray, name) <= 2)
                {
                    Console.WriteLine("Did you mean \"{0}\"& Y/N", nameFromArray);
                    string answer = Console.ReadLine();
                    if (answer == "Y")
                    {
                        name = nameFromArray;
                        Console.WriteLine("Hello, {0}!", name);
                        return true;
                    }   
                }
            }
            return false;
        }
        
        static void Main(string[] args)
        {
            string name;
            bool   resultOsSearch;
            
            Console.WriteLine("Enter name:");
            name = Console.ReadLine();
            if (name == "")
            {
                Console.WriteLine("Your name was not found.");
                return;
            }
            
            string path = @"us.txt";
            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                resultOsSearch = SearchName(name, path);
            }
            else
            {
                Console.WriteLine("ERROR: incorrect path to file");
                return;
            }

            if (!resultOsSearch)
                Console.WriteLine("Your name was not found.");
        }
    }
}
