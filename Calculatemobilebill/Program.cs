using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculatemobilebill
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal bill = 0;

            DateTime startTime = Convert.ToDateTime("2019-08-31 12:00:00 am");
            DateTime endTime = Convert.ToDateTime("2019-08-31 12:01:59 am");

            DateTime timeNow = startTime;
            TimeSpan spans = endTime.Subtract(startTime);
            int TotalSeceond = Convert.ToInt32(spans.TotalSeconds);
            while (timeNow <= endTime)
            {
                int span = 0;
                int count = 1;
                if (TotalSeceond > 0)
                {
                    for (int i = 0; i <= TotalSeceond; i++)
                    {
                        if ((TotalSeceond - 20) > 0)
                        {
                            span = 20;
                        }
                        decimal rate = 0;
                        if ((timeNow.Hour >= 9 && timeNow.Hour < 23))
                        {
                            if (span >= 20)
                            {
                                rate = rate + Convert.ToDecimal(0.30);
                            }
                            else
                            {
                                rate = Convert.ToDecimal(span) * Convert.ToDecimal(0.00);
                            }
                        }
                        else if (timeNow.Hour >= 0 && timeNow.Hour < 9 || (timeNow.Hour >= 23 && timeNow.Hour < 24))
                        {
                            if (span >= 20)
                            {
                                rate = rate + Convert.ToDecimal(0.20);
                            }
                            else
                            {
                                rate = Convert.ToDecimal(span) * Convert.ToDecimal(0.00);
                            }
                        }
                        bill = bill + rate;
                        Console.WriteLine("{0:HH:mm}, rate: {1:#,0.00}, bill: {2:#,0.00}", timeNow, rate, bill);
                        count++;
                        TotalSeceond = TotalSeceond - 20;
                        if (count > 3)
                        {
                            count = 1;
                            timeNow = timeNow.AddMinutes(1);
                        }
                    }
                }
                else
                {
                    break;
                }

            }
            Console.WriteLine("Bill: {0:HH:mm} to {1:HH:mm}, {2:#,0.00} mins, {3:#,0.00}", startTime, endTime, (endTime - startTime).TotalMinutes, bill);
            Console.WriteLine("Total Bill {0}: ", bill);
            Console.ReadLine();
        }
    }
}
