using ChartJs.Models;
using ChartJs.Models.Datasets;

namespace ChartJs.Services.DefaultValuesGenerator
{
    public interface IDefaultChartGenerator
    {
        Chart<LineDataset> GenerateLineChart();

        Chart<RadarDataset> GenerateRadarChart();

        Chart<DoughnutDataset> GenerateDoughnutChart();

        Chart<DoughnutDataset> GeneratePieChart();

        Chart<BarDataset> GenerateBarChart();

        Chart<BarDataset> GenerateHorizontalBarChart();

        Chart<BubbleDataset> GenerateBubbleChart();
    }
}
