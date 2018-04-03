namespace ChartJs.Models
{
    public class Grid
    {
        public bool Display { get; set; } 

		public string Color { get; set; }

		public int[] BorderDash { get; set; }

        public int BorderDashOffset { get; set; }

        public int LineWidth { get; set; }

        public bool DrawBorder { get; set; } 

        public bool DrawOnChartArea { get; set; } 

        public bool DrawTicks { get; set; } 

        public int TickMarkLength { get; set; }

        public int ZeroLineWidth { get; set; }

        public string ZeroLineColor { get; set; }

        public int[] ZeroLineBorderDash { get; set; }

        public int ZeroLineBorderDashOffset { get; set; } 

        public bool OffsetGridLines { get; set; } = false;
	}
}
