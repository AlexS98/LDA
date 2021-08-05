using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson6
{
    public class Car
    {
        public static int CarCount;

        public string color;

        public string Color
        {
            get 
            { 
                return $"%{color.ToUpper()}%"; 
            }
            set 
            {
                color = value.ToLower(); 
            }
        }

        public int SeatCount { get; set; }


        //private int seatCount;

        //public int SeatCount
        //{
        //    get { return seatCount; }
        //    set { seatCount = value; }
        //}


        public Car()
        {
            color = "white";
            CarCount++;
        }

        public Car(string color, int seatCount)
        {
            this.color = color;
            SeatCount = seatCount;
            CarCount++;
        }

        public void Beep()
        {
            Console.WriteLine($"{Color} car make \"Beep-beep\"");
        }

        public static void LogCap()
        {
            Console.WriteLine(CarCount);
        }
    }
}
