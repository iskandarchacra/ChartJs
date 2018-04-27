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
		public static DoughnutChartOptions ChartOptions;

        protected override DoughnutChartBuilder BuilderInstance => this;

        public DoughnutChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IChartJsonHelper chartJsonHelper, Data<DoughnutDataset> data) 
            : base(defaultChartGenerator, chartValidator, chartJsonHelper)
        {
            base.Chart = defaultChartGenerator.GenerateDoughnutChart();
            base.Chart.Data = data;
            ChartOptions = (DoughnutChartOptions)base.Chart.Options;
        }

        public DoughnutChartBuilder SetCutoutPercentage(int cutoutPercentage)
        {
            ChartOptions.CutoutPercentage = cutoutPercentage;

            return this;
        }

        public DoughnutChartBuilder SetRotation(double rotation)
        {
            ChartOptions.Rotation = rotation;

            return this;
        }

        public DoughnutChartBuilder SetCircumference(double circumference)
        {
            ChartOptions.Circumference = circumference;

            return this;
        }

        public DoughnutChartBuilder SetAnimateRotation(bool animateRotation)
        {
            ChartOptions.Animation.AnimateRotate = animateRotation;

            return this;
        }

        public DoughnutChartBuilder SetAnimateScale(bool animateScale)
        {
            ChartOptions.Animation.AnimateScale = animateScale;

            return this;
        }

        public override string BuildChart()
        {
			var errors = new List<string>();

            base.Chart.Options = ChartOptions;
            chartValidator.IsValid(Chart, out errors);

            return chartJsonHelper.OverwriteTemplate(Chart);
        }
    }
}
