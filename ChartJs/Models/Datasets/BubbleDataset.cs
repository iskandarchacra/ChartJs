using System.Collections.Generic;

namespace ChartJs.Models.Datasets
{
    public class BubbleDataset : Dataset
    {
        public string HoverBackgroundColor { get; set; }

        public string HoverBorderColor { get; set; }

        public int HoverBorderWidth { get; set; } 

        public int HoverRadius { get; set; } 

        public int HitRadius { get; set; }

        public PointStyleType PointStyle { get; set; } 

        public int Radius { get; set; } 

        public List<BubblePoint> Data { get; set; }
  	}
}
