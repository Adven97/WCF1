using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WCF
{
    class Program
    {
        static string pathh = @"C:\Users\Adven97\source\repos\ConsoleApp1\ConsoleApp1\loty.csv";
        static List<List<string>> listOfAll = new List<List<string>>();

        static void Main(string[] args)
        {
            // ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client("BasicHttpBinding_IService1");
            ServiceReference6.Service1Client proxy = new ServiceReference6.Service1Client();
            var msg = proxy.GetData(12);

            Console.WriteLine(msg);
            Console.WriteLine("-------------------------------------");
           // ReadCsvx();

            Console.Write("Enter Airport: ");
            string srcAirport = Console.ReadLine();

            Console.Write("Enter Airport Destination: ");
            string dstAirport = Console.ReadLine();

            Console.Write("Enter Time of the Flight (optional) ");
            string czas = Console.ReadLine();
            if(czas.Length > 0 && Regex.IsMatch(czas, @"^\d+$"))
            {
                if(Int32.Parse(czas) > 0)
                {
                    Console.WriteLine(proxy.getFlightInfo(srcAirport, dstAirport, Int32.Parse(czas)));
                }
                else
                {
                    Console.WriteLine(proxy.getFlightInfo(srcAirport, dstAirport, 0));
                }
                
            }
            else
            {
                Console.WriteLine(proxy.getFlightInfo(srcAirport, dstAirport, 0));
            }


            //getInfo(srcAirport, dstAirport);
            Console.ReadKey();
        }

        //public static void ReadCsvx()
        //{
        //    using (var reader = new StreamReader(pathh))
        //    {
        //        List<string> listA = new List<string>();
        //        List<string> listB;
        //        while (!reader.EndOfStream)
        //        {
        //            var line = reader.ReadLine();
        //            var values = line.Split(';');

        //            listA.Add(values[0]);
        //            // listB.Add(values[1]);
        //        }
        //        foreach (var item in listA)
        //        {
        //            listB = new List<string>();
        //            var valu = item.Split(',');
        //            // Console.WriteLine(valu[0]);
        //            listB.Add(valu[0]);
        //            listB.Add(valu[4]);
        //            listB.Add(valu[5]);
        //            listB.Add(valu[6]);
        //            listB.Add(valu[10]);
        //            listB.Add(valu[11]);
        //            listOfAll.Add(listB);

        //          //  listOfAirports.Add(valu[0]);
        //           // listOfAirports.Add(valu[6]);
        //        }
        //        //foreach(var it in listOfAll)
        //        //{
        //        //    Console.WriteLine("Dst: "+it[0]+" "+it[1]+" "+it[2]);
        //        //    Console.WriteLine("Src: "+it[3]+" "+it[4]+" "+it[5]);
        //        //    Console.WriteLine();
        //        //}



        //    }

        //}

        //static void checkPosrednie(string src, string dest)
        //{
        //    int count=0;
        //    foreach (var it in listOfAll)
        //    {
        //        if (it[0] == src.ToUpper())
        //        {

        //            foreach (var it2 in listOfAll)
        //            {
        //                if (it2[0] == it[3] && it2[3] == dest.ToUpper() && Int32.Parse(it2[1]) >= Int32.Parse(it[4])
        //                    && Int32.Parse(it2[2]) >= Int32.Parse(it[5]))
        //                {
        //                    count++;
        //                    Console.WriteLine("*************************");
        //                    Console.WriteLine("Dst: " + it[0] + " " + it[1] + ":" + it[2]);
        //                    Console.WriteLine("Src: " + it[3] + " " + it[4] + ":" + it[5]);
        //                    Console.WriteLine("___________________________");


        //                    Console.WriteLine("Dst: " + it2[0] + " " + it2[1] + ":" + it2[2]);
        //                    Console.WriteLine("Src: " + it2[3] + " " + it2[4] + ":" + it2[5]);
        //                    //  Console.WriteLine("___________________________");
        //                    Console.WriteLine("88********************************88");
        //                    Console.WriteLine();

        //                }

        //            }

        //        }

        //    }
        //    Console.WriteLine("Counter: "+count);
        //}

        //static void getInfo(string src, string dest)
        //{
        //    int howMany = 0;
        //    foreach (var it in listOfAll)
        //    {
        //        if (it[0] == src.ToUpper() && it[3] == dest.ToUpper())
        //        {
        //            Console.WriteLine("*************************");
        //            Console.WriteLine("Dst: " + it[0] + " " + it[1] + " " + it[2]);
        //            Console.WriteLine("Src: " + it[3] + " " + it[4] + " " + it[5]);
        //            Console.WriteLine("*************************");
        //            howMany++;
        //        }

        //    }
        //    if (howMany == 0)
        //    {
        //        Console.WriteLine("Niestety takiego bezpośredniego połączenia nie ma");
        //        Console.WriteLine("moze posrednie");

        //    }
        //    checkPosrednie(src, dest);
        //}


    }


}
