using Otus.MyDictionary;

namespace OtusHW_Dictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDictionary<int,string> asd = new MyDictionary<int, string>();
            asd.Add(34,"asdasdasdasdasdasd");
            Console.WriteLine(asd.Get(34));
            asd.Add(34,"Hello Otus!");
            Console.WriteLine(asd.Get(34));
            asd.Add(66, "NEW____asdasdasdasdasdasd");
            Console.WriteLine(asd.Get(66));
        }
    }
}