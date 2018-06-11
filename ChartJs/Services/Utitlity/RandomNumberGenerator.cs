using System;

namespace ChartJs.Services.Utility
{
	public static class RandomNumberGenerator
	{
		static Random random;

		static void Init()
		{
            if (random == null) 
            {
                random = new Random(); 
            }
		}

		public static int Random(int min, int max)
		{
			Init();

			return random.Next(min, max);
		}
	}
}
