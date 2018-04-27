using ChartJs.Models;
using ChartJs.Models.Datasets;
using ChartJs.Services.DefaultValuesGenerator;
using ChartJs.Services.TemplateWriter;
using ChartJs.Services.Validators;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChartJs.Services
{
    public abstract class ChartBuilder<TBuilder, TDataset> 
        where TBuilder : ChartBuilder<TBuilder, TDataset>
        where TDataset : Dataset
	{
        protected Chart<TDataset> Chart;
        protected abstract TBuilder BuilderInstance { get; }
        protected readonly IDefaultChartGenerator defaultChartGenerator;
        protected readonly IChartValidator chartValidator;
        protected readonly IChartJsonHelper chartJsonHelper;

        protected ChartBuilder(IDefaultChartGenerator defaultChartGenerator, IChartValidator chartValidator, IChartJsonHelper chartJsonHelper)
        {
            this.defaultChartGenerator = defaultChartGenerator;
            this.chartValidator = chartValidator;
            this.chartJsonHelper = chartJsonHelper;
		}

        public TBuilder SetChartAnimation(AnimationType animation) 
		{
            Chart.Animation = animation;

            return BuilderInstance;
		}

		/// <summary>
		/// Sets the top padding to add inside the chart
		/// </summary>
		/// <returns>The chart padding top.</returns>
		/// <param name="paddingTop">Padding top.</param>
		public TBuilder SetChartPaddingTop(int paddingTop)
		{
			Chart.Options.Layout.Padding.Top = paddingTop;

			return BuilderInstance;
		}

		/// <summary>
		/// Sets the left padding to add inside the chart
		/// </summary>
		/// <returns>The chart padding left.</returns>
		/// <param name="paddingLeft">Padding left.</param>
		public TBuilder SetChartPaddingLeft(int paddingLeft)
		{
			Chart.Options.Layout.Padding.Left = paddingLeft;

			return BuilderInstance;
		}

		/// <summary>
		/// Sets the bottom padding to add inside the chart
		/// </summary>
		/// <returns>The chart padding top.</returns>
		/// <param name="paddingBottom">Padding bottom.</param>
		public TBuilder SetChartPaddingBottom(int paddingBottom)
		{
			Chart.Options.Layout.Padding.Bottom = paddingBottom;

			return BuilderInstance;
		}

		/// <summary>
		/// Sets the right padding to add inside the chart
		/// </summary>
		/// <returns>The chart padding top.</returns>
		/// <param name="paddingRight">Padding right.</param>
		public TBuilder SetChartPaddingRight(int paddingRight)
		{
			Chart.Options.Layout.Padding.Right = paddingRight;

			return BuilderInstance;
		}

		/// <summary>
		/// Type of X scale being employed.
		/// </summary>
		/// <returns>The X A xes scales type.</returns>
		/// <param name="type">Type.</param>
		public TBuilder SetXAxesScalesType(ScaleType type)
		{
			Chart.Options.Scales.XAxes[0].Type = type;

			return BuilderInstance;
		}

        /// <summary>
        /// Sets whether the X Axes is displayed or not.
        /// </summary>
        /// <returns>The XA xes display.</returns>
        /// <param name="display">If set to <c>true</c> display.</param>
		public TBuilder SetXAxesDisplay(bool display)
		{
			Chart.Options.Scales.XAxes[0].Display = display;

			return BuilderInstance;
		}

		/// <summary>
		/// The weight used to sort the X axes. Higher weights are further away from the chart area.
		/// </summary>
		/// <returns>The XA xes weight.</returns>
		/// <param name="weight">Weight.</param>
		public TBuilder SetXAxesWeight(int weight)
		{
			Chart.Options.Scales.XAxes[0].Weight = weight;

			return BuilderInstance;
		}

		/// <summary>
		/// User defined fixed step size for the scale.
		/// </summary>
		/// <returns>The X Axes step size.</returns>
		/// <param name="stepSize">Step size.</param>
		public TBuilder SetXAxesStepSize(string stepSize)
		{
			Chart.Options.Scales.XAxes[0].StepSize = stepSize;

			return BuilderInstance;
		}

		/// <summary>
		/// Position of the X axes in the chart. 
		/// </summary>
		/// <returns>The X Axes position.</returns>
		/// <param name="position">Position.</param>
		public TBuilder SetXAxesPosition(PositionType position)
		{
			Chart.Options.Scales.XAxes[0].Position = position;

			return BuilderInstance;
		}

        /// <summary>
        /// Type of Y scale being employed.
        /// </summary>
        /// <returns>The YA xes scales type.</returns>
        /// <param name="type">Type.</param>
		public TBuilder SetYAxesScalesType(ScaleType type)
		{
			Chart.Options.Scales.YAxes[0].Type = type;

			return BuilderInstance;
		}
         
        /// <summary>
        /// Sets whether the Y Axes is displayed.
        /// </summary>
        /// <returns>The Y Axes display.</returns>
        /// <param name="display">If set to <c>true</c> display.</param>
		public TBuilder SetYAxesDisplay(bool display)
		{
			Chart.Options.Scales.YAxes[0].Display = display;

			return BuilderInstance;
		}

        /// <summary>
        /// The weight used to sort the Y axes. Higher weights are further away from the chart area.
        /// </summary>
        /// <returns>The Y Axes weight.</returns>
        /// <param name="weight">Weight.</param>
		public TBuilder SetYAxesWeight(int weight)
		{
			Chart.Options.Scales.YAxes[0].Weight = weight;

			return BuilderInstance;
		}

        /// <summary>
        /// User defined fixed step size for the scale.
        /// </summary>
        /// <returns>The Y Axes step size.</returns>
        /// <param name="stepSize">Step size.</param>
		public TBuilder SetYAxesStepSize(string stepSize)
		{
			Chart.Options.Scales.YAxes[0].StepSize = stepSize;

			return BuilderInstance;
		}

        /// <summary>
        /// Position of the Y axes in the chart. 
        /// </summary>
        /// <returns>The Y Axes position.</returns>
        /// <param name="position">Position.</param>
		public TBuilder SetYAxesPosition(PositionType position)
		{
			Chart.Options.Scales.YAxes[0].Position = position;

			return BuilderInstance;
		}

        /// <summary>
        /// Sets whether the legend is displayed or not.
        /// </summary>
        /// <returns>The legend display.</returns>
        /// <param name="legendDisplay">If set to <c>true</c> legend display.</param>
		public TBuilder SetLegendDisplay(bool legendDisplay)
		{
			Chart.Options.Legend.Display = legendDisplay;

			return BuilderInstance;
		}

        /// <summary>
        /// Sets the position of the legend.
        /// </summary>
        /// <returns>The legend position.</returns>
        /// <param name="position">Position.</param>
		public TBuilder SetLegendPosition(PositionType position)
		{
			Chart.Options.Legend.Position = position;

			return BuilderInstance;
		}

		/// <summary>
		/// Marks that this box should take the full width of the canvas (pushing down other boxes). 
        /// This is unlikely to need to be changed in day-to-day use.
		/// </summary>
		/// <returns>The legend full width.</returns>
		/// <param name="fullWidth">If set to <c>true</c> full width.</param>
		public TBuilder SetLegendFullWidth(bool fullWidth)
		{
			Chart.Options.Legend.FullWidth = fullWidth;

			return BuilderInstance;
		}

		/// <summary>
		/// Legend will show datasets in reverse order.
		/// </summary>
		/// <returns>The legend reverse.</returns>
		/// <param name="reverse">If set to <c>true</c> reverse.</param>
		public TBuilder SetLegendReverse(bool reverse)
		{
			Chart.Options.Legend.Reverse = reverse;

			return BuilderInstance;
		}

		/// <summary>
		/// Sets the width of coloured box.
		/// </summary>
		/// <returns>The legend label box width.</returns>
		/// <param name="boxWidth">Box width.</param>
		public TBuilder SetLegendLabelBoxWidth(int boxWidth)
		{
			Chart.Options.Legend.Labels.BoxWidth = boxWidth;

			return BuilderInstance;
		}

		/// <summary>
		/// Sets the size of the legend label font.
		/// </summary>
		/// <returns>The legend label font size.</returns>
		/// <param name="fontSize">Font size.</param>
		public TBuilder SetLegendLabelFontSize(int fontSize)
		{
			Chart.Options.Legend.Labels.FontSize = fontSize;

			return BuilderInstance;
		}

        /// <summary>
        /// Sets the legend label font style.
        /// </summary>
        /// <returns>The legend label font style.</returns>
        /// <param name="fontStyle">Font style.</param>
		public TBuilder SetLegendLabelFontStyle(FontStyleType fontStyle)
		{
			Chart.Options.Legend.Labels.FontStyle = fontStyle;

			return BuilderInstance;
		}

        /// <summary>
        /// Sets the color of the legend label font.
        /// </summary>
        /// <returns>The legend label font color.</returns>
        /// <param name="fontColor">Font color.</param>
		public TBuilder SetLegendLabelFontColor(string fontColor)
		{
			Chart.Options.Legend.Labels.FontColor = fontColor;

			return BuilderInstance;
		}

        /// <summary>
        /// Sets the legend label font family.
        /// </summary>
        /// <returns>The legend label font family.</returns>
        /// <param name="fontFamily">Font family.</param>
		public TBuilder SetLegendLabelFontFamily(string fontFamily)
		{
			Chart.Options.Legend.Labels.FontFamily = fontFamily;

			return BuilderInstance;
		}

		/// <summary>
		/// Sets the padding between rows of colored boxes.
		/// </summary>
		/// <returns>The legend label padding.</returns>
		/// <param name="padding">Padding.</param>
		public TBuilder SetLegendLabelPadding(int padding)
		{
			Chart.Options.Legend.Labels.Padding = padding;

			return BuilderInstance;
		}

		/// <summary>
		/// Label style will match corresponding point style (size is based on fontSize, boxWidth is not used in this case).
		/// </summary>
		/// <returns>The legend label is using point style.</returns>
		/// <param name="usePointStyle">If set to <c>true</c> use point style.</param>
		public TBuilder SetLegendLabelIsUsingPointStyle(bool usePointStyle)
		{
			Chart.Options.Legend.Labels.UsePointStyle = usePointStyle;

			return BuilderInstance;
		}

        /// <summary>
        /// Sets whether the title is displayed.
        /// </summary>
        /// <returns>The title display.</returns>
        /// <param name="titleDisplay">If set to <c>true</c> title display.</param>
		public TBuilder SetTitleDisplay(bool titleDisplay)
		{
			Chart.Options.Title.Display = titleDisplay;

			return BuilderInstance;
		}

        /// <summary>
        /// Sets the position of the title.
        /// </summary>
        /// <returns>The title position.</returns>
        /// <param name="position">Position.</param>
		public TBuilder SetTitlePosition(PositionType position)
		{
			Chart.Options.Title.Position = position;

			return BuilderInstance;
		}

        /// <summary>
        /// Sets the font size of the title.
        /// </summary>
        /// <returns>The title font size.</returns>
        /// <param name="fontSize">Font size.</param>
		public TBuilder SetTitleFontSize(int fontSize)
		{
			Chart.Options.Title.FontSize = fontSize;

			return BuilderInstance;
		}

        /// <summary>
        /// Sets the font family of the title.
        /// </summary>
        /// <returns>The title font family.</returns>
        /// <param name="fontFamily">Font family.</param>
		public TBuilder SetTitleFontFamily(string fontFamily)
		{
			Chart.Options.Title.FontFamily = fontFamily;

			return BuilderInstance;
		}

		/// <summary>
		/// Sets the font color of the title.
		/// </summary>
		/// <returns>The title font color.</returns>
		/// <param name="fontColor">Font color.</param>
		public TBuilder SetTitleFontColor(string fontColor)
		{
			Chart.Options.Title.FontColor = fontColor;

			return BuilderInstance;
		}

		/// <summary>
		/// Sets the  font style of the title.
		/// </summary>
		/// <returns>The title font style.</returns>
		/// <param name="fontStyle">Font style.</param>
		public TBuilder SetTitleFontStyle(FontStyleType fontStyle)
		{
			Chart.Options.Title.FontStyle = fontStyle;

			return BuilderInstance;
		}

		/// <summary>
		/// Number of pixels to add above and below the title text.
		/// </summary>
		/// <returns>The title padding.</returns>
		/// <param name="padding">Padding.</param>
		public TBuilder SetTitlePadding(int padding)
		{
			Chart.Options.Title.Padding = padding;

			return BuilderInstance;
		}

		/// <summary>
		/// Height of an individual line of text 
		/// </summary>
		/// <returns>The title line height.</returns>
		/// <param name="lineHeight">Line height.</param>
		public TBuilder SetTitleLineHeight(double lineHeight)
		{
			Chart.Options.Title.LineHeight = lineHeight;

			return BuilderInstance;
		}

		/// <summary>
		/// Title text to display. If specified as an array, text is rendered on multiple lines.
		/// </summary>
		/// <returns>The title text.</returns>
		/// <param name="text">Text.</param>
		public TBuilder SetTitleText(string[] text)     
		{
			Chart.Options.Title.Text = text;

			return BuilderInstance;
		}

        public abstract string BuildChart();
	}
}
