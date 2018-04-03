namespace ChartJs.Models.Datasets
{
    public class RadarDataset : Dataset
    {
		public int[] BorderDash { get; set; }

		public int BorderDashOffset { get; set; }

		public string BorderCapStyle { get; set; }

		public string BorderJoinStyle { get; set; }

		public bool Fill { get; set; }

		public int LineTension { get; set; }

		public string[] PointBackgroundColor { get; set; }

		public string[] PointBorderColor { get; set; }

		public int[] PointBorderWidth { get; set; }

		public int[] PointRadius { get; set; }

		public PointStyleType PointStyle { get; set; }

		public int[] PointHitRadius { get; set; }

		public string[] PointHoverBackgroundColor { get; set; }

		public string[] PointHoverBorderColor { get; set; }

		public int[] PointHoverBorderWidth { get; set; }

		public int[] PointHoverRadius { get; set; }

		public int[] Data { get; set; }    
    }
}
