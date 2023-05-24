namespace oof
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Muvelet> list = new List<Muvelet>();
            using (StreamReader f = new StreamReader("kifejezesek.txt"))
            {
                while (!f.EndOfStream)
                {
                    list.Add(new Muvelet(f.ReadLine()));
                }
            }
            Console.WriteLine($"Kifejezések Száma: {list.Count}");
            Console.WriteLine($"Maradékos Osztásssal: {list.Count(x => x.STR == "mod")}");

            int index = 0;
            bool found = false;
            do
            {
                found = list[index].A % 10 == 0 && list[index].B % 10 == 0;
                index++;
            } while (!found);
            Console.WriteLine($"{(found ? "Van" : "Nincs")} ilyen kifejezés!");
            Console.WriteLine("Statisztika");
            list.Where(x => x.STR == "+" || x.STR == "-" || x.STR == "*" || x.STR == "/" || x.STR == "div" || x.STR == "mod").GroupBy(x => x.STR).ToList().ForEach(y => Console.WriteLine($"\t{y.Key} -> {y.Count()} db"));
            string input = "";
            do
            {
                if (input != "")
                {
                    try
                    {
                        Muvelet muvelet = new Muvelet(input);
                        Console.WriteLine($"\t{muvelet.ToString()}");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("\tHibás muvelet!");
                    }
                }
                Console.Write("Adj meg egy muveletet (pl: 7 * 7): ");
                input = Console.ReadLine();
            } while (input != "");

            using (StreamWriter f = new StreamWriter("eredmenyek.txt"))
            {
                list.ForEach(x => f.WriteLine(x.ToString()));
            }
            Console.WriteLine("eredmenyek.txt");
            Console.ReadKey();
        }
    }
}