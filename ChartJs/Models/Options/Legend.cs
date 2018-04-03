namespace ChartJs.Models.Options
{
    public class Legend
    {
        public bool Display { get; set; } = true;

        public PositionType Position { get; set; }

        public bool FullWidth { get; set; } = true;

        public bool Reverse { get; set; } = false;

        public LegendLabel Labels { get; set; }
    }
}