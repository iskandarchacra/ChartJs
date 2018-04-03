namespace ChartJs.Models.Options
{
    public class Title
    {
        public bool Display { get; set; }

        public PositionType Position { get; set; }

        public int FontSize { get; set; }

        public string FontFamily { get; set; }

        public string FontColor { get; set; }

        public FontStyleType FontStyle { get; set; }

        public int Padding { get; set; }

        public double LineHeight { get; set; }

        public string[] Text { get; set; }
    }
}