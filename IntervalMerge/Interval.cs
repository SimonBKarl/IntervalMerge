using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntervalMerge
{
	/// <summary>
	/// represents a Interval of start and end time
	/// it also provides the MERGE functionality
	/// </summary>
	public class Interval
	{
		#region members
		public int Start { get; set; }
		public int End { get; set; }
		#endregion members

		#region construction
		public Interval(int t1, int t2)
		{
			// prevents wrong initialization
			if (t1 < t2)
			{
				Start = t1;
				End = t2;
			}
			else
			{
				Start = t2;
				End = t1;
			}
		}
		#endregion construction

		#region methods
		public static List<Interval> Merge(List<Interval> intervals)
		{
			try
			{
				if (intervals == null)
				{
					// ensures to return a list instead of null
					intervals = new List<Interval>();
				}

				if (intervals.Count > 0)
				{
					// sorting input data to decrease merge's complexity
					intervals.Sort(new IntervalComparer());

					int i = 0;
					while (i + 1 < intervals.Count)
					{
						if ((intervals[i].Start <= intervals[i + 1].Start && intervals[i].End >= intervals[i + 1].Start)
							|| (intervals[i].Start <= intervals[i + 1].End && intervals[i].End >= intervals[i + 1].End))
						{
							intervals[i].Start = Math.Min(intervals[i].Start, intervals[i + 1].Start);
							intervals[i].End = Math.Max(intervals[i].End, intervals[i + 1].End);

							intervals.RemoveAt(i + 1);
						}
						else
						{
							i++;
						}
					}
				}

				return intervals;
			}
			catch (Exception)
			{
				throw;
			}
		}
		#endregion methods
	}

	/// <summary>
	/// custom comparer, used for sorting a List<Interval>
	/// </summary>
	public class IntervalComparer : IComparer<Interval>
	{
		public int Compare(Interval x, Interval y)
		{
			if (x == null)
			{
				// x is null, y is null
				if (y == null)
				{
					return 0;
				}
				else // x is null, y is !null
				{
					return -1;
				}
			}
			else
			{
				// x is !null, y is null
				if (y == null)
				{
					return 1;
				}
				else
				{
					// In this case there doesn't need to be a distinction for x.Start == y.Start cases as they will get merged anyway.
					// if the Interval class is extended and used for other operations the equal-case should naturally be given consideration and accordingly implemented.
					if (x.Start < y.Start)
					{
						return -1;
					}
					else
					{
						return 1;
					}
				}
			}
		}
	}
}
