using ChartJs.Models;
using System.Collections.Generic;

namespace ChartJs.Services.Utility
{
    public interface IRandomColorGenerator
    {
        string[] GenerateColorsForPointList(int [] valueArray);

        string[] GenerateColorsForBubblePointList(List<BubblePoint> bubblePointList);
    }
}
