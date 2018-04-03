using System.Collections.Generic;
using ChartJs.Models;
using ChartJs.Models.Datasets;

namespace ChartJs.Services.Validators
{
    public interface IChartValidator
    {
        bool IsValid(Chart<BubbleDataset> chart, out List<string> errors);

        bool IsValid(Chart<BarDataset> chart, out List<string> errors);

        bool IsValid(Chart<LineDataset> chart, out List<string> errors);

        bool IsValid(Chart<RadarDataset> chart, out List<string> errors);

        bool IsValid(Chart<DoughnutDataset> chart, out List<string> errors);
	}
}
