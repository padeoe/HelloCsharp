using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// This is my first C# program!
/// </summary>
namespace HelloCsharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello,C#!");
            //value and reference
            //srtuct pass value
            Coordinate location;
            location.x = 10;
            location.y = 10;
            AttempTomodifyCoord(location);
            Console.WriteLine("({0},{1})",location.x,location.y);
            ModifyCoord(ref location);
            Console.WriteLine("({0},{1})", location.x, location.y);
            //object pass reference
            CoordinateClass newlocation=new CoordinateClass();
            newlocation.x = 10;
            newlocation.y = 10;
            AttempTomodifyNewCoord(newlocation);
            Console.WriteLine("({0},{1})", newlocation.x, newlocation.y);
            ModifyNewCoord(ref newlocation);
            Console.WriteLine("({0},{1})", newlocation.x, newlocation.y);
            //enum
            Days meetingDay = Days.Tuesday | Days.Thursday;
            Console.WriteLine(meetingDay.ToString());

    }
        [Flags]
        enum Days
        {
            None = 0x0,
            Sunday = 0x1,
            Monday = 0x2,
            Tuesday = 0x4,
            Wednesday = 0x8,
            Thursday = 0x10,
            Friday = 0x20,
            Saturday = 0x40
        }
        public static void AttempTomodifyCoord(Coordinate c)
        {
            c.x = 50;
            c.y = 90;
        }
        public static void ModifyCoord(ref Coordinate c)
        {
            c.x = 90;
            c.y = 50;
        }
        public static void AttempTomodifyNewCoord(CoordinateClass c)
        {
            c.x = 50;
            c.y = 90;
        }
        public static void ModifyNewCoord(ref CoordinateClass c)
        {
            c.x = 90;
            c.y = 50;
        }
    }
    public struct Coordinate{
        public int x;
        public int y;
    }
    class CoordinateClass
    {
        public int x;
        public int y;
    }
}
