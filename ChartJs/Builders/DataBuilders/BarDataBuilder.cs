using ChartJs.Models.Datasets;
using ChartJs.Services.Builders.ChartBuilders;
using ChartJs.Services.Utility;

namespace ChartJs.Services.Builders.DataBuilders
{
    using System.Collections.Generic;
    using global::ChartJs.Models;
    using global::ChartJs.Services.DefaultValuesGenerator;
    using global::ChartJs.Services.Validators;
    using static global::ChartJs.Services.Builders.DataBuilders.ChartJs.Services.Builders.BarDataStepsBuilder;
    using global::ChartJs.Services.TemplateWriter;

    namespace ChartJs.Services.Builders
	{
		public class BarDataStepsBuilder
		{
            readonly IRandomColorGenerator randomColorGenerator;
            readonly IChartValidator chartValidator;
            readonly IChartJsonHelper chartJsonHelper;
            readonly IDefaultChartGenerator defaultChartGenerator;
            readonly bool isHorizontal;

			public BarDataStepsBuilder(IRandomColorGenerator randomColorGenerator, IChartValidator chartValidator, IChartJsonHelper chartJsonHelper, IDefaultChartGenerator defaultChartGenerator, bool isHorizontal = false)
			{
                this.randomColorGenerator = randomColorGenerator;
                this.chartValidator = chartValidator;
                this.chartJsonHelper = chartJsonHelper;
                this.defaultChartGenerator = defaultChartGenerator;
                this.isHorizontal = isHorizontal;
			}

			public ICreateBarDataBuilderStep StartBuildingChartData()
			{
                if (isHorizontal)
                {
                    return new BarDataBuilder(randomColorGenerator, chartValidator, chartJsonHelper, defaultChartGenerator, true);
                }

				return new BarDataBuilder(randomColorGenerator, chartValidator, chartJsonHelper, defaultChartGenerator);
			}

			public interface ICreateBarDataBuilderStep
			{
                ISetDataLabelsStep SetDataLabels(string[] dataLabels);
			}

			public interface ISetDataLabelsStep
			{
                BarDataBuilder AddDataset(int[] value, string label);
			}
        }
	}

    public class BarDataBuilder : ICreateBarDataBuilderStep, ISetDataLabelsStep
    {
        readonly IRandomColorGenerator randomColorGenerator;
        readonly IChartValidator chartValidator;
        readonly IChartJsonHelper chartJsonHelper;
        readonly IDefaultChartGenerator defaultChartGenerator;
        protected Data<BarDataset> data;
		protected int index = -1;
        readonly bool isHorizontal;
        string[] baseColorArray;

		public BarDataBuilder(IRandomColorGenerator randomColorGenerator, IChartValidator chartValidator, IChartJsonHelper chartJsonHelper, IDefaultChartGenerator defaultChartGenerator, bool isHorizontal = false)
        {
            this.randomColorGenerator = randomColorGenerator;
            this.chartValidator = chartValidator;
            this.chartJsonHelper = chartJsonHelper;
            this.defaultChartGenerator = defaultChartGenerator;
            this.isHorizontal = isHorizontal;

            data = new Data<BarDataset>
			{
                Datasets = new List<BarDataset>()
			};
        }

        public ISetDataLabelsStep SetDataLabels(string[] dataLabels)
        {
            data.Labels = dataLabels;

            return this;
        }

		public BarDataBuilder AddDataset(int[] value, string label)
		{
			data.Datasets.Add(new BarDataset());

			index++;
			data.Datasets[index].Data = value;

			if (index == 0)
			{
				data.Datasets[0].BackgroundColor = randomColorGenerator.GenerateColorsForPointList(value);

                baseColorArray = new string[data.Labels.Length];

                for (var i = 0; i < baseColorArray.Length; i++)
                {
                    baseColorArray[i] = data.Datasets[0].BackgroundColor[i];
                }
			}

			else
			{
                data.Datasets[index].BackgroundColor = new string[data.Labels.Length];

                for (var i = 0; i < baseColorArray.Length; i++ )
                {
                    data.Datasets[0].BackgroundColor[i] = baseColorArray[0];
                    data.Datasets[index].BackgroundColor[i] = baseColorArray[index];
                }
			}

			data.Datasets[index].Label = label;

			return this;
		}

		/// <summary>
		/// The fill color of the bar.
		/// </summary>
		/// <returns>The background color.</returns>
		/// <param name="backgroundColor">Background color.</param>
		public BarDataBuilder SetBackgroundColor(string[] backgroundColor)
		{
			data.Datasets[index].BackgroundColor = backgroundColor;

            return this;
		}

		/// <summary>
		/// The color of the bar border. 
		/// </summary>
		/// <returns>The border color.</returns>
		/// <param name="borderColor">Border color.</param>
		public BarDataBuilder SetBorderColor(string[] borderColor)
		{
			data.Datasets[index].BorderColor = borderColor;

            return this;
		}

		/// <summary>
		/// The stroke width of the bar in pixels.
		/// </summary>
		/// <returns>The border width.</returns>
		/// <param name="borderWidth">Border width.</param>
		public BarDataBuilder SetBorderWidth(int[] borderWidth)
		{
			data.Datasets[index].BorderWidth = borderWidth;

            return this;
		}

		/// <summary>
		/// Which edge to skip drawing the border for.
		/// </summary>
		/// <returns>The border skipped.</returns>
		/// <param name="borderSkipped">Border skipped.</param>
		public BarDataBuilder SetBorderSkipped(string borderSkipped)
        {
            data.Datasets[index].BorderSkipped = borderSkipped;

            return this;
        }

		/// <summary>
		/// The fill colour of the bars when hovered.
		/// </summary>
		/// <returns>The hover background color.</returns>
		/// <param name="hoverBackgroundColor">Hover background color.</param>
		public BarDataBuilder SetHoverBackgroundColor(string [] hoverBackgroundColor)
        {
            data.Datasets[index].HoverBackgroundColor = hoverBackgroundColor;

            return this;    
        }

		/// <summary>
		/// The stroke colour of the bars when hovered.
		/// </summary>
		/// <returns>The hover border color.</returns>
		/// <param name="hoverBorderColor">Hover border color.</param>
		public BarDataBuilder SetHoverBorderColor(string [] hoverBorderColor)
        {
            data.Datasets[index].HoverBorderColor = hoverBorderColor;

            return this;
        }

		/// <summary>
		/// The stroke width of the bars when hovered.
		/// </summary>
		/// <returns>The hover border width.</returns>
		/// <param name="hoverBorderWidth">Hover border width.</param>
		public BarDataBuilder SetHoverBorderWidth(int [] hoverBorderWidth)
        {
            data.Datasets[index].HoverBorderWidth = hoverBorderWidth;

            return this;
        }

        public BarChartBuilder CreateDataAndStartBuildingChart()
        {
            if (isHorizontal)
            {
                return new HorizontalBarChartBuilder(defaultChartGenerator, chartValidator, chartJsonHelper, data);
            }

            return new BarChartBuilder(defaultChartGenerator, chartValidator, chartJsonHelper, data);
        }
    }
}
