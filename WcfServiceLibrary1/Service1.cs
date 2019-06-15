using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // UWAGA: możesz użyć polecenia „Zmień nazwę” w menu „Refaktoryzuj”, aby zmienić nazwę klasy „Service1” w kodzie i pliku konfiguracji.
    public class Service1 : IService1
    {
        List<List<string>> listOfAll = new List<List<string>>();
        HashSet<string> listOfAirports = new HashSet<string>();
        string patha = @"C:\Users\Adven97\source\repos\ConsoleApp1\ConsoleApp1\loty.csv";

        public Service1()
        {
            using (var reader = new StreamReader(patha))
            {
                List<string> listA = new List<string>();
                List<string> listB;
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    listA.Add(values[0]);
                    // listB.Add(values[1]);
                }
                foreach (var item in listA)
                {
                    listB = new List<string>();
                    var valu = item.Split(',');
                    // Console.WriteLine(valu[0]);
                    listB.Add(valu[0]);
                    listB.Add(valu[4]);
                    listB.Add(valu[5]);
                    listB.Add(valu[6]);
                    listB.Add(valu[10]);
                    listB.Add(valu[11]);

                    listOfAirports.Add(valu[0]);
                    listOfAirports.Add(valu[6]);
                    

                    listOfAll.Add(listB);
                }
            }
        }

        public string GetData(int value)
        {

            return "c";
        }

        bool correctCity(string city)
        {
            foreach (var c in listOfAirports)
            {
                if(city.ToUpper() == c)
                {
                    return true;
                }
            }
            return false;

        }

        string checkPosrednie(string src, string dest, int przedzial)
        {
            int count = 0;
            string odp="";
            foreach (var it in listOfAll)
            {
                
                if (it[0] == src.ToUpper())
                {

                    foreach (var it2 in listOfAll)
                    {
                        int srcH = Int32.Parse(it[1]);
                        int srcM = Int32.Parse(it[2]);
                        int dstH = Int32.Parse(it[4]);
                        int dstM = Int32.Parse(it[5]);

                        int srcH2 = Int32.Parse(it2[1]);
                        int srcM2 = Int32.Parse(it2[2]);
                        int dstH2 = Int32.Parse(it2[4]);
                        int dstM2 = Int32.Parse(it2[5]);


                        if (przedzial > 0)
                        {
                            if (it2[0] == it[3] && it2[3] == dest.ToUpper() && srcH2 >= dstH && srcM2 >= dstM
                                && ((srcH +przedzial) >= dstH2))
                            {
                                if (((srcH + przedzial) == dstH2 && dstM2 <= srcM) || (srcH + przedzial) > dstH2)
                                {
                                    count++;
                                    odp += "*******************" + "\n" +
                                    "Src: " + it[0] + " " + it[1] + ":" + it[2] + "\n" +
                                    "Dst: " + it[3] + " " + it[4] + ":" + it[5] + "\n" +
                                    "----------------------" + "\n";


                                    odp +=
                                    "Src: " + it2[0] + " " + it2[1] + ":" + it2[2] + "\n" +
                                    "Dst: " + it2[3] + " " + it2[4] + ":" + it2[5] + "\n" +
                                    "*******************" + "\n" + "\n";
                                }
                            }
                        }
                        else
                        {

                            if (it2[0] == it[3] && it2[3] == dest.ToUpper() && srcH2 >= dstH && srcM2 >= dstM)
                            {
                                count++;
                                odp += "*******************" + "\n" +
                                "Src: " + it[0] + " " + it[1] + ":" + it[2] + "\n" +
                                "Dst: " + it[3] + " " + it[4] + ":" + it[5] + "\n" +
                                "----------------------" + "\n";


                                odp +=
                                "Src: " + it2[0] + " " + it2[1] + ":" + it2[2] + "\n" +
                                "Dst: " + it2[3] + " " + it2[4] + ":" + it2[5] + "\n" +
                                "*******************" + "\n" + "\n";

                            }
                        }

                    }

                }

            }
            if(count > 0)
            {
                return "POŁĄCZENIA POŚREDNIE \n" + odp + " xd: " + count;
            }
            else
            {
                return "Brak połączeń pośrednich";
            }

            
        }

        public string getFlightInfo(string src, string dest, int przedzial)
        {

            int howMany = 0;
            string odp="";

            if(!correctCity(src))
            {
                return "Nie ma wylotów z lotniska "+src;
                
            }
            if (!correctCity(dest))
            {
                return "Nie ma przylotów do lotniska "+dest;
            }



            foreach (var it in listOfAll)
            {
                if(przedzial > 0)
                {
                    int srcH = Int32.Parse(it[1]);
                    int srcM = Int32.Parse(it[2]);
                    int dstH = Int32.Parse(it[4]);
                    int dstM = Int32.Parse(it[5]);
                    if (it[0] == src.ToUpper() && it[3] == dest.ToUpper() && (srcH + przedzial >= dstH ))
                    {
                        if (((srcH + przedzial) == dstH && dstM <= srcM) || (srcH + przedzial) > dstH)
                        {
                            odp += "*******************" + "\n" +
                        "Src: " + it[0] + " " + it[1] + ":" + it[2] + "\n" +
                        "Dst: " + it[3] + " " + it[4] + ":" + it[5] + "\n" +
                        "*******************" + "\n" + "\n";

                         howMany++;
                        }
                    }
                }
                else
                {
                    if (it[0] == src.ToUpper() && it[3] == dest.ToUpper())
                    {
                        odp += "*******************" + "\n" +
                        "Src: " + it[0] + " " + it[1] + ":" + it[2] + "\n" +
                        "Dst: " + it[3] + " " + it[4] + ":" + it[5] + "\n" +
                        "*******************" + "\n" + "\n";


                        howMany++;
                    }
                }
                

            }
            if (howMany == 0)
            {
                return "Niestety nie ma takiego połączenia bezpośredniego\n" + checkPosrednie(src, dest,przedzial);
            }

            else
            {
                return odp + "\n" + checkPosrednie(src, dest, przedzial);
            }

        }


        public string ReadCsv()
        {
            string csv = "xd";
            try
            {
                csv = File.ReadAllText(patha);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return csv;
        }


    }
}

