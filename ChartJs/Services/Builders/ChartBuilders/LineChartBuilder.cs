using System.Collections.Generic;
using ChartJs.Models;
using ChartJs.Models.Datasets;
using ChartJs.Models.Options.LineChart;
using ChartJs.Services.DefaultValuesGenerator;
using ChartJs.Services.TemplateWriter;
using ChartJs.Services.Validators;

namespace ChartJs.Services.Builders
{
    public class LineChartBuilder : ChartBuilder<LineChartBuilder, LineDataset> 
    {
        public static LineChartOptions chartOptions;

        protected override LineChartBuilder BuilderInstance => this;

        public LineChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IJsTemplateWriter jsTemplateWriter, Data<LineDataset> data) 
            : base(defaultChartGenerator, chartValidator, jsTemplateWriter)
        {
            base.Chart = defaultChartGenerator.GenerateLineChart();
            base.Chart.Data = data;

            chartOptions = (LineChartOptions)Chart.Options;
		}

        /// <summary>
        /// Line charts can be configured into stacked area charts by changing the settings on the y axis to enable stacking. 
        /// Stacked area charts can be used to show how one data trend is made up of a number of smaller pieces.
        /// </summary>
        /// <returns>The is stacked.</returns>
        /// <param name="stacked">If set to <c>true</c> stacked.</param>
        public LineChartBuilder SetIsStacked(bool stacked)
        {
            Chart.Options.Scales.YAxes[0].Stacked = stacked;

            return this;
        }

        /// <summary>
        /// Sets whethere the line is drawn for this dataset.
        /// </summary>
        /// <returns>The show line.</returns>
        /// <param name="showLines">If set to <c>true</c> show lines.</param>
        public LineChartBuilder SetShowLine(bool showLines)
        {
            chartOptions.ShowLines = showLines;

            return this;
        }

        /// <summary>
        /// If true, lines will be drawn between points with no or null data. 
        /// If false, points with NaN data will create a break in the line
        /// </summary>
        /// <returns>The span gaps.</returns>
        /// <param name="spanGaps">If set to <c>true</c> span gaps.</param>
        public LineChartBuilder SetSpanGaps(bool spanGaps)
        {
            chartOptions.SpanGaps = spanGaps;

            return this;
        }

        public override Chart<LineDataset> BuildChart()
        {
            Chart.Options = chartOptions;
			var errors = new List<string>();

			chartValidator.IsValid(Chart, out errors);
			jsTemplateWriter.OverwriteTemplate(Chart);

			return Chart;
        }
    }
}
