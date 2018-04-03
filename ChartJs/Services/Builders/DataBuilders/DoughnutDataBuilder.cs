using System.Collections.Generic;
using ChartJs.Models;
using ChartJs.Models.Datasets;
using ChartJs.Services.Builders.ChartBuilders;
using ChartJs.Services.DefaultValuesGenerator;
using ChartJs.Services.Utility;
using ChartJs.Services.Validators;
using static ChartJs.Services.Builders.DataBuilders.ChartJs.Services.Builders.DoughnutDataStepsBuilder;
using ChartJs.Services.TemplateWriter;

namespace ChartJs.Services.Builders.DataBuilders
{
	namespace ChartJs.Services.Builders
	{
		public class DoughnutDataStepsBuilder
		{
            readonly IRandomColorGenerator randomColorGenerator;
            readonly IChartValidator chartValidator;
            readonly IJsTemplateWriter jsTemplateWriter;
            readonly IDefaultChartGenerator defaultChartGenerator;
            bool isPie;

			public DoughnutDataStepsBuilder(IRandomColorGenerator randomColorGenerator, IChartValidator chartValidator, IJsTemplateWriter jsTemplateWriter,IDefaultChartGenerator defaultChartGenerator, bool isPie = false)
			{
                this.randomColorGenerator = randomColorGenerator;
                this.chartValidator = chartValidator;
                this.jsTemplateWriter = jsTemplateWriter;
                this.defaultChartGenerator = defaultChartGenerator;
                this.isPie = isPie;
			}

			public ICreateDoughnutDataBuilderStep StartBuildingChartData()
			{
                if (isPie)
                {
                    return new DoughnutDataBuilder(randomColorGenerator, chartValidator, jsTemplateWriter, defaultChartGenerator, true);
                }

                return new DoughnutDataBuilder(randomColorGenerator, chartValidator, jsTemplateWriter, defaultChartGenerator);
			}

			public interface ICreateDoughnutDataBuilderStep
			{
				ISetDoughnutDataLabelsStep SetDataLabels(string[] dataLabels);
			}

			public interface ISetDoughnutDataLabelsStep
			{
                DoughnutDataBuilder AddDataset(int[] value, string label);
			}
		}
	}

    public class DoughnutDataBuilder : ICreateDoughnutDataBuilderStep, ISetDoughnutDataLabelsStep
    {
        readonly IRandomColorGenerator randomColorGenerator;
        readonly IChartValidator chartValidator;
        readonly IJsTemplateWriter jsTemplateWriter;
        readonly IDefaultChartGenerator defaultChartGenerator;
        protected Data<DoughnutDataset> data;
		protected int index = -1;
        readonly bool isPie;
        string[] baseColorArray;

        public DoughnutDataBuilder (IRandomColorGenerator randomColorGenerator, IChartValidator chartValidator, IJsTemplateWriter jsTemplateWriter, IDefaultChartGenerator defaultChartGenerator, bool isPie = false)
        {
            this.randomColorGenerator = randomColorGenerator;
            this.chartValidator = chartValidator;
            this.jsTemplateWriter = jsTemplateWriter;
            this.defaultChartGenerator = defaultChartGenerator;
            this.isPie = isPie;

            data = new Data<DoughnutDataset>
			{
                Datasets = new List<DoughnutDataset>()
			};
        }

        public ISetDoughnutDataLabelsStep SetDataLabels(string[] dataLabels)
        {
            data.Labels = dataLabels;

            return this;       
        }

        public DoughnutDataBuilder AddDataset(int[] value, string label)
        {
			data.Datasets.Add(new DoughnutDataset());

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

				for (var i = 0; i < baseColorArray.Length; i++)
				{
					data.Datasets[0].BackgroundColor[i] = baseColorArray[0];
					data.Datasets[index].BackgroundColor[i] = baseColorArray[index];
				}
			}

			data.Datasets[index].Label = label;

			return this;
        }

		/// <summary>
		/// The fill color of the arcs in the dataset.
		/// </summary>
		/// <returns>The background color.</returns>
		/// <param name="backgroundColor">Background color.</param>
		public DoughnutDataBuilder SetBackgroundColor(string[] backgroundColor)
		{
			data.Datasets[index].BackgroundColor = backgroundColor;

            return this;
		}

		/// <summary>
		/// The border color of the arcs in the dataset.
		/// </summary>
		/// <returns>The border color.</returns>
		/// <param name="borderColor">Border color.</param>
		public DoughnutDataBuilder SetBorderColor(string[] borderColor)
		{
			data.Datasets[index].BorderColor = borderColor;

            return this;
		}

		/// <summary>
		/// The border width of the arcs in the dataset.
		/// </summary>
		/// <returns>The border width.</returns>
		/// <param name="borderWidth">Border width.</param>
		public DoughnutDataBuilder SetBorderWidth(int[] borderWidth)
		{
			data.Datasets[index].BorderWidth = borderWidth;

            return this;
		}

		/// <summary>
		/// The fill colour of the arcs when hovered.
		/// </summary>
		/// <returns>The hover background color.</returns>
		/// <param name="hoverBackgroundColor">Hover background color.</param>
		public DoughnutDataBuilder SetHoverBackgroundColor(string [] hoverBackgroundColor)
        {
            data.Datasets[index].HoverBackgroundColor = hoverBackgroundColor;

            return this;
        }

		/// <summary>
		/// The stroke colour of the arcs when hovered.
		/// </summary>
		/// <returns>The hover border color.</returns>
		/// <param name="hoverBorderColor">Hover border color.</param>
		public DoughnutDataBuilder SetHoverBorderColor(string[] hoverBorderColor)
        {
            data.Datasets[index].HoverBorderColor = hoverBorderColor;

            return this;
        }

		/// <summary>
		/// The stroke width of the arcs when hovered.
		/// </summary>
		/// <returns>The hover border width.</returns>
		/// <param name="hoverBorderWidth">Hover border width.</param>
		public DoughnutDataBuilder SetHoverBorderWidth(int[] hoverBorderWidth)
        {
            data.Datasets[index].HoverBorderWidth = hoverBorderWidth;

            return this;
        }

        public DoughnutChartBuilder CreateDataAndStartBuildingChart()
        {
            if (isPie)
            {
                return new PieChartBuilder(defaultChartGenerator, chartValidator, jsTemplateWriter, data);
            }

            return new DoughnutChartBuilder(defaultChartGenerator, chartValidator, jsTemplateWriter, data);
        }
    }
}
