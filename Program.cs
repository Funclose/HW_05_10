using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HW_05_10
{
     class Program
    {
        static async Task Main(string[] args)
        {
            Task task = new Task(CallMethod);
            task.Start();
            task.Wait();

            Console.WriteLine("генерация простых чисел");
            List<int> ints = await GenerationAsync(100);

            foreach (var item in ints)
            {
                Console.WriteLine(item);
            }


            Console.WriteLine("main end");
            Console.ReadLine();
        }

        static async void CallMethod()
        {
            string filepath = "myTxt.txt";
            Task<int> tasks = ReadFile(filepath);
            int lengt = await tasks;
            Console.WriteLine("Total lengt: " + lengt);
        }

        static async Task<int> ReadFile(string path)
        {
            int lengt = 0;
            
            if (File.Exists(path))
            {
                Console.WriteLine("file starting");
                using (StreamReader str = new StreamReader(path))
                {
                    string s = await str.ReadToEndAsync();
                    lengt = s.Length;
                }
            }
            Console.WriteLine("file finally reading");
            return lengt;
        }



        //Доп задание на генерацию простых чисел
        static async Task<List<int>> GenerationAsync(int value)
        {
            return await Task.Run(() =>  GenerationSimpleNum(value));
        }


        static List<int> GenerationSimpleNum(int num)
        {
            List<int> list = new List<int>();
            for (int i = 0; i <= num; i++)
            {
                if(IsPrime(i))
                {
                    list.Add(i);
                }
            }
            return list;
            

        }

        static bool IsPrime(int num)
        {
            if(num<2) return false;
            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if(num % i == 0) return false;
            }
            return true;
        }
    }
}
