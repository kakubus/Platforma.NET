using Lab4;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            IEnumerable<int> printLinq(IEnumerable<int> linq1, int exerciseNumber)
            {
                Console.Write($"Zadanie Linq{exerciseNumber}: ");


                foreach (var l in linq1)
                {
                    Console.Write(" " + l.ToString());
                }
                Console.Write("\n");

                return linq1;
            }


            //Dane do zadan

            int[] n1 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };                       // Dane do Zadania 1
            int[] n2 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14 };                       // Dane do Zadania 2
            var arr1 = new[] { 3, -1, -3, 6, 9, 2, -7, 0, 8, 14, 13, 24, 12, 6, 5 };            // Dane do Zadania 3
            var arr2 = new[] { 3, 9, 2, 8, 6, 5 };                                              // Dane do Zadania 4
            int[] arr3 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };    // Dane do Zadania 5
            var str = "abeddwkkecjjeksoiekcllkenndkwel";                                        // Dane do Zadania 6
            string[] months = { "January", "February", "March", "April", "May",                 // Dane do Zadania 7
                "June", "July", "August", "September", "October", "November", "December"
            };
            int[] nums = new int[] { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 };          // Dane do Zadania 8
            string[] cities ={"ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH",                  // Dane do Zadania 9
                "NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
            };
            string[] files = { "a.erc", "b.txt",
                "c.ldd","d.pdf", "e.PDF","a.pdf", "b.xml", "z.txt", "zzz.doc"                   // Dane do Zadania 16
            };
            List<int> numbers17 = new List<int>() {                                             // Dane do Zadania 17
                5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2
            };

            //Rozwiazania zadan

            printLinq(from n in n1 where n % 2 == 0 select n, 1); //Zadanie 1

            printLinq(from n in n2 where n % 2 != 0 select n, 2); //Zadanie 2

            printLinq(from n in arr1 where (n > 0 && n < 12) select n, 3); //Zadanie 3

            printLinq(from n in arr2 where (n * n > 20) select n, 4); //Zadanie 4

            var linq5 = printLinq(from n in arr3 select n, 5); // Zadanie 5

            var linq5Groups = from n in linq5 group linq5 by n;
            foreach (var group in linq5Groups)
            {
                Console.WriteLine($"\tLiczba: {group.Key} wystapila: {group.Count()} razy.");
            }

            // Zadanie 6

            var linq6 = from letter in str group str by letter;
            var temp_str = "";
            foreach (char letter in str)
            {
                temp_str += letter;
            }
            Console.Write($"\nZadanie Linq6: {temp_str}\n");
            foreach (var group in linq6)
            {
                Console.WriteLine($"\tLiterka: {group.Key} wystapila: {group.Count()} razy.");
            }
            Console.Write("\n");

            // Zadanie 7

            var linq7 = from month in months select month;
            temp_str = "";
            foreach (var month in linq7)
            {
                temp_str += " " + month;
            }
            Console.Write($"\nZadanie Linq7: {temp_str}\n");

            // Zadanie 8

            var linq8 = from n in nums select n;
            var linq8Groups = from n in linq8 group linq8 by n;
            temp_str = "";

            foreach (var n in linq8)
                temp_str += " " + n.ToString();

            Console.Write($"\nZadanie Linq8: {temp_str}\n");

            foreach (var group in linq8Groups)
                Console.WriteLine($"\tLiczba: {group.Key} wystapila: {group.Count()} razy, suma wartosci: {group.Sum(x => group.Key * group.Count())}");

            // Zadanie 9

            Console.Write("\nZadanie 9 - Wymaga interakcji uzytkownika.\n");

            string start, end;
            Console.WriteLine("Podaj znak na jaka zaczyna sie szukane miasto: ");
            start = Console.ReadLine();
            Console.WriteLine("Podaj znak na jaka konczy sie szukane miasto: ");
            end = Console.ReadLine();

            var search = from city in cities where city.StartsWith(start) && city.EndsWith(end) select city;

            if (!search.Any())
            {
                Console.WriteLine("Nie znaleziono miast o zadanych parametrach!");
            }
            else
            {
                Console.Write("\nZnaleziono nastepujace miasta:");
                foreach (var city in search)
                {
                    Console.Write(" " + city);
                }
            }

            // Zadanie 10

            Console.Write("\nZadanie 10 - Wymaga interakcji uzytkownika.\n");
            Console.Write("Podaj kolejno liste liczb calkowitych (wpisz 'q' aby zakonczyc):\n");
            List<int> numbers = new List<int>();
            while (true)
            {
                string listInput = Console.ReadLine();

                if (listInput == "q") break;
                int number = int.Parse(listInput);
                numbers.Add(number);
            }
            Console.Write("\nPodaj prog wartosci od jakiej wyswietlic dane: ");
            int value = int.Parse(Console.ReadLine());
            var searchValues = from number in numbers.FindAll(n => n > value) select number;
            if (!searchValues.Any())
            {
                Console.WriteLine($"Nie znaleziono takich wartosci wiekszych od {value}!\n");
            }
            else
            {
                Console.Write($"\nZnaleziono nastepujace wartosci wieksze od {value}:");
                foreach (var n in searchValues)
                {
                    Console.Write(" " + n);
                }
            }

            // Zadanie 11

            Console.Write("\n\nZadanie 11 - Wymaga interakcji uzytkownika. Dane z poprzedniego programu\n");
            Console.Write("Podaj ilosc ostatnich liczb do wyswietlenia: ");
            numbers.Reverse(); // Aby podawać "faktycznie ostatnie" elementy listy. Bo lista przechowuje jako ostatnie elementy, te które zostały podane najwcześniej.
            int lastValues = int.Parse(Console.ReadLine());
            var lastNumbers = numbers.Take(lastValues);
            Console.Write($"\nNastepujace {lastValues} ostatnie liczby: ");
            foreach (var n in lastNumbers)
            {
                Console.Write(" " + n.ToString());
            }

            // Zadanie 12

            Console.Write("\n\nZadanie 12 - Wymaga interakcji uzytkownika. Dane z zadania 10 \n");
            Console.Write("Podaj ilosc n najwiekszych liczb do wyswietlenia: ");
            numbers.Reverse(); // Przywracam do stanu sprzed 11 zadania liste numbers.
            int nNumbers = int.Parse(Console.ReadLine());

            numbers.Sort(); // Posortowanie od najmniejszej -> najwiekszej
            numbers.Reverse(); // Odwrocenie listy, aby najwieksze byly na poczatku


            var maxNValues = numbers.Take(nNumbers); // Pobiera n najwiekszych elementow
            Console.Write($"\nNastepujace {nNumbers} najwieksze liczby: ");
            foreach (var n in maxNValues)
            {
                Console.Write(" " + n.ToString());
            }

            // Zadanie 13 - to jednak coś niezbyt działa :(

            Console.Write("\n\nZadanie 13\n");
            string inputString = "Wyraz PISANY wielkimi LITERAMI majacy PaRe Wyrazow i NIC NIEznaczacych stwierdzen";
            string[] words = inputString.Split(' ');
            Console.WriteLine("Zdanie wejsciowe: " + inputString);
            words = words.Where(w => ((w.Length).Equals(w.ToUpper().Length))).ToArray();
            Console.Write($"\nWyrazy napisane wielkimi literami: ");
            foreach (var n in words)
            {
                Console.Write(" " + n);
            }

            // Zadanie 14

            Console.Write("\n\nZadanie 14 \n");
            string[] array = { "Hello", "World", "!" };
            string result = string.Join(" ", array);

            // Zadanie 15

            Console.Write("\n\nZadanie 15 - Wymaga interakcji uzytkownika. \n");
            var studentList = new Students().GtStuRec();

            Console.Write("Podaj ilosc najlepszych studentow do wyswietlenia: ");
            int nStudents = int.Parse(Console.ReadLine());

            var studentLinq = from student in studentList.OrderByDescending(x => x.GroupPoint).Take(nStudents) select student;
            Console.Write($"\nLista {nStudents} najlepszych studentow: ");
            foreach (var forStudent in studentLinq)
            {

                Console.Write("\n\t" + forStudent.StudentName + "\tPunkty: " + forStudent.GroupPoint.ToString() + "");
            }

            //Zadanie 16

            Console.Write("\n\nZadanie 16 \n");
            var fileLinq = files.GroupBy(x => Path.GetExtension(x), StringComparer.InvariantCultureIgnoreCase).Select(x => new { Value = Path.GetExtension(x.Key), Count = x.Count() });

            foreach (var file in fileLinq)
            {
                Console.WriteLine("Rozszerzenie: " + file.Value + "\tIlosc wystapien: " + file.Count);
            }

            //Zadanie 17

            Console.Write("\n\nZadanie 17 - Wymaga interakcji uzytkownika.\n");
            Console.Write($"\nLista: ");
            foreach (var n in numbers17)
            {
                Console.Write(" " + n.ToString());
            }

            while (true)
            {

                Console.Write("\nPodaj liczbe ktora chcesz usunac z tej listy (wcisnij 'q' aby zakonczyc): ");
                string nInput = Console.ReadLine();

                if (nInput == "q") break;
                int nToDelete = int.Parse(nInput);
                numbers17.RemoveAll(x => x == nToDelete);
                Console.Write($"\nLista: ");
                foreach (var n in numbers17)
                {
                    Console.Write(" " + n.ToString());
                }
            }
            Console.Write($"\nLista koncowa: ");
            foreach (var n in numbers17)
            {
                Console.Write(" " + n.ToString());
            }

            //Zadanie 18

            Console.Write("\n\nZadanie 18\n");

            var charset1 = new[] { 'A', 'B', 'C', 'D' };
            var numset1 = new[] { 1, 2, 3, 4 };

            var cart = charset1.SelectMany(x => numset1.Select(y => x.ToString() + y.ToString()));

            foreach (var c in cart)
            {
                Console.WriteLine(c);
            }

            //Zadanie 19
            Console.Write("\n\nZadanie 19\n");

            class Item_mast
        {
            public int Id { get; set; }
            public string Descr { get; set; }
        }
        class Purchase
        {
            public int Id { get; set; }
            public int No { get; set; }
            public int Qty { get; set; }
        }

        List<Item_mast> itemlist = new List<Item_mast>
            {
                new Item_mast { Id = 1, Descr = "A " },
                new Item_mast { Id = 2, Descr = "B" },
                new Item_mast { Id = 3, Descr = "C" },
                new Item_mast { Id = 4, Descr = "D" },
                new Item_mast { Id = 5, Descr = "E" }
            };

        List<Purchase> purchlist = new List<Purchase>
            {
                new Purchase { No=100, Id = 3, Qty = 55 },
                new Purchase { No =101, Id = 2, Qty = 44 },
                new Purchase { No =102, Id = 3, Qty = 555 },
                new Purchase { No =103, Id = 4, Qty = 33 },
                new Purchase { No =104, Id = 3, Qty = 33 },
                new Purchase { No =105, Id = 4, Qty = 44 },
                new Purchase { No =106, Id = 1, Qty = 343 }
            };

            
        
   
            var joined = from p in purchlist
                         join i in itemlist
                         on p.Id equals i.Id
                         select new { Purchase = p, Item = i };
   
        }
    }
}