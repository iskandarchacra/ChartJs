using System.Collections.Generic;
using ChartJs.Models;
using ChartJs.Models.Datasets;
using ChartJs.Services.DefaultValuesGenerator;
using ChartJs.Services.Utility;
using ChartJs.Services.Validators;
using static ChartJs.Services.Builders.DataBuilders.ChartJs.Services.Builders.RadarDataStepsBuilder;
using ChartJs.Services.TemplateWriter;

namespace ChartJs.Services.Builders.DataBuilders
{
	namespace ChartJs.Services.Builders
	{
		public class RadarDataStepsBuilder
		{
            readonly IRandomColorGenerator randomColorGenerator;
            readonly IChartValidator chartValidator;
            readonly IJsTemplateWriter jsTemplateWriter;
            readonly IDefaultChartGenerator defaultChartGenerator;

			public RadarDataStepsBuilder(IRandomColorGenerator randomColorGenerator, IChartValidator chartValidator, IJsTemplateWriter jsTemplateWriter, IDefaultChartGenerator defaultChartGenerator)
			{
                this.randomColorGenerator = randomColorGenerator;
                this.chartValidator = chartValidator;
                this.jsTemplateWriter = jsTemplateWriter;
                this.defaultChartGenerator = defaultChartGenerator;
            }

			public ICreateRadarDataBuilderStep StartBuildingChartData()
			{
				return new RadarDataBuilder(randomColorGenerator, chartValidator, jsTemplateWriter, defaultChartGenerator);
			}

			public interface ICreateRadarDataBuilderStep
			{
				ISetRadarDataLabelsStep SetDataLabels(string[] dataLabels);
			}

			public interface ISetRadarDataLabelsStep
			{
				RadarDataBuilder AddDataset(int[] value, string label);
			}
		}
	}
    public class RadarDataBuilder: ISetRadarDataLabelsStep, ICreateRadarDataBuilderStep
    {
        protected Data<RadarDataset> data;
		protected int index = -1;
        readonly IRandomColorGenerator randomColorGenerator;
        readonly IChartValidator chartValidator;
        readonly IJsTemplateWriter jsTemplateWriter;
        readonly IDefaultChartGenerator defaultChartGenerator;
        string[] baseColorArray;
        public RadarDataBuilder (IRandomColorGenerator randomColorGenerator, IChartValidator chartValidator, IJsTemplateWriter jsTemplateWriter, IDefaultChartGenerator defaultChartGenerator) 
        {
            this.randomColorGenerator = randomColorGenerator;
            this.chartValidator = chartValidator;
            this.jsTemplateWriter = jsTemplateWriter;
            this.defaultChartGenerator = defaultChartGenerator;

            data = new Data<RadarDataset>
            {
                Datasets = new List<RadarDataset>()
            };
        }

        public ISetRadarDataLabelsStep SetDataLabels(string[] dataLabels)
        {
            data.Labels = dataLabels;

            return this;
        }

