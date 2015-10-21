using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace ConsoleApplication7
{

	class Person
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Country { get; set; }
		public string Town { get; set; }
		public string Street { get; set; }


		public string FirstName1 { get; set; }
		public string FirstName2 { get; set; }
		public string FirstName3 { get; set; }
		public string FirstName4 { get; set; }
		public string FirstName5 { get; set; }
		public string FirstName6 { get; set; }		
		public string FirstName7 { get; set; }
		public string FirstName8 { get; set; }
		public string FirstName9 { get; set; }
		public string FirstName10 { get; set; }
		public string FirstName11 { get; set; }
		public string FirstName12 { get; set; }
		public string FirstName13 { get; set; }
		public string FirstName14 { get; set; }
		public string FirstName15 { get; set; }
		public string FirstName16 { get; set; }
		public string FirstName17 { get; set; }
		public string FirstName18 { get; set; }
		public string FirstName19 { get; set; }
		public string FirstName20 { get; set; }
		public string FirstName21 { get; set; }
		public string FirstName22 { get; set; }
		public string FirstName23 { get; set; }
		public string FirstName24 { get; set; }
		public string FirstName25 { get; set; }
		public string FirstName26 { get; set; }
		public string FirstName27 { get; set; }
		public string FirstName28 { get; set; }
		public string FirstName29 { get; set; }
		public string FirstName30 { get; set; }
		public string FirstName31 { get; set; }
		public string FirstName32 { get; set; }
		public string FirstName33 { get; set; }
		public string FirstName34 { get; set; }
		public string FirstName35 { get; set; }
		public string FirstName36 { get; set; }
		public string FirstName37 { get; set; }
		public string FirstName38 { get; set; }
		public string FirstName39 { get; set; }
		public string FirstName40 { get; set; }


		public override string ToString()
		{
			string resultString = "{\n";
			Type type = this.GetType();
			var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (PropertyInfo prop in properties)
			{
				resultString += prop.Name + ": " + prop.GetValue(this) + "\n";
			}
			resultString += "}";
			return resultString;
		}
	}


	class Program
	{
		static Stopwatch myStopwatch = new Stopwatch();

		static private readonly Random _rnd = new Random();
		 private const string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		static private string RandomString()
		{
			int size = 10;
			char[] buffer = new char[size];
			for (int i = 0; i < size; i++)
			{
				buffer[i] = _chars[_rnd.Next(_chars.Length)];
			}
			return new string(buffer);
		}

		static void Main(string[] args)
		{
			int countOfPerson = 2000000;
			for (int i = 0; i < 15; i++)
			{
				Person[] people = new Person[countOfPerson];
				for (int j = 0; j < countOfPerson; j++)
				{
					people[j] = new Person();
					people[j].FirstName = RandomString();
				}


				myStopwatch.Start();
				var orderedList1 = people.OrderByViaReflection("FirstName");
				myStopwatch.Stop();
				Console.WriteLine("Reflection method - " + myStopwatch.Elapsed.Milliseconds);
				myStopwatch.Reset();

				myStopwatch.Start();
				var orderedList2 = people.OrderByViaExpressions("FirstName");
				myStopwatch.Stop();
				Console.WriteLine("Expressions method - " + myStopwatch.Elapsed.Milliseconds);
				myStopwatch.Reset();



				//File.WriteAllLines("reflection" + i + ".txt", orderedList1.Select<Person, string>(x => x.ToString()), Encoding.ASCII);
				//File.WriteAllLines("expressions" + i + ".txt", orderedList2.Select<Person, string>(x => x.ToString()), Encoding.ASCII);
			}	
			Console.ReadKey();
		}
	}
}
