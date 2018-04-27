using System.Collections.Generic;
using System.Threading.Tasks;
using ChartJs.Models;
using ChartJs.Models.Datasets;
using ChartJs.Services.DefaultValuesGenerator;
using ChartJs.Services.TemplateWriter;
using ChartJs.Services.Validators;

namespace ChartJs.Services.Builders
{
    public class BubbleChartBuilder : ChartBuilder<BubbleChartBuilder, BubbleDataset>
    {
        protected override BubbleChartBuilder BuilderInstance => this;

        public BubbleChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IChartJsonHelper chartJsonHelper, Data<BubbleDataset> data) : base(defaultChartGenerator, chartValidator, chartJsonHelper)
        {
            base.Chart = defaultChartGenerator.GenerateBubbleChart();
            base.Chart.Data = data;
        }

        public override string BuildChart()
        {
            var errors = new List<string>(); 

            chartValidator.IsValid(Chart,out errors);

			return chartJsonHelper.OverwriteTemplate(Chart);
        }
    }
}
