using System.Collections.Generic;
using ChartJs.Models;
using ChartJs.Models.Datasets;
using ChartJs.Services.DefaultValuesGenerator;
using ChartJs.Services.Utility;
using ChartJs.Services.Validators;
using static ChartJs.Services.Builders.DataBuilders.ChartJs.Services.Builders.LineDataStepsBuilder;
using ChartJs.Services.TemplateWriter;

namespace ChartJs.Services.Builders.DataBuilders
{
	namespace ChartJs.Services.Builders
	{
		public class LineDataStepsBuilder
		{
            readonly IRandomColorGenerator randomColorGenerator;
            readonly IChartValidator chartValidator;
            readonly IChartJsonHelper chartJsonHelper;
            readonly IDefaultChartGenerator defaultChartGenerator;

            public LineDataStepsBuilder(IRandomColorGenerator randomColorGenerator, IChartValidator chartValidator, IChartJsonHelper chartJsonHelper, IDefaultChartGenerator defaultChartGenerator)
			{
                this.randomColorGenerator = randomColorGenerator;
                this.chartValidator = chartValidator;
                this.chartJsonHelper = chartJsonHelper;
                this.defaultChartGenerator = defaultChartGenerator;
            }

			public ICreateLineDataBuilderStep StartBuildingChartData()
			{
				return new LineDataBuilder(randomColorGenerator, chartValidator, chartJsonHelper, defaultChartGenerator);
			}

			public interface ICreateLineDataBuilderStep
			{
				ISetLineDataLabelsStep SetDataLabels(string[] dataLabels);
			}

			public interface ISetLineDataLabelsStep
			{
				LineDataBuilder AddDataset(int[] value, string label);
			}
		}
	}

    public class LineDataBuilder : ICreateLineDataBuilderStep, ISetLineDataLabelsStep
    {
        readonly IRandomColorGenerator randomColorGenerator;
        readonly IChartValidator chartValidator;
        readonly IChartJsonHelper chartJsonHelper;
        readonly IDefaultChartGenerator defaultChartGenerator;
        protected Data<LineDataset> data;
		protected int index = -1;

        public LineDataBuilder(IRandomColorGenerator randomColorGenerator, IChartValidator chartValidator, IChartJsonHelper chartJsonHelper, IDefaultChartGenerator defaultChartGenerator)
        {
            this.randomColorGenerator = randomColorGenerator;
            this.chartValidator = chartValidator;
            this.chartJsonHelper = chartJsonHelper;
            this.defaultChartGenerator = defaultChartGenerator;

            data = new Data<LineDataset>
			{
                Datasets = new List<LineDataset>()
			};
        }

		public ISetLineDataLabelsStep SetDataLabels(string[] dataLabels)
		{
			data.Labels = dataLabels;

			return this;
		}

		/// <summary>
		/// Adds the dataset.
		/// </summary>
		/// <returns>The dataset.</returns>
		/// <param name="value">Value.</param>
		/// <param name="label">The label for the dataset which appears in the legend and tooltips.</param>
		public LineDataBuilder AddDataset(int[] value, string label)
        {
			data.Datasets.Add(new LineDataset());

			index++;
			data.Datasets[index].Data = value;
			data.Datasets[index].BackgroundColor = randomColorGenerator.GenerateColorsForPointList(value);
			data.Datasets[index].Label = label;

			return this;
        }

		/// <summary>
		/// The fill color under the line.
		/// </summary>
		/// <returns>The background color.</returns>
		/// <param name="backgroundColor">Background color.</param>
		public LineDataBuilder SetBackgroundColor(string[] backgroundColor)
		{
			data.Datasets[index].BackgroundColor = backgroundColor;

            return this;
		}

		/// <summary>
		/// The color of the line. 
		/// </summary>
		/// <returns>The border color.</returns>
		/// <param name="borderColor">Border color.</param>
		public LineDataBuilder SetBorderColor(string[] borderColor)
		{
			data.Datasets[index].BorderColor = borderColor;

            return this;
		}

		/// <summary>
		/// The width of the line in pixels.
		/// </summary>
		/// <returns>The border width.</returns>
		/// <param name="borderWidth">Border width.</param>
		public LineDataBuilder SetBorderWidth(int[] borderWidth)
		{
			data.Datasets[index].BorderWidth = borderWidth;

            return this;
		}

		/// <summary>
		/// Length and spacing of dashes. 
		/// </summary>
		/// <returns>The border dash.</returns>
		/// <param name="borderDash">Border dash.</param>
		public LineDataBuilder SetBorderDash(int[] borderDash)
        {
            data.Datasets[index].BorderDash = borderDash;

            return this;
        }

		/// <summary>
		/// Offset for line dashes. 
		/// </summary>
		/// <returns>The border dash offset.</returns>
		/// <param name="borderDashOffset">Border dash offset.</param>
		public LineDataBuilder SetBorderDashOffset(int borderDashOffset)
        {
            data.Datasets[index].BorderDashOffset = borderDashOffset;

            return this;
        }

		/// <summary>
		/// Cap style of the line.
		/// </summary>
		/// <returns>The border cap style.</returns>
		/// <param name="borderCapStyle">Border cap style.</param>
		public LineDataBuilder SetBorderCapStyle(string borderCapStyle)
        {
            data.Datasets[index].BorderCapStyle = borderCapStyle;

            return this;
        }

