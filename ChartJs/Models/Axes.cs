namespace ChartJs.Models
{
    public class Axes
    {
        public ScaleType Type { get; set; }

        public bool Display { get; set; } = true;

        public int Weight { get; set; }

        public Grid GridLines { get; set; }

        public Label ScaleLabel { get; set; }

        public Ticks Ticks { get; set; }

        public string StepSize { get; set; }

        public PositionType Position { get; set; }

        public bool Stacked { get; set; }
    }
}
