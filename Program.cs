using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biegacz
{
    class Program
    {
        static void Main(string[] args)
        {
            string testCase = Console.ReadLine();
            string[] laps = Console.ReadLine().Split(',');
            List<Time> times = new List<Time>();

            int wholeTime = 0;

            for (int i = 0; i < laps.Length; i++)
            {
                string[] temp = laps[i].Split(':');
                if (i == 0)
                {
                    int tempTime = Int32.Parse(temp[0]) * 60 + Int32.Parse(temp[1]);
                    wholeTime = tempTime;
                    Time newTime = new Time(tempTime);
                    times.Add(newTime);
                }
                else
                {
                    int tempTime = Int32.Parse(temp[0]) * 60 + Int32.Parse(temp[1]);
                    int lapTime = tempTime - wholeTime;
                    wholeTime = tempTime;
                    Time newTime = new Time(lapTime);
                    times.Add(newTime);
                }
            }

            switch (testCase)
            {
                case "test1":
                    Console.WriteLine(laps.Length);
                    break;
                case "test2":
                    foreach (Time t in times)
                        Console.Write($"{t} ");
                    break;
                case "test3":
                    Time minTime = (from t in times select t).Min();
                    Console.Write($"{minTime} {times.IndexOf(minTime) + 1}");
                    break;
                case "test4":
                    Time maxTime = (from t in times select t).Max();
                    Console.Write($"{maxTime} {times.IndexOf(maxTime) + 1}");
                    break;
                case "test5":
                    int sumOfTimes = 0;
                    for(int i = 0; i < times.Count; i++)
                    {
                        sumOfTimes += times[i].numberOfSeconds;
                    }
                    double everageLap = Math.Round((double)(sumOfTimes / times.Count()));
                    Time everageTime = new Time((int)everageLap);
                    Console.WriteLine(everageTime);
                    break;
            }
            Console.ReadKey();
        }
    }

    class Time: IComparable<Time>
    {
        public int numberOfSeconds;
        public int Seconds => numberOfSeconds % 60;
        public int Minutes => numberOfSeconds / 60;

        public Time(int seconds)
        {
            numberOfSeconds = seconds; 
        }
        public override string ToString() => $"{Minutes:D2}:{Seconds:D2}";

        public int CompareTo(Time other)
        {
            if (other == null) return 1;
            if (this == other) return 0;
            return numberOfSeconds.CompareTo(other.numberOfSeconds);
        }      
    }
}
