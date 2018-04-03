using System.Collections.Generic;
using ChartJs.Models;
using ChartJs.Models.Datasets;
using ChartJs.Services.Builders;

namespace ChartJs
{
    public class SampleChartJsProgram
    {
        private readonly string jsTemplate;
        private readonly string chartId; 

        public SampleChartJsProgram(string jsTemplate, string chartId)
        {
            this.jsTemplate = jsTemplate;
            this.chartId = chartId;
        }

        public Chart<BarDataset> MultiDatasetBarChart()
        {
            return new ChartJsBuilder(jsTemplate, chartId).CreateBarChart()
                .StartBuildingChartData()
                    .SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
                        .AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
                        .AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
                        .AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
                .CreateDataAndStartBuildingChart()
                .BuildChart();
        }

		public Chart<BarDataset> BarChart()
		{
			return new ChartJsBuilder(jsTemplate, chartId).CreateBarChart()
				.StartBuildingChartData()
				    .SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				        .AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
				.CreateDataAndStartBuildingChart()
                .SetOffsetGridLines(false)
				.BuildChart();
		}

		public Chart<BarDataset> MultiDatasetHorizontalBarChart()
		{
			return new ChartJsBuilder(jsTemplate, chartId).CreateHorizontalBarChart()
				.StartBuildingChartData()
				    .SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				    .AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
				    .AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
				    .AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

		public Chart<BarDataset> HorizontalBarChart()
		{
			return new ChartJsBuilder(jsTemplate, chartId).CreateHorizontalBarChart()
				.StartBuildingChartData()
				    .SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				        .AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<LineDataset> MultiDatasetLineChart()
		{
			return new ChartJsBuilder(jsTemplate, chartId).CreateLineChart()
				.StartBuildingChartData()
				    .SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				        .AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
                    .SetFill(true)
				        .AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
                    .SetFill(true)
				        .AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<LineDataset> LineChart()
		{
			return new ChartJsBuilder(jsTemplate, chartId).CreateLineChart()
				.StartBuildingChartData()
				    .SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				        .AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
                    .SetFill(true)
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<RadarDataset> MultiDatasetRadarChart()
		{
			return new ChartJsBuilder(jsTemplate, chartId).CreateRadarChart()
				.StartBuildingChartData()
				    .SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				        .AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
                    .SetFill(true)
				        .AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
                    .SetFill(true)
				        .AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
                    .SetFill(true)
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<RadarDataset> RadarChart()
		{
			return new ChartJsBuilder(jsTemplate, chartId).CreateRadarChart()
				.StartBuildingChartData()
				    .SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				        .AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
                    .SetFill(true)
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<DoughnutDataset> MultiDatasetDoughnutChart()
		{
			return new ChartJsBuilder(jsTemplate, chartId).CreateDoughnutChart()
				.StartBuildingChartData()
				    .SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				        .AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
				        .AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
				        .AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<DoughnutDataset> DoughnutChart()
		{
			return new ChartJsBuilder(jsTemplate, chartId).CreateDoughnutChart()
				.StartBuildingChartData()
				    .SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				        .AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<DoughnutDataset> MultiDatasetPieChart()
		{
			return new ChartJsBuilder(jsTemplate, chartId).CreatePieChart()
				.StartBuildingChartData()
				    .SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				        .AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
				        .AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
				        .AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<DoughnutDataset> PieChart()
		{
			return new ChartJsBuilder(jsTemplate, chartId).CreatePieChart()
				.StartBuildingChartData()
				    .SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
				        .AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}

        public Chart<BubbleDataset> BubbleChart()
        {		
			return new ChartJsBuilder(jsTemplate, chartId).CreateBubbleChart()
				.StartBuildingChartData()
				    .SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
                        .AddDataset(new List<BubblePoint> 
                        { 
                            new BubblePoint { R = 4, X = 20, Y = 30 },
                            new BubblePoint { R = 4, X = 15, Y = 15 },
                            new BubblePoint { R = 4, X = 10, Y = 10 }
                        }, "First Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
        }

        public Chart<BubbleDataset> MultiDatasetBubbleChart()
        {
            return new ChartJsBuilder(jsTemplate, chartId).CreateBubbleChart()
                .StartBuildingChartData()
                    .SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
                        .AddDataset(new List<BubblePoint>
                        {
                            new BubblePoint { R = 4, X = 20, Y = 30 },
					        new BubblePoint { R = 1, X = 4, Y = 23 },
					        new BubblePoint { R = 8, X = 9, Y = 26 }
                        }, "First Dataset")
                        .AddDataset(new List<BubblePoint>
                        {
                            new BubblePoint { R = 5, X= 15, Y = 15 },
					        new BubblePoint { R = 5, X = 85, Y = 15 },
					        new BubblePoint { R = 4, X = 45, Y = 52 }
                        }, "Second Dataset")
                        .AddDataset(new List<BubblePoint>
                        {
                            new BubblePoint { R = 9, X = 5, Y = 10 },
					        new BubblePoint { R = 4, X = 66, Y = 41 },
					        new BubblePoint { R = 4, X = 33, Y = 4 }
                        }, "Third Dataset")
				.CreateDataAndStartBuildingChart()
				.BuildChart();
		}
    }
}

