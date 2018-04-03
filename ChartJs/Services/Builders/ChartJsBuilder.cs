using ChartJs.Services.Builders.DataBuilders.ChartJs.Services.Builders;
using ChartJs.Services.DefaultValuesGenerator;
using ChartJs.Services.TemplateWriter;
using ChartJs.Services.Utility;
using ChartJs.Services.Validators;

namespace ChartJs.Services.Builders
{
    public class ChartJsBuilder
    {
        readonly IRandomColorGenerator randomColorGenerator;
        readonly IChartValidator chartValidator;
        readonly IJsTemplateWriter jsTemplateWriter;
        readonly IDefaultChartGenerator defaultChartGenerator;

        public ChartJsBuilder(IRandomColorGenerator randomColorGenerator, IChartValidator chartValidator, IJsTemplateWriter jsTemplateWriter, IDefaultChartGenerator defaultChartGenerator)
        {
            this.randomColorGenerator = randomColorGenerator;
            this.chartValidator = chartValidator;
            this.jsTemplateWriter = jsTemplateWriter;
            this.defaultChartGenerator = defaultChartGenerator;
        }

        public ChartJsBuilder(string javascriptFile, string chartId)
        {
            randomColorGenerator = new RandomColorGenerator();
            chartValidator = new ChartValidator();
            jsTemplateWriter = new JsTemplateWriter(javascriptFile, chartId);
            defaultChartGenerator = new DefaultChartGenerator();
        }

        public BarDataStepsBuilder CreateBarChart()
        {
            return new BarDataStepsBuilder(randomColorGenerator, chartValidator, jsTemplateWriter, defaultChartGenerator);
        }

        public BarDataStepsBuilder CreateHorizontalBarChart()
        {
            return new BarDataStepsBuilder(randomColorGenerator, chartValidator, jsTemplateWriter, defaultChartGenerator, true);
		}

        public DoughnutDataStepsBuilder CreatePieChart()
        {
            return new DoughnutDataStepsBuilder(randomColorGenerator, chartValidator, jsTemplateWriter, defaultChartGenerator, true);
        }

        public DoughnutDataStepsBuilder CreateDoughnutChart()
        {
            return new DoughnutDataStepsBuilder(randomColorGenerator, chartValidator, jsTemplateWriter, defaultChartGenerator);
        }

        public LineDataStepsBuilder CreateLineChart()
        {
            return new LineDataStepsBuilder(randomColorGenerator, chartValidator, jsTemplateWriter, defaultChartGenerator);
        }

        public RadarDataStepsBuilder CreateRadarChart()
        {
            return new RadarDataStepsBuilder(randomColorGenerator, chartValidator, jsTemplateWriter, defaultChartGenerator);
        }

        public BubbleDataStepsBuilder CreateBubbleChart()
        {
            return new BubbleDataStepsBuilder(randomColorGenerator, chartValidator, jsTemplateWriter, defaultChartGenerator);
        }
    }
}
