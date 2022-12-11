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

            int[] n1 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14};                       // Zadanie 1
            int[] n2 = { 1, 3, -2, -4, -7, -3, -8, 12, 19, 6, 9, 10, 14};                       // Zadanie 2
            var arr1 = new[] { 3, -1, -3, 6, 9, 2, -7, 0, 8, 14, 13, 24, 12, 6, 5 };            // Zadanie 3
            var arr2 = new[] { 3, 9, 2, 8, 6, 5 };                                              // Zadanie 4
            int[] arr3 = new int[] { 5, 9, 1, 2, 3, 7, 5, 6, 7, 3, 7, 6, 8, 5, 4, 9, 6, 2 };    // Zadanie 5
            var str = "abeddwkkecjjeksoiekcllkenndkwel";                                        // Zadanie 6
            string[] months = { "January", "February", "March", "April", "May",                 // Zadanie 7
                "June", "July", "August", "September", "October", "November", "December" 
            };
            int[] nums = new int[] { 5, 1, 9, 2, 3, 7, 4, 5, 6, 8, 7, 6, 3, 4, 5, 2 };          // Zadanie 8
            string[] cities ={"ROME","LONDON","NAIROBI","CALIFORNIA","ZURICH",                  // Zadanie 9
                "NEW DELHI","AMSTERDAM","ABU DHABI", "PARIS"
            };

            //Rozwiazania zadan

            printLinq(from n in n1 where n % 2 == 0 select n, 1); //Zadanie 1
            
            printLinq(from n in n2 where n % 2 != 0 select n, 2); //Zadanie 2

            printLinq(from n in arr1 where (n > 0 && n < 20) select n, 3); //Zadanie 3

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
            foreach(char letter in str)
            {
                temp_str+= letter;
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
            
            if(!search.Any())
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







        }
    }
}