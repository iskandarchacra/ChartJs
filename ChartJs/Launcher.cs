using ChartJs.Services.Builders;

namespace ChartJs
{
    public class Launcher
	{
       	public static void Main()
		{
            var chartJsProgram = new SampleChartJsProgram(@"C:\Users\iskan\Desktop\ChartOutput\js\main.js", "myChart");

            //chartJsProgram.BarChart();
            //chartJsProgram.MultiDatasetBarChart();

            //chartJsProgram.PieChart();
            //chartJsProgram.MultiDatasetPieChart();

            // chartJsProgram.LineChart();
            //chartJsProgram.MultiDatasetLineChart();

            //chartJsProgram.RadarChart();;
            //chartJsProgram.MultiDatasetRadarChart();

            //chartJsProgram.BubbleChart();
            //chartJsProgram.MultiDatasetBubbleChart();

            //chartJsProgram.DoughnutChart();
            //chartJsProgram.MultiDatasetDoughnutChart();

            //chartJsProgram.HorizontalBarChart();
            //chartJsProgram.MultiDatasetHorizontalBarChart();
        }
	}
}
