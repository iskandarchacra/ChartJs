using System.Collections.Generic;
using ChartJs.Models;
using ChartJs.Models.Datasets;
using ChartJs.Models.Options.BarChart;
using ChartJs.Services.DefaultValuesGenerator;
using ChartJs.Services.TemplateWriter;
using ChartJs.Services.Validators;

namespace ChartJs.Services.Builders.ChartBuilders
{
    public class HorizontalBarChartBuilder : BarChartBuilder
    {
        public HorizontalBarChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IJsTemplateWriter jsTemplateWriter, Data<BarDataset> data) : base(defaultChartGenerator, chartValidator, jsTemplateWriter, data)
        {
			Chart = defaultChartGenerator.GenerateHorizontalBarChart();
			ChartOptions = (BarChartOptions)Chart.Options;
			Chart.Data = data;
		}

        public override Chart<BarDataset> BuildChart()
        {
			var errors = new List<string>();

			chartValidator.IsValid(Chart, out errors);
			jsTemplateWriter.OverwriteTemplate(Chart);

			return Chart;
        }
    }
}
