using System.Collections.Generic;
using ChartJs.Models;
using ChartJs.Models.Datasets;
using ChartJs.Services.JsonConverters;
using ChartJs.Services.TemplateWriter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ChartJs.Services
{
    public class ChartJsonHelper : IChartJsonHelper
    {
        private const string template = "Chart.defaults.scale.ticks.beginAtZero = true; \nChart.defaults.global.hover.mode = 'nearest'; \nChart.defaults.global.animation.easing = '{ANIMATION}'; \nvar generatedChart = new Chart({CHART_VARIABLE}, {CHART_JSON});";
        readonly string chartVariableName;

        public ChartJsonHelper(string chartVariableName)
        {
            this.chartVariableName = chartVariableName;
        }

        public string OverwriteTemplate<T>(Chart<T> chart) where T : Dataset
        {
            var overWrittenTemplate = template;

            overWrittenTemplate = overWrittenTemplate.Replace("{CHART_VARIABLE}", chartVariableName);
            overWrittenTemplate = overWrittenTemplate.Replace("{ANIMATION}", chart.Animation.ToString());

			var chartJson = JsonConvert.SerializeObject
            (
                chart,
                new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = new List<JsonConverter>
                    {
                        new StringEnumConverter(),
                        new ChartJsonConverter<T>()
                    },
					NullValueHandling = NullValueHandling.Ignore
				}
			);

            overWrittenTemplate = overWrittenTemplate.Replace("{CHART_JSON}", chartJson);

            return overWrittenTemplate;
        }
	}
}
