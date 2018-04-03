using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace ChartJs.Services.JsonConverters
{
	public abstract class BaseEntityJsonConverter : JsonConverter
	{
		public readonly Type entityType;
		public readonly JsonSerializer serializer;

		protected BaseEntityJsonConverter(Type entityType)
		{
			this.entityType = entityType;

			var settings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				ContractResolver = new CamelCasePropertyNamesContractResolver(),
				Converters = new List<JsonConverter>
				{
                    new StringEnumConverter()
				}
			};

			serializer = JsonSerializer.Create(settings);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) => null;

		public override bool CanRead => false;

  		public override bool CanConvert(Type objectType) => objectType.Equals(entityType);
	}
}