		/// <summary>
		/// Line joint style.
		/// </summary>
		/// <returns>The border join style.</returns>
		/// <param name="borderJoinStyle">Border join style.</param>
		public LineDataBuilder SetBorderJoinStyle(string borderJoinStyle)
        {
            data.Datasets[index].BorderJoinStyle = borderJoinStyle;

            return this;
        }

		/// <summary>
		/// How to fill the area under the line.
		/// </summary>
		/// <returns>The fill.</returns>
		/// <param name="fill">If set to <c>true</c> fill.</param>
		public LineDataBuilder SetFill(bool fill)
        {
            data.Datasets[index].Fill = fill;
           
            return this;
        }

		/// <summary>
		/// Bezier curve tension of the line. 
        /// Set to 0 to draw straightlines. 
        /// This option is ignored if monotone cubic interpolation is used.
		/// </summary>
		/// <returns>The line tension.</returns>
		/// <param name="lineTension">Line tension.</param>
		public LineDataBuilder SetLineTension(int lineTension)
        {
            data.Datasets[index].LineTension = lineTension;

            return this;
        }

		/// <summary>
		/// The fill color for points.
		/// </summary>
		/// <returns>The point background color.</returns>
		/// <param name="pointBackgroundColor">Point background color.</param>
		public LineDataBuilder SetPointBackgroundColor(string [] pointBackgroundColor)
        {
            data.Datasets[index].PointBackgroundColor = pointBackgroundColor;

            return this;
        }

		/// <summary>
		/// The border color for points.
		/// </summary>
		/// <returns>The point border color.</returns>
		/// <param name="pointBorderColor">Point border color.</param>
		public LineDataBuilder SetPointBorderColor(string[] pointBorderColor)
        {
            data.Datasets[index].PointBorderColor = pointBorderColor;

            return this;
        }

		/// <summary>
		/// The width of the point border in pixels.
		/// </summary>
		/// <returns>The point border width.</returns>
		/// <param name="pointBorderWidth">Point border width.</param>
		public LineDataBuilder SetPointBorderWidth(int[] pointBorderWidth)
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
		public LineDataBuilder SetPointRadius(int [] pointRadius)
        {
            data.Datasets[index].PointRadius = pointRadius;

            return this;
        }

		/// <summary>
		/// The pixel size of the non-displayed point that reacts to mouse events.
		/// </summary>
		/// <returns>The point hit radius.</returns>
		/// <param name="pointHitRadius">Point hit radius.</param>
		public LineDataBuilder SetPointHitRadius(int [] pointHitRadius)
        {
            data.Datasets[index].PointHitRadius = pointHitRadius;

            return this;
        }

		/// <summary>
		/// Point background color when hovered.
		/// </summary>
		/// <returns>The point hover background color.</returns>
		/// <param name="pointHoverBackgroundColor">Point hover background color.</param>
		public LineDataBuilder SetPointHoverBackgroundColor(string[] pointHoverBackgroundColor)
        {
            data.Datasets[index].PointHoverBackgroundColor = pointHoverBackgroundColor;

            return this;
        }

		/// <summary>
		/// Point border color when hovered.
		/// </summary>
		/// <returns>The point hover border color.</returns>
		/// <param name="pointHoverBorderColor">Point hover border color.</param>
		public LineDataBuilder SetPointHoverBorderColor(string[] pointHoverBorderColor)
        {
            data.Datasets[index].PointHoverBorderColor = pointHoverBorderColor;

            return this;
        }

		/// <summary>
		/// Border width of point when hovered.
		/// </summary>
		/// <returns>The point hover border width.</returns>
		/// <param name="pointHoverBorderWidth">Point hover border width.</param>
		public LineDataBuilder SetPointHoverBorderWidth(int[] pointHoverBorderWidth)
        {
            data.Datasets[index].PointHoverBorderWidth = pointHoverBorderWidth;

            return this;
        }

		/// <summary>
		/// The radius of the point when hovered.
		/// </summary>
		/// <returns>The point hover radius.</returns>
		/// <param name="pointHoverRadius">Point hover radius.</param>
		public LineDataBuilder SetPointHoverRadius(int [] pointHoverRadius)
        {
            data.Datasets[index].PointHoverRadius = pointHoverRadius;

            return this;
        }

		/// <summary>
		/// If false, the line is not drawn for this dataset.
		/// </summary>
		/// <returns>The show line.</returns>
		/// <param name="showLine">If set to <c>true</c> show line.</param>
		public LineDataBuilder SetShowLine(bool showLine)
        {
            data.Datasets[index].ShowLine = showLine;

            return this;
        }

		/// <summary>
		/// If true, lines will be drawn between points with no or null data. 
        /// If false, points with NaN data will create a break in the line
		/// </summary>
		/// <returns>The span gaps.</returns>
		/// <param name="spanGaps">If set to <c>true</c> span gaps.</param>
		public LineDataBuilder SetSpanGaps(bool spanGaps)
        {
            data.Datasets[index].SpanGaps = spanGaps;

            return this;
        }

		/// <summary>
		/// If the line is shown as a stepped line.
		/// </summary>
		/// <returns>The stepped line.</returns>
		/// <param name="steppedLine">If set to <c>true</c> stepped line.</param>
		public LineDataBuilder SetSteppedLine(bool steppedLine)
        {
            data.Datasets[index].SteppedLine = steppedLine;

            return this;
        }

        public LineChartBuilder CreateDataAndStartBuildingChart()
        {
            return new LineChartBuilder(defaultChartGenerator, chartValidator, chartJsonHelper, data);
        }
    }
}
