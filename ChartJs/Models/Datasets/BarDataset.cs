namespace ChartJs.Models.Datasets
{
    public class BarDataset : Dataset
    {
        public string BorderSkipped { get; set; }

        public string[] HoverBackgroundColor { get; set; }

        public string[] HoverBorderColor { get; set; }

        public int[] HoverBorderWidth { get; set; }

        public int[] Data { get; set; }
    }
}
