using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntervalMerge
{
    class Program
	{
		private static List<Interval> inputIntervals = new List<Interval>();

		static void Main(string[] args)
        {
			List<Interval> mergedIntervals;
			bool exit = false;
			string initCase = "0";

			try
			{
				// main program loop to test multiple inputs
				while (!exit)
				{
					Console.Write("\r\n\r\nPlease specify an action...\r\n0\t= run with given example\r\n[1..3]\t= run with test data\r\n'exit'\t= close the application.\r\nYour input: ");
					initCase = Console.ReadLine();
					inputIntervals.Clear();

					if (initCase == "exit")
					{
						exit = true;
					}
					else
					{
						InitInput(initCase);
						PrintIntervals(inputIntervals, "input intervals");

						mergedIntervals = Interval.Merge(inputIntervals);

						PrintIntervals(mergedIntervals, "merged intervals");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occured.\r\n" + ex.Message);
			}
		}


		private static void PrintIntervals(List<Interval> intervals, string description)
		{
			Console.WriteLine("\r\n{0}:", description);

			foreach (Interval iv in inputIntervals)
			{
				Console.WriteLine("[{0},{1}]", iv.Start, iv.End);
			}
		}

		#region tests
		private static void InitInput(string initCase)
		{
			try
			{
				if (string.IsNullOrEmpty(initCase))
				{
					initCase = "0";
				}

				// determine if custom input is provided or one of the pre-defined inputs is used
				if (initCase.StartsWith("["))
				{
					// ----- not production-ready, added only for testing convenience -----

					initCase = initCase.Replace(" ", "");   // remove whitespaces
					initCase = initCase.Substring(1, initCase.Length - 2); // remove leading [ and trailing ]
					string[] plainIntervals = initCase.Split(new string[] { "][" }, StringSplitOptions.RemoveEmptyEntries);

					foreach (string s in plainIntervals)
					{
						string[] numbers = s.Split(new char[] { ',' });
						if (numbers.Length == 2)
						{
							inputIntervals.Add(new Interval(Convert.ToInt32(numbers[0]), Convert.ToInt32(numbers[1])));
						}
					}

					// ----- not production-ready end-----
				}
				else
				{
					switch (initCase)
					{
						case "0":
							// official input data
							inputIntervals.Add(new Interval(25, 30));
							inputIntervals.Add(new Interval(2, 19));
							inputIntervals.Add(new Interval(14, 23));
							inputIntervals.Add(new Interval(4, 8));
							break;

						case "1":
							// test 1
							inputIntervals.Add(new Interval(5, 14));
							inputIntervals.Add(new Interval(30, 32));
							inputIntervals.Add(new Interval(16, 17));
							inputIntervals.Add(new Interval(23, 28));
							inputIntervals.Add(new Interval(8, 10));
							inputIntervals.Add(new Interval(15, 15));
							inputIntervals.Add(new Interval(1, 2));
							inputIntervals.Add(new Interval(19, 21));
							inputIntervals.Add(new Interval(19, 19));
							inputIntervals.Add(new Interval(7, 8));
							break;

						case "2":
							// test2
							inputIntervals.Add(new Interval(38, 39));
							inputIntervals.Add(new Interval(38, 38));
							inputIntervals.Add(new Interval(35, 37));
							inputIntervals.Add(new Interval(33, 36));
							inputIntervals.Add(new Interval(31, 31));
							inputIntervals.Add(new Interval(25, 26));
							inputIntervals.Add(new Interval(24, 25));
							inputIntervals.Add(new Interval(21, 28));
							inputIntervals.Add(new Interval(18, 22));
							inputIntervals.Add(new Interval(16, 17));
							inputIntervals.Add(new Interval(14, 16));
							inputIntervals.Add(new Interval(10, 12));
							inputIntervals.Add(new Interval(9, 11));
							inputIntervals.Add(new Interval(5, 6));
							inputIntervals.Add(new Interval(3, 11));
							inputIntervals.Add(new Interval(2, 3));
							inputIntervals.Add(new Interval(1, 2));
							break;

						case "3":
							// test2
							inputIntervals.Add(new Interval(1, 2));
							inputIntervals.Add(new Interval(2, 3));
							inputIntervals.Add(new Interval(3, 11));
							inputIntervals.Add(new Interval(5, 6));
							inputIntervals.Add(new Interval(9, 11));
							inputIntervals.Add(new Interval(10, 12));
							inputIntervals.Add(new Interval(14, 16));
							inputIntervals.Add(new Interval(16, 17));
							inputIntervals.Add(new Interval(18, 22));
							inputIntervals.Add(new Interval(21, 28));
							inputIntervals.Add(new Interval(24, 25));
							inputIntervals.Add(new Interval(25, 26));
							inputIntervals.Add(new Interval(31, 31));
							inputIntervals.Add(new Interval(33, 36));
							inputIntervals.Add(new Interval(35, 37));
							inputIntervals.Add(new Interval(38, 38));
							inputIntervals.Add(new Interval(38, 39));
							break;

						default:
							break;
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
		#endregion tests
	}
}
