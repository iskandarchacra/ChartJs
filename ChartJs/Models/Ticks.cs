namespace ChartJs.Models
{
    public class Ticks
    {
        public bool Display { get; set; } 

        public string FontColor { get; set; } 

        public string FontFamily { get; set; } 

        public int FontSize { get; set; }

        public FontStyleType FontStyle { get; set; } 

        public bool Reverse { get; set; }

        public MajorMinorTick Minor { get; set; }

        public MajorMinorTick Major { get; set; }
    }
}
