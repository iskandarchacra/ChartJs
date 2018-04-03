using ChartJs.Models;
using ChartJs.Models.Datasets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ChartJs.Services.JsonConverters
{
    public class ChartJsonConverter<T> : BaseEntityJsonConverter where T: Dataset
	{
		public ChartJsonConverter() : base(typeof(Chart<T>))
		{
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var chartModel = (Chart<T>)value;
			var chartModelJsonObject = JObject.FromObject(chartModel, this.serializer);

            chartModelJsonObject.Property("animation").Remove();
			chartModelJsonObject.WriteTo(writer);
		}
	}
}
