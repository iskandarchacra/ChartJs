using System.Collections.Generic;
using System.IO;
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
    public class JsTemplateWriter : IJsTemplateWriter
    {
		readonly string javascriptFile;
        readonly string chartId;

        public JsTemplateWriter(string javascriptFile, string chartId)
        {
            this.javascriptFile = javascriptFile;
            this.chartId = chartId;
        }

        public async void OverwriteTemplate<T>(Chart<T> chart) where T : Dataset
        {
            var overWrittenTemplate = await ResourceHelper.GetChartJsTemplate();

            overWrittenTemplate = overWrittenTemplate.Replace("{chartId}", chartId);
            overWrittenTemplate = overWrittenTemplate.Replace("{animation}", chart.Animation.ToString());

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

            overWrittenTemplate = overWrittenTemplate.Replace("{chart}", chartJson);

			await File.WriteAllTextAsync(javascriptFile, overWrittenTemplate);
        }
	}
}
