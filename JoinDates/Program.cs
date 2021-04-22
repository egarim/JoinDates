using System;
using System.Collections.Generic;
using System.Linq;
namespace JoinDates
{
    class Program
    {
        static void Main(string[] args)
        {
            Fechas();

            Console.WriteLine("Hello World!");
        }
     
        private static void Fechas()
        {
            var year = 2021;
            DateTime StartDate = new DateTime(year, 1, 1);
            List<DateTime> AllDates = new List<DateTime>();
            for (int i = 0; i < 365; i++)
            {

                AllDates.Add(StartDate);
                StartDate = StartDate.AddDays(1);
            }

            List<DateTime> DatesInSystem = new List<DateTime>();
            DatesInSystem.Add(new DateTime(2021, 1, 2));
            DatesInSystem.Add(new DateTime(2021, 1, 3));

            //var isEven = (number % 2 == 0) ? true : false;

            var query = from Date in AllDates
                        join day in DatesInSystem on Date.Date equals day.Date into temp
                        from SubDates in temp.DefaultIfEmpty()

                        select new { Date.Date, SystemDate = (SubDates.Date != DateTime.MinValue) == true ? SubDates.Date.ToString() : "" };
        }
    }
}
