using System;
using System.Collections;
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
			//装箱转换
			///当值类型被作为引用类型的参数传给方法或者赋值给一个引用类型参数时，堆上将创建一个复制值到值字段的对象
			int personID = 111;
			object boxID = personID;
			personID = 222;
			int unboxID = (int)boxID;
			Console.WriteLine(personID.ToString());
			Console.WriteLine(unboxID.ToString());

			///foreach循环中无法改变集合对象，会直接编译器报错
			String[] stringArray = new String[5];
			for (int i=0;i<stringArray.Length;i++)
			{
				stringArray[i] = i.ToString();
				Console.WriteLine(stringArray[i]);
			}
			foreach (String s in stringArray)
			{
			///	s = "hh";///语法报错
			}

			//C#3.0初始化器
			//class成员变量的set get写法
			Person person = new Person();
			person.id = 2;
			person.name = "hh";
			Console.WriteLine(person.name);
			//等同于
			Person person2 = new Person { id = 2, name = "hh" };
			Console.WriteLine(person2.name);

			//as和is操作符
			//is只是返bool变量表示是否可以转换成给定类型
			//as操作则直接将其转换成给定类型，若失败则返回null
			//这里说的转换可能是引用转换，也可能是装箱或拆箱操作
			Student student = new Student { id=2,name="hhh",school="ss"};
			student.school = "Nanjing University";
			Console.WriteLine("student {0} a person",student is Person?"is":"is not");
			Console.WriteLine("{0}",student.school);

			Person personFromStudent = student as Person;
			if (personFromStudent!=null) { Console.WriteLine(personFromStudent.ToString()); }
			//此时观察personFromStudent的属性，已经没有school这一项了，说明as操作同时进行了类型转换装箱操作
			//Console.WriteLine("personFromStudent {0} a Student", personFromStudent is Student?"is":"is not");



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
	/// <summary>
	/// C#3.0初始化器
	/// public int id { get; set; }相当于
	/// private int id;
	/// int getId(){return id;}
	/// int setId(int id){this.id=id;}
	/// </summary>
	class Person {
		public int id { get; set; }
		public String name { get; set; }
		//使用以下代码，即构造函数后，默认构造函数被覆盖，且初始化器将无法使用，因为初始化器调用了默认构造方法
		/*public Person(int id,String name)
		{
			this.id = id;
			this.name = name;
		}*/
	}
	/// <summary>
	/// 关键字sealed
	/// 表示叶子类，不允许别的类继承该类
	/// </summary>
	sealed class Student:Person {
		private ArrayList studentSet;
		public String school { get; set; }
		public int Count {
			get {
				return studentSet.Count;
			}
		}
		/// <summary>
		/// 索引器，可以直接像数组一样访问类中的集合
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public Student this[int i]
		{
			get
			{
				return (Student)studentSet[i];
			}
		}
	}


	class circle {
		//readonly和const的区别
		//readonly是运行时计算值，之后不可修改
		//const是编译时字面值(literal value)替换。因此有可能：B程序引用了A程序的const变量，A程序修改该const变量后，B程序重新编译前使用的仍然是旧的值
		//因此readonly可能更加灵活
		const double pi = 3.1415926;
		readonly double mypi = Math.Round(pi, 2);
	}
	/// <summary>
	/// 静态类
	/// 无法创建实例（同abstract），无法作为基类（同sealed），内部方法也必须为静态方法
	/// 与Java的不同：Java不允许创建如下的外部静态类，只能创建内部静态类---用于Builder模式（参见“设计模式之Builder模式”）
	/// 静态类的编译器实现其实是sealed abstract，但是编译器不允许直接使用该语法
	/// System.Console类就是静态类
	/// C#静态类是实现单例模式（Singleton）的好方法！
	/// </summary>
	static class MyMath
	{
		static int add(int a,int b)
		{
			return a + b;
		}
		public static int sub(int a,int b)
		{
			return a - b;
		}
		private static void printResult(int result)
		{
			Console.WriteLine(result);
		}
		//静态类不能包含protected成员，因为静态类不能作为基类，protected无意义
	/*	protected static int mul(int a,int b)
		{
			return a* b;
		}*/
	}
	
}
