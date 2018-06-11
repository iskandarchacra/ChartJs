using System.Collections.Generic;
using ChartJs.Models;

namespace ChartJs.Services.Utility
{
    public class RandomColorGenerator : IRandomColorGenerator
    {
		public string[] GenerateColorsForPointList(int [] valueArray)
		{
            List<string> colorList = new List<string>();

            int x, y, z;
            
			for (int i = 0; i < valueArray.Length - 1; i++)
			{
				x = GetRandomNumber();
				y = GetRandomNumber();
				z = GetRandomNumber();

                colorList.Add($"rgba({x}, {y}, {z}, 0.5)");
			}

			x = GetRandomNumber();
			y = GetRandomNumber();
			z = GetRandomNumber();

            colorList.Add($"rgba({x}, {y}, {z}, 0.5)");

            return colorList.ToArray();
		}

		public string[] GenerateColorsForBubblePointList(List<BubblePoint>bubblePointList)
		{
			List<string> colorList = new List<string>();

			var x = GetRandomNumber();
			var y = GetRandomNumber();
			var z = GetRandomNumber();

			for (int i = 0; i < bubblePointList.Count - 1; i++)
			{
                colorList.Add($"rgba({x}, {y}, {z}, 0.5)");
            }

            colorList.Add($"rgba({x}, {y}, {z}, 0.5)");

            return colorList.ToArray();
		}

		public static int GetRandomNumber()
		{
			return RandomNumberGenerator.Random(1, 256);
		}
    }
}
