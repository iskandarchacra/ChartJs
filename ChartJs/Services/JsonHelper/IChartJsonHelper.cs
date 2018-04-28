using ChartJs.Models;
using ChartJs.Models.Datasets;

namespace ChartJs.Services.TemplateWriter
{
    public interface IChartJsonHelper
    {
        string OverwriteTemplate<T>(Chart<T> chart) where T : Dataset;
	}
}
