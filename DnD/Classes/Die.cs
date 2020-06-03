using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnD.Pages;

namespace DnD.Classes
{
	class Die
	{
		public int Count, Size;
		public string Formatted => Count + "d" + Size;

		/// <summary>
		/// Initializes the Die class with a count and a size.
		/// </summary>
		/// <param name="count">The number of times to roll the die. Equivalent to the '2' in '2d6'.</param>
		/// <param name="size">The maximum number that can be rolled on the die. Equivalent to teh '6' in '2d6'.</param>
		public Die(int count, int size)
		{
			this.Count = count;
			this.Size = size;
		}

		/// <summary>
		/// Rolls the die Count number of times.
		/// </summary>
		/// <returns>An array of the generated integers.</returns>
		public int[] Roll()
		{
			int[] values = new int[Count];
			for (int i = 0; i< Count; i++)
			{
				values[i] = MainPage.rng.Next(1, Size);
			}
			return values;
		}
	}
}
