using ChartJs.Services.Builders.DataBuilders.ChartJs.Services.Builders;
using ChartJs.Services.DefaultValuesGenerator;
using ChartJs.Services.TemplateWriter;
using ChartJs.Services.Utility;
using ChartJs.Services.Validators;

namespace ChartJs.Services.Builders
{
    /// <summary>
    /// This class is used to build Charts.
    /// </summary>
    /// <param name="chartVariableName">The name of the Javascript variable that has the HTML <canvas> element where the chart will be used. </param>
    public class ChartJsBuilder
    {
        readonly IRandomColorGenerator randomColorGenerator;
        readonly IChartValidator chartValidator;
        readonly IChartJsonHelper chartJsonHelper;
        readonly IDefaultChartGenerator defaultChartGenerator;

        public ChartJsBuilder(IRandomColorGenerator randomColorGenerator, IChartValidator chartValidator, IChartJsonHelper chartJsonHelper, IDefaultChartGenerator defaultChartGenerator)
        {
            this.randomColorGenerator = randomColorGenerator;
            this.chartValidator = chartValidator;
            this.chartJsonHelper = chartJsonHelper;
            this.defaultChartGenerator = defaultChartGenerator;
        }
        /// <summary>
        /// ChartJsBuilder constructor
        /// </summary>
        /// <param name="chartVariableName">The name of the Javascript variable that has the HTML <canvas> element where the chart will be used. </param>
        public ChartJsBuilder(string chartVariableName)
        {
            randomColorGenerator = new RandomColorGenerator();
            chartValidator = new ChartValidator();
            chartJsonHelper = new ChartJsonHelper(chartVariableName);
            defaultChartGenerator = new DefaultChartGenerator();
        }

        /// <summary>
        /// Start creating a Bar Chart
        /// </summary>
        /// <returns>BarDataStepsBuilder</returns>
        public BarDataStepsBuilder CreateBarChart()
        {
            return new BarDataStepsBuilder(randomColorGenerator, chartValidator, chartJsonHelper, defaultChartGenerator);
        }

        /// <summary>
        /// Start creating a Horizontal Bar Chart
        /// </summary>
        /// <returns>BarDataStepsBuilder</returns>
        public BarDataStepsBuilder CreateHorizontalBarChart()
        {
            return new BarDataStepsBuilder(randomColorGenerator, chartValidator, chartJsonHelper, defaultChartGenerator, true);
		}

        /// <summary>
        /// Start creating a Pie Chart
        /// </summary>
        /// <returns>DoughnutDataStepsBuilder</returns>
        public DoughnutDataStepsBuilder CreatePieChart()
        {
            return new DoughnutDataStepsBuilder(randomColorGenerator, chartValidator, chartJsonHelper, defaultChartGenerator, true);
        }

        /// <summary>
        /// Start creating a Doughnut Chart
        /// </summary>
        /// <returns>DoughnutDataStepsBuilder</returns>
        public DoughnutDataStepsBuilder CreateDoughnutChart()
        {
            return new DoughnutDataStepsBuilder(randomColorGenerator, chartValidator, chartJsonHelper, defaultChartGenerator);
        }

        /// <summary>
        /// Start creating a Line Chart
        /// </summary>
        /// <returns>LineDataStepsBuilder</returns>
        public LineDataStepsBuilder CreateLineChart()
        {
            return new LineDataStepsBuilder(randomColorGenerator, chartValidator, chartJsonHelper, defaultChartGenerator);
        }

        /// <summary>
        /// Start creating a Radar Chart
        /// </summary>
        /// <returns>RadarDataStepsBuilder</returns>
        public RadarDataStepsBuilder CreateRadarChart()
        {
            return new RadarDataStepsBuilder(randomColorGenerator, chartValidator, chartJsonHelper, defaultChartGenerator);
        }

        /// <summary>
        /// Start creating a Bubble Chart
        /// </summary>
        /// <returns>BubbleDataStepsBuilder</returns>
        public BubbleDataStepsBuilder CreateBubbleChart()
        {
            return new BubbleDataStepsBuilder(randomColorGenerator, chartValidator, chartJsonHelper, defaultChartGenerator);
        }
    }
}
