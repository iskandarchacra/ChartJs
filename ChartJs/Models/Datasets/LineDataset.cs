namespace ChartJs.Models.Datasets
{
    public class LineDataset : Dataset
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

        public bool ShowLine { get; set; } = true;

        public bool SpanGaps { get; set; } = false;

        public bool SteppedLine { get; set; } 

		public int[] Data { get; set; }
    }
}
