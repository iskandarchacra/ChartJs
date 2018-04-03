using System;

namespace ChartJs.Services.Utility
{
	/*
	 * This code was taken from an answer posted by Proximo on stackoverflow
	 * http://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-int-number-in-c
	 * 
	 * */
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
