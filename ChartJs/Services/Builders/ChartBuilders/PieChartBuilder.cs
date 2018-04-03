using System.Collections.Generic;
using ChartJs.Models;
using ChartJs.Models.Datasets;
using ChartJs.Models.Options.DoughnutChart;
using ChartJs.Services.DefaultValuesGenerator;
using ChartJs.Services.TemplateWriter;
using ChartJs.Services.Validators;

namespace ChartJs.Services.Builders.ChartBuilders
{
    public class PieChartBuilder : DoughnutChartBuilder
    {
        public PieChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IJsTemplateWriter jsTemplateWriter, Data<DoughnutDataset> data) : base(defaultChartGenerator, chartValidator, jsTemplateWriter, data)
        {
            Chart = defaultChartGenerator.GeneratePieChart();
			Chart.Data = data;
		}

        public override Chart<DoughnutDataset> BuildChart()
        {
            Chart.Options = chartOptions;

			var errors = new List<string>();

			chartValidator.IsValid(Chart, out errors);
			jsTemplateWriter.OverwriteTemplate(Chart);

			return Chart;
        }
    }
}
