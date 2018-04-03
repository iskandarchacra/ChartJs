using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace ChartJs.Services.ResourceHelpers
{
    public static class ResourceHelper
    {
        public static Task<string> GetChartJsTemplate()
        {
            Stream resource = Assembly.GetEntryAssembly().GetManifestResourceStream("ChartJs.Templates.ChartJsTemplate.txt");
            StreamReader streamReader = new StreamReader(resource);

            return streamReader.ReadToEndAsync();
        }
    }
}
