using System.IO;
using System.Reflection;

namespace ChartJs.Services.ResourceHelpers
{
    public static class ResourceHelper
    {
        public static string GetChartJsTemplate()
        {
            Stream resource = Assembly.GetEntryAssembly().GetManifestResourceStream("ChartJs.Templates.ChartJsTemplate.txt");

            using (var streamReader = new StreamReader(resource))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}
