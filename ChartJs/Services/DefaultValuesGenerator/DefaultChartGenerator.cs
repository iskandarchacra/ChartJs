using System;
using ChartJs.Models;
using ChartJs.Models.Datasets;
using ChartJs.Models.Options;
using ChartJs.Models.Options.BarChart;
using ChartJs.Models.Options.DoughnutChart;
using ChartJs.Models.Options.LineChart;
using ChartJs.Models.Options.RadarChart;

namespace ChartJs.Services.DefaultValuesGenerator
{
    public class DefaultChartGenerator : IDefaultChartGenerator
    {
        public Legend legend;
        public Title title;
        public Ticks ticks;
        public Axes yAxes;
        public Axes xAxes;

        public DefaultChartGenerator()
        {
			ticks = new Ticks
			{
				Display = true,
				FontColor = "#666",
				FontFamily = "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
				FontSize = 12,
				FontStyle = FontStyleType.normal,
				Major = new MajorMinorTick
				{
					FontColor = "#666",
					FontFamily = "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
					FontSize = 12,
					FontStyle = FontStyleType.normal
				},
				Minor = new MajorMinorTick
				{
					FontColor = "#666",
					FontFamily = "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
					FontSize = 12,
					FontStyle = FontStyleType.normal
				}
			};

            xAxes = new Axes
            {
                Type = ScaleType.category,
                Display = true,
                Position = PositionType.bottom,
				GridLines = new Grid
				{
					Display = true,
					Color = "rgba(0, 0, 0, 0.1)",
					LineWidth = 1,
					DrawBorder = true,
					DrawOnChartArea = true,
					DrawTicks = true,
					TickMarkLength = 10,
					ZeroLineWidth = 1,
					ZeroLineColor = "rgba(0, 0, 0, 0.1)"
				},
				Ticks = ticks
            };

            yAxes = new Axes
            {
                Type = ScaleType.linear,
                Display = true,
                Position = PositionType.left,
                GridLines = new Grid
                {
                    Display = true,
                    Color = "rgba(0, 0, 0, 0.1)",
                    LineWidth = 1,
                    DrawBorder = true,
                    DrawOnChartArea = true,
                    DrawTicks = true,
                    TickMarkLength = 10,
                    ZeroLineWidth = 1,
                    ZeroLineColor = "rgba(0, 0, 0, 0.1)"
                },
                Ticks = ticks
            };

            legend = new Legend
            {
                Display = true,
                FullWidth = true,
                Labels = new LegendLabel
                {
                    BoxWidth = 40,
                    FontSize = 12,
                    FontStyle = FontStyleType.normal,
                    FontColor = "#666",
                    FontFamily = "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                    Padding = 10
                }
            };

            title = new Title
            {
                FontSize = 12,
                FontFamily = "'Helvetica Neue', 'Helvetica', 'Arial', sans-serif",
                FontColor = "#666",
                Padding = 10,
                LineHeight = 1.2
            };
        }

        public Chart<LineDataset> GenerateLineChart()
        {
            return new Chart<LineDataset>
            {
                Type = ChartType.line,
                Options = new LineChartOptions
                {
                    ShowLines = true,
                    Scales = new Scale
                    {
                        XAxes = new Axes[]
                        {
                            xAxes
                        },
                        YAxes = new Axes[]
                        {
                            yAxes
                        }
                    },
					Legend = legend,
					Title = title
				}
			};
		}

        public Chart<RadarDataset> GenerateRadarChart()
        {
            xAxes.Display = false;

            return new Chart<RadarDataset>
            {
                Type = ChartType.radar,
                Options = new Option
                {
                    Scales = new RadarOptionsScale
                    {
                        Display = false
                    },
                    Legend = legend,
                    Title = title
                }
            };
        }

        public Chart<DoughnutDataset> GenerateDoughnutChart()
        {
            return new Chart<DoughnutDataset>
            {
                Type = ChartType.doughnut,
                Options = new DoughnutChartOptions
                {
                    CutoutPercentage = 50,
                    Rotation = -0.5 * Math.PI,
                    Circumference = 2 * Math.PI,
                    Animation = new Animation
                    {
                        AnimateRotate = true
                    },
                    Legend = legend,
                    Title = title
                }
            };
        }

        public Chart<DoughnutDataset> GeneratePieChart()
        {
			return new Chart<DoughnutDataset>
			{
                Type = ChartType.pie,
				Options = new DoughnutChartOptions
                {
                    CutoutPercentage = 0,
                    Rotation = -0.5 * Math.PI,
                    Circumference = 2 * Math.PI,
                    Animation = new Animation
                    {
                        AnimateRotate = true
                    },
					Legend = legend,
					Title = title
				}
			};
        }

		public Chart<BarDataset> GenerateBarChart()
		{
            yAxes.GridLines.OffsetGridLines = true;
            xAxes.GridLines.OffsetGridLines = true;

			return new Chart<BarDataset>
            {
                Type = ChartType.bar,
				Options = new BarChartOptions
                {
                    BarPercentage = 0.9,
                    CategoryPercentage = 0.8,
                    GridLines = new GridLines
                    {
                        OffsetGridLines = true
                    },
                    Scales = new Scale
                    {
                        XAxes = new Axes[]
                        {
                            xAxes
                        },
                        YAxes = new Axes[]
                        {
                            yAxes
                        }
                    },
					Legend = legend,
					Title = title
                }
            };
        }

        public Chart<BubbleDataset> GenerateBubbleChart()
        {
            return new Chart<BubbleDataset>
            {
                Type = ChartType.bubble,
				Options = new Option
				{
					Scales = new Scale
					{
						XAxes = new Axes[]
						{
							xAxes
						},
						YAxes = new Axes[]
                        {
                            yAxes
                        }
					},
					Legend = legend,
					Title = title
				}
            };
        }

		public Chart<BarDataset> GenerateHorizontalBarChart()
		{
            yAxes.Type = ScaleType.category;
            xAxes.Type = ScaleType.linear;
            xAxes.GridLines.OffsetGridLines = true;
            yAxes.GridLines.OffsetGridLines = true;

			return new Chart<BarDataset>
			{
				Type = ChartType.horizontalBar,
				Options = new BarChartOptions
				{
					BarPercentage = 0.9,
					CategoryPercentage = 0.8,
					GridLines = new GridLines
					{
						OffsetGridLines = true
					},
					Scales = new Scale
					{
						XAxes = new Axes[]
						{
							xAxes
						},
						YAxes = new Axes[]
						{
							yAxes
						}
					},
					Legend = legend,
					Title = title
				}
			};
		}
    }
}
