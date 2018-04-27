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
        public PieChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IChartJsonHelper chartJsonHelper, Data<DoughnutDataset> data) : base(defaultChartGenerator, chartValidator, chartJsonHelper, data)
        {
            Chart = defaultChartGenerator.GeneratePieChart();
			Chart.Data = data;
            ChartOptions = (DoughnutChartOptions)base.Chart.Options;
        }

        public override string BuildChart()
        {
            Chart.Options = ChartOptions;

			var errors = new List<string>();

			chartValidator.IsValid(Chart, out errors);

            return chartJsonHelper.OverwriteTemplate(Chart);
        }
    }
}
