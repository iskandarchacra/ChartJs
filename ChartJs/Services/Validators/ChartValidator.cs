using System.Collections.Generic;
using ChartJs.Models;
using ChartJs.Models.Datasets;

namespace ChartJs.Services.Validators
{
    public class ChartValidator : IChartValidator
    {
        public bool IsValid(Chart<BarDataset> chart, out List<string> errors) 
        {
			errors = new List<string>();

            if(chart.Data.Datasets.Count == 0)
            {
                errors.Add("No datasets added to the chart.");
            }

            if(chart.Data.Labels.Length == 0)
            {
                errors.Add("No data labels added to the chart.");
            }

            if(chart.Data.Datasets.Count < chart.Data.Labels.Length)
            {
                errors.Add("The number of datasets is less than the number of labels.");
            }

            if(chart.Data.Datasets.Count > chart.Data.Labels.Length)
            {
                errors.Add("The number of datasets is less than the number of labels");
            }

            foreach(var dataset in chart.Data.Datasets)
            {
                var datasetIndex = 1;

                if(dataset.Data.Length > dataset.BackgroundColor.Length)
                {
                    errors.Add("There is more data in dataset " + datasetIndex + " than background colors specified. Add more background colors.");
                }

                if(string.IsNullOrEmpty(dataset.Label))
                {
                    errors.Add("Dataset " + datasetIndex + " is missing a label");
                }

                datasetIndex++;
            }

            if (errors.Count == 0)
            {
                return true; 
            }

			return false;
        }

        public bool IsValid(Chart<BubbleDataset> chart, out List<string> errors)
        {
            errors = new List<string>();

			if (chart.Data.Datasets.Count == 0)
			{
				errors.Add("No datasets added to the chart.");
			}

			if (chart.Data.Labels.Length == 0)
			{
				errors.Add("No data labels added to the chart.");
			}

			if (chart.Data.Datasets.Count < chart.Data.Labels.Length)
			{
				errors.Add("The number of datasets is less than the number of labels.");
			}

			if (chart.Data.Datasets.Count > chart.Data.Labels.Length)
			{
				errors.Add("The number of datasets is less than the number of labels");
			}

			foreach (var dataset in chart.Data.Datasets)
			{
				var datasetIndex = 1;

				if (dataset.Data.Count > dataset.BackgroundColor.Length)
				{
					errors.Add("There is more data in dataset " + datasetIndex + " than background colors specified. Add more background colors.");
				}

				if (string.IsNullOrEmpty(dataset.Label))
				{
					errors.Add("Dataset " + datasetIndex + " is missing a label");
				}
				datasetIndex++;
			}

			if (errors.Count == 0)
			{
				return true;
			}

            return false;
        }

        public bool IsValid(Chart<LineDataset> chart, out List<string> errors)
        {
            errors = new List<string>();

            if (chart.Data.Datasets.Count == 0)
            {
                errors.Add("No datasets added to the chart.");
            }

            if (chart.Data.Labels.Length == 0)
            {
                errors.Add("No data labels added to the chart.");
            }

            if (chart.Data.Datasets.Count < chart.Data.Labels.Length)
            {
                errors.Add("The number of datasets is less than the number of labels.");
            }

            if (chart.Data.Datasets.Count > chart.Data.Labels.Length)
            {
                errors.Add("The number of datasets is less than the number of labels");
            }

			foreach (var dataset in chart.Data.Datasets)
			{
				var datasetIndex = 1;

				if (dataset.Data.Length > dataset.BackgroundColor.Length)
				{
					errors.Add("There is more data in dataset " + datasetIndex + " than background colors specified. Add more background colors.");
				}

				if (string.IsNullOrEmpty(dataset.Label))
				{
					errors.Add("Dataset " + datasetIndex + " is missing a label");
				}
				datasetIndex++;
			}

            if (errors.Count == 0)
            {
                return true;
            }

            return false;
        }

        public bool IsValid(Chart<DoughnutDataset> chart, out List<string> errors)
        {
            errors = new List<string>();

            if (chart.Data.Datasets.Count == 0)
            {
                errors.Add("No datasets added to the chart.");
            }

            if (chart.Data.Labels.Length == 0)
            {
                errors.Add("No data labels added to the chart.");
            }

            if (chart.Data.Datasets.Count < chart.Data.Labels.Length)
            {
                errors.Add("The number of datasets is less than the number of labels.");
            }

            if (chart.Data.Datasets.Count > chart.Data.Labels.Length)
            {
                errors.Add("The number of datasets is less than the number of labels");
            }

			foreach (var dataset in chart.Data.Datasets)
			{
				var datasetIndex = 1;

				if (dataset.Data.Length > dataset.BackgroundColor.Length)
				{
					errors.Add("There is more data in dataset " + datasetIndex + " than background colors specified. Add more background colors.");
				}

				if (string.IsNullOrEmpty(dataset.Label))
				{
					errors.Add("Dataset " + datasetIndex + " is missing a label");
				}
				datasetIndex++;
			}

            if (errors.Count == 0)
            {
                return true;
            }

            return false;
        }

        public bool IsValid(Chart<RadarDataset> chart, out List<string> errors)
        {
            errors = new List<string>();

            if (chart.Data.Datasets.Count == 0)
            {
                errors.Add("No datasets added to the chart.");
            }

            if (chart.Data.Labels.Length == 0)
            {
                errors.Add("No data labels added to the chart.");
            }

            if (chart.Data.Datasets.Count < chart.Data.Labels.Length)
            {
                errors.Add("The number of datasets is less than the number of labels.");
            }

            if (chart.Data.Datasets.Count > chart.Data.Labels.Length)
            {
                errors.Add("The number of datasets is less than the number of labels");
            }

			foreach (var dataset in chart.Data.Datasets)
			{
				var datasetIndex = 1;

				if (dataset.Data.Length > dataset.BackgroundColor.Length)
				{
					errors.Add("There is more data in dataset " + datasetIndex + " than background colors specified. Add more background colors.");
				}

				if (string.IsNullOrEmpty(dataset.Label))
				{
					errors.Add("Dataset " + datasetIndex + " is missing a label");
				}
				datasetIndex++;
			}

            if (errors.Count == 0)
            {
                return true;
            }

            return false;
        }
    }
}
