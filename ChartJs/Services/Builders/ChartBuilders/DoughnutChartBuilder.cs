using System.Collections.Generic;
using ChartJs.Models;
using ChartJs.Models.Datasets;
using ChartJs.Models.Options.DoughnutChart;
using ChartJs.Services.DefaultValuesGenerator;
using ChartJs.Services.TemplateWriter;
using ChartJs.Services.Validators;

namespace ChartJs.Services.Builders
{
    public class DoughnutChartBuilder : ChartBuilder<DoughnutChartBuilder, DoughnutDataset>
    {
		public static DoughnutChartOptions chartOptions;

        protected override DoughnutChartBuilder BuilderInstance => this;

        public DoughnutChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IJsTemplateWriter jsTemplateWriter, Data<DoughnutDataset> data) 
            : base(defaultChartGenerator, chartValidator, jsTemplateWriter)
        {
            base.Chart = defaultChartGenerator.GenerateDoughnutChart();
            base.Chart.Data = data;
            chartOptions = (DoughnutChartOptions)base.Chart.Options;
        }

        public DoughnutChartBuilder SetCutoutPercentage(int cutoutPercentage)
        {
            chartOptions.CutoutPercentage = cutoutPercentage;

            return this;
        }

        public DoughnutChartBuilder SetRotation(double rotation)
        {
            chartOptions.Rotation = rotation;

            return this;
        }

        public DoughnutChartBuilder SetCircumference(double circumference)
        {
            chartOptions.Circumference = circumference;

            return this;
        }

        public DoughnutChartBuilder SetAnimateRotation(bool animateRotation)
        {
            chartOptions.Animation.AnimateRotate = animateRotation;

            return this;
        }

        public DoughnutChartBuilder SetAnimateScale(bool animateScale)
        {
            chartOptions.Animation.AnimateScale = animateScale;

            return this;
        }

        public override Chart<DoughnutDataset> BuildChart()
        {
			var errors = new List<string>();

            base.Chart.Options = chartOptions;
            chartValidator.IsValid(Chart, out errors);
			jsTemplateWriter.OverwriteTemplate(Chart);

			return Chart;
        }
    }
}
