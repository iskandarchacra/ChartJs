using System.Collections.Generic;
using ChartJs.Models.Datasets;

namespace ChartJs.Models
{
    public class Data <TDataset> where TDataset : Dataset
    {
        public string[] Labels { get; set; }

        public List<TDataset> Datasets { get; set; }
    }
}
