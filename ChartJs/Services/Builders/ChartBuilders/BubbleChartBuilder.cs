using System.Collections.Generic;
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

        public BubbleChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IJsTemplateWriter jsTemplateWriter, Data<BubbleDataset> data) : base(defaultChartGenerator, chartValidator, jsTemplateWriter)
        {
            base.Chart = defaultChartGenerator.GenerateBubbleChart();
            base.Chart.Data = data;
        }

        public override Chart<BubbleDataset> BuildChart()
        {
            var errors = new List<string>(); 

            chartValidator.IsValid(Chart,out errors);
			jsTemplateWriter.OverwriteTemplate(Chart);

			return Chart;
        }
    }
}