        public RadarDataBuilder AddDataset(int[] value, string label)
        {
            data.Datasets.Add(new RadarDataset());


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
		/// The fill color under the line.
		/// </summary>
		/// <returns>The background color.</returns>
		/// <param name="backgroundColor">Background color.</param>
		public RadarDataBuilder SetBackgroundColor(string[] backgroundColor)
		{
			data.Datasets[index].BackgroundColor = backgroundColor;

            return this;
		}

		/// <summary>
		/// The color of the line.
		/// </summary>
		/// <returns>The border color.</returns>
		/// <param name="borderColor">Border color.</param>
		public RadarDataBuilder SetBorderColor(string[] borderColor)
		{
			data.Datasets[index].BorderColor = borderColor;

            return this;
		}

		/// <summary>
		/// The width of the line in pixels.
		/// </summary>
		/// <returns>The border width.</returns>
		/// <param name="borderWidth">Border width.</param>
		public RadarDataBuilder SetBorderWidth(int[] borderWidth)
		{
			data.Datasets[index].BorderWidth = borderWidth;

            return this;
		}

		/// <summary>
		/// Length and spacing of dashes.
		/// </summary>
		/// <returns>The border dash.</returns>
		/// <param name="borderDash">Border dash.</param>
		public RadarDataBuilder SetBorderDash(int[] borderDash)
        {
            data.Datasets[index].BorderDash = borderDash;

            return this;
        }

		/// <summary>
		/// Offset for line dashes. 
		/// </summary>
		/// <returns>The border dash offset.</returns>
		/// <param name="borderDashOffset">Border dash offset.</param>
		public RadarDataBuilder SetBorderDashOffset(int borderDashOffset)
        {
            data.Datasets[index].BorderDashOffset = borderDashOffset;

            return this;
        }

		/// <summary>
		/// Cap style of the line.
		/// </summary>
		/// <returns>The border cap style.</returns>
		/// <param name="borderCapStyle">Border cap style.</param>
		public RadarDataBuilder SetBorderCapStyle(string borderCapStyle)
        {
            data.Datasets[index].BorderCapStyle = borderCapStyle;

            return this;
        }

		/// <summary>
		/// Line joint style.
		/// </summary>
		/// <returns>The border join style.</returns>
		/// <param name="borderJoinStyle">Border join style.</param>
		public RadarDataBuilder SetBorderJoinStyle(string borderJoinStyle)
        {
            data.Datasets[index].BorderJoinStyle = borderJoinStyle;

            return this;
        }

		/// <summary>
		/// How to fill the area under the line.
		/// </summary>
		/// <returns>The fill.</returns>
		/// <param name="fill">If set to <c>true</c> fill.</param>
		public RadarDataBuilder SetFill(bool fill)
        {
            data.Datasets[index].Fill = fill;

            return this;
        }

		/// <summary>
		/// Bezier curve tension of the line. 
        /// Set to 0 to draw straightlines.
		/// </summary>
		/// <returns>The line tension.</returns>
		/// <param name="lineTension">Line tension.</param>
		public RadarDataBuilder SetLineTension(int lineTension)
        {
            data.Datasets[index].LineTension = lineTension;

            return this;
        }

		/// <summary>
		/// The fill color for points.
		/// </summary>
		/// <returns>The point background color.</returns>
		/// <param name="pointBackgroundColor">Point background color.</param>
		public RadarDataBuilder SetPointBackgroundColor(string [] pointBackgroundColor)
        {
            data.Datasets[index].PointBackgroundColor = pointBackgroundColor;

            return this;
        }

		/// <summary>
		/// The border color for points.
		/// </summary>
		/// <returns>The point border color.</returns>
		/// <param name="pointBorderColor">Point border color.</param>
		public RadarDataBuilder SetPointBorderColor(string [] pointBorderColor)
        {
            data.Datasets[index].PointBorderColor = pointBorderColor;

            return this;
        }

        /// <summary>
        /// The width of the point border in pixels.
        /// </summary>
        /// <returns>The point border width.</returns>
        /// <param name="pointBorderWidth">Point border width.</param>
        public RadarDataBuilder SetPointBorderWidth(int[] pointBorderWidth)
        {
            data.Datasets[index].PointBorderWidth = pointBorderWidth;

            return this;
        }

		/// <summary>
		/// The radius of the point shape. 
        /// If set to 0, the point is not rendered.
		/// </summary>
		/// <returns>The point radius.</returns>
		/// <param name="pointRadius">Point radius.</param>
		public RadarDataBuilder SetPointRadius(int[] pointRadius)
        {
            data.Datasets[index].PointRadius = pointRadius;

            return this;
        }

		/// <summary>
		/// Style of the point. 
		/// </summary>
		/// <returns>The point style.</returns>
		/// <param name="pointStyle">Point style.</param>
		public RadarDataBuilder SetPointStyle(PointStyleType pointStyle)
        {
            data.Datasets[index].PointStyle = pointStyle;

            return this;
        }

		/// <summary>
		/// The pixel size of the non-displayed point that reacts to mouse events.
		/// </summary>
		/// <returns>The point hit radius.</returns>
		/// <param name="pointHitRadius">Point hit radius.</param>
		public RadarDataBuilder SetPointHitRadius(int [] pointHitRadius)
        {
            data.Datasets[index].PointHitRadius = pointHitRadius;

            return this;
        }

		/// <summary>
		/// Point background color when hovered.
		/// </summary>
		/// <returns>The point hover background color.</returns>
		/// <param name="pointHoverBackgroundColor">Point hover background color.</param>
		public RadarDataBuilder SetPointHoverBackgroundColor(string [] pointHoverBackgroundColor)
        {
            data.Datasets[index].PointHoverBackgroundColor = pointHoverBackgroundColor;

            return this;
        }

		/// <summary>
		/// Point border color when hovered.
		/// </summary>
		/// <returns>The point hover border color.</returns>
		/// <param name="pointHoverBorderColor">Point hover border color.</param>
		public RadarDataBuilder SetPointHoverBorderColor(string [] pointHoverBorderColor)
        {
            data.Datasets[index].PointHoverBorderColor = pointHoverBorderColor;

            return this;
        }

		/// <summary>
		/// Border width of point when hovered.
		/// </summary>
		/// <returns>The point hover border width.</returns>
		/// <param name="pointHoverBorderWidth">Point hover border width.</param>
		public RadarDataBuilder SetPointHoverBorderWidth(int[] pointHoverBorderWidth)
        {
            data.Datasets[index].PointHoverBorderWidth = pointHoverBorderWidth;

            return this;
        }

		/// <summary>
		/// The radius of the point when hovered.
		/// </summary>
		/// <returns>The point hover radius.</returns>
		/// <param name="pointHoverRadius">Point hover radius.</param>
		public RadarDataBuilder SetPointHoverRadius(int [] pointHoverRadius)
        {
            data.Datasets[index].PointHoverRadius = pointHoverRadius;

            return this;
        }

        public RadarChartBuilder CreateDataAndStartBuildingChart()
        {
			return new RadarChartBuilder(defaultChartGenerator, chartValidator, jsTemplateWriter, data);
        }
    }
}
