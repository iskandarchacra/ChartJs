namespace ChartJs.Models.Options
{
    public class Tooltip
    {
        public bool Enabled { get; set; } = true;

        public string Mode { get; set; } = "nearest";

        public bool Intersect { get; set; } = true;

        public string Position { get; set; } = "average";

        public string BackgroundColor { get; set; } = "'rgba(0,0,0,0.8)'";

        public string TitleFontFamily { get; set; } = "\"'Helvetica Neue', 'Helvetica', 'Arial', sans-serif\"";

        public int TitleFontSize { get; set; } = 12;

        public string TitleFontStyle { get; set; } = "bold";

        public string TitleFontColor { get; set; } = "#fff";

        public int TitleSpacing { get; set; } = 2;

        public int TitleMarginBottom { get; set; } = 6;

        public string BodyFontFamily { get; set; } = "\"'Helvetica Neue', 'Helvetica', 'Arial', sans-serif\"";

        public int BodyFontSize { get; set; } = 12;

        public string BodyFontStyle { get; set; } = "normal";

        public string BodyFontColor { get; set; } = "#fff";

        public int BodySpacing { get; set; } = 2;

        public string FooterFontFamily { get; set; } = "\"'Helvetica Neue', 'Helvetica', 'Arial', sans-serif\"";

        public int FooterFontSize { get; set; } = 12;

        public string FooterFontStyle { get; set; } = "bold";

        public string FooterFontColor { get; set; } = "#fff";

        public int FooterSpacing { get; set; } = 2;

        public int MarginFooterTop { get; set; } = 6;

        public int XPadding { get; set; } = 6;

        public int YPadding { get; set; } = 6;

        public int CaretPadding { get; set; } = 2;

        public int CaretSize { get; set; } = 5;

        public int CornerRadius { get; set; } = 6;

        public string MultiKeyBackground { get; set; } = "#fff";

        public bool DisplayColors { get; set; } = true;

        public string BorderColor { get; set; } = "'rgba(0,0,0,0)'";

        public int BorderWidth { get; set; } = 0;
    }
}
