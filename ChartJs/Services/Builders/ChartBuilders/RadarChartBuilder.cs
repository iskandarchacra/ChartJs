using System.Collections.Generic;
using ChartJs.Models;
using ChartJs.Models.Datasets;
using ChartJs.Models.Options.RadarChart;
using ChartJs.Services.DefaultValuesGenerator;
using ChartJs.Services.TemplateWriter;
using ChartJs.Services.Validators;

namespace ChartJs.Services.Builders
{
    public class RadarChartBuilder : ChartBuilder<RadarChartBuilder, RadarDataset>
    {
		public static RadarOptionsScale radarScale;

        protected override RadarChartBuilder BuilderInstance => this;

        public RadarChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IJsTemplateWriter jsTemplateWriter, Data<RadarDataset> data) : base(defaultChartGenerator, chartValidator, jsTemplateWriter)
        {
            Chart = defaultChartGenerator.GenerateRadarChart();
            radarScale = (RadarOptionsScale)Chart.Options.Scales;
			Chart.Data = data;
		}

        /// <summary>
        /// Sets whether the scale is displayed
        /// </summary>
        /// <returns>The scale display.</returns>
        /// <param name="display">If set to <c>true</c> display.</param>
        public RadarChartBuilder SetScaleDisplay(bool display)
        {
            radarScale.Display = display;
            Chart.Options.Scales.XAxes[0].Display = display;   

            return this;
        }

        public override Chart<RadarDataset> BuildChart()
        {
			Chart.Options.Scales = radarScale;
			var errors = new List<string>();

			chartValidator.IsValid(Chart, out errors);
			jsTemplateWriter.OverwriteTemplate(Chart);

			return Chart;
        }
    }
}
