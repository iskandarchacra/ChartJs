using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ChartJs.Models;
using ChartJs.Models.Datasets;
using ChartJs.Services.JsonConverters;
using ChartJs.Services.ResourceHelpers;
using ChartJs.Services.TemplateWriter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ChartJs.Services
{
    public class ChartJsonHelper : IChartJsonHelper
    {
        readonly string chartVariableName;

        public ChartJsonHelper(string chartVariableName)
        {
            this.chartVariableName = chartVariableName;
        }

        public string OverwriteTemplate<T>(Chart<T> chart) where T : Dataset
        {
            var overWrittenTemplate = ResourceHelper.GetChartJsTemplate();

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
