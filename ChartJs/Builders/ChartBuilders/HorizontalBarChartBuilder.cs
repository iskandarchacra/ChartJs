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
        public HorizontalBarChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IChartJsonHelper chartJsonHelper, Data<BarDataset> data) : base(defaultChartGenerator, chartValidator, chartJsonHelper, data)
        {
			Chart = defaultChartGenerator.GenerateHorizontalBarChart();
			ChartOptions = (BarChartOptions)Chart.Options;
			Chart.Data = data;
		}

        public override string BuildChart()
        {
			var errors = new List<string>();

			chartValidator.IsValid(Chart, out errors);

            return chartJsonHelper.OverwriteTemplate(Chart);
        }
    }
}
