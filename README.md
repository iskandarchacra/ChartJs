## [Install Chart.Js](http://www.chartjs.org/docs/latest/getting-started/installation.html)

## Steps for adding a Chart:
1. Create a `<canvas>` element in your HTML file and give it an id.
2. Get canvas element by ID in your JavaScript file and save it in a variable.
3. Pass the ChartJsBuilder constructor the name of the variable.
4. Calling `BuildChart()` will return a string.
5. Add the string returned to your JavaScript file.

## Sample Charts: 
   - **Bar Chart:** 
  ```
string barChart = new ChartJsBuilder("myChart").CreateBarChart()
	.StartBuildingChartData()
		.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
		.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
	.CreateDataAndStartBuildingChart()
		.SetOffsetGridLines(false)
	.BuildChart();
  ```        
  - **Multiple Datasets Bar Chart:** 
  ```
string multiDatasetBarChart = new ChartJsBuilder("myChart").CreateBarChart()
	.StartBuildingChartData() 
		.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" }) 
		.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
		.AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
		.AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
	.CreateDataAndStartBuildingChart()
	.BuildChart();
  ```
  - **Horizontal Bar Chart:**
```
string horizontalBarChart = new ChartJsBuilder("myChart").CreateHorizontalBarChart()
	.StartBuildingChartData()
		.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
		.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
	.CreateDataAndStartBuildingChart()
	.BuildChart();
```

  - **Multiple Datasets Horizontal Bar Chart:** 
```
string multiDatasetHorizontalBarChart = new ChartJsBuilder("myChart").CreateHorizontalBarChart()
	.StartBuildingChartData()
		.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
		.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
		.AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
		.AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
	.CreateDataAndStartBuildingChart()
	.BuildChart();
```

  - **Line Chart:** 
```
string lineChart = new ChartJsBuilder("myChart").CreateLineChart()
	.StartBuildingChartData()
		.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
		.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
		.SetFill(true)
	.CreateDataAndStartBuildingChart()
	.BuildChart();
```
          
  - **Multiple Datasets Line Chart:**
```
string multiDatasetLineChart = new ChartJsBuilder("myChart").CreateLineChart()
	.StartBuildingChartData()
		.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
		.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
		.SetFill(true)
		.AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
		.SetFill(true)
		.AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
	.CreateDataAndStartBuildingChart()
	.BuildChart();
```

  - **Radar Chart:**
```
string radarChart = new ChartJsBuilder("myChart").CreateRadarChart()
	.StartBuildingChartData()
		.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
		.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
		.SetFill(true)
	.CreateDataAndStartBuildingChart()
	.BuildChart();
```

  - **Multiple Datasets Radar Chart:** 
```
string multiDatasetRadarChart = new ChartJsBuilder("myChart").CreateRadarChart()
	.StartBuildingChartData()
		.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
		.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
		.SetFill(true)
		.AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
		.SetFill(true)
		.AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
		.SetFill(true)
	.CreateDataAndStartBuildingChart()
	.BuildChart();
```

  - **Doughnut Chart:** 
```
string doughnutChart = new ChartJsBuilder("myChart").CreateDoughnutChart()
	.StartBuildingChartData()
		.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
		.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
	.CreateDataAndStartBuildingChart()
	.BuildChart();
```

  - **Multiple Datasets Doughnut Chart:** 
```
string multiDatasetDoughnutChart = new ChartJsBuilder("myChart").CreateDoughnutChart()
	.StartBuildingChartData()
		.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
		.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
		.AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
		.AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
	.CreateDataAndStartBuildingChart()
	.BuildChart();
```
  - **Pie Chart:** 
```
string pieChart = new ChartJsBuilder("myChart").CreatePieChart()
	.StartBuildingChartData()
		.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
		.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
	.CreateDataAndStartBuildingChart()
	.BuildChart();
```
      
  - **Multiple Datasets Pie Chart:** 
  
```
string multiDatasetPieChart = new ChartJsBuilder("myChart").CreatePieChart()
	.StartBuildingChartData()
		.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
		.AddDataset(new int[] { 10, 20, 30 }, "First Dataset")
		.AddDataset(new int[] { 15, 25, 35 }, "Second Dataset")
		.AddDataset(new int[] { 35, 60, 75 }, "Third Dataset")
	.CreateDataAndStartBuildingChart()
	.BuildChart();
```


  - **Bubble Chart:** 
```
string bubbleChart = new ChartJsBuilder("myChart").CreateBubbleChart()
	.StartBuildingChartData()
		.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
		.AddDataset(new List<BubblePoint>
		{
			new BubblePoint { R = 4, X = 20, Y = 30 },
			new BubblePoint { R = 4, X = 15, Y = 15 },
			new BubblePoint { R = 4, X = 10, Y = 10 }
		}, "First Dataset")
	.CreateDataAndStartBuildingChart()
	.BuildChart();
```

  - **Multiple Datasets Bubble Chart:** 
```	
string multiDatasetBubbleChart = new ChartJsBuilder("myChart").CreateBubbleChart()
	.StartBuildingChartData()
		.SetDataLabels(new string[] { "First Data Label", "Second Data Label", "Third Data Label" })
		.AddDataset(new List<BubblePoint>
		{
			new BubblePoint { R = 4, X = 20, Y = 30 },
			new BubblePoint { R = 1, X = 4, Y = 23 },
			new BubblePoint { R = 8, X = 9, Y = 26 }
		}, "First Dataset")
		.AddDataset(new List<BubblePoint>
		{
			new BubblePoint { R = 5, X= 15, Y = 15 },
			new BubblePoint { R = 5, X = 85, Y = 15 },
			new BubblePoint { R = 4, X = 45, Y = 52 }
		}, "Second Dataset")
		.AddDataset(new List<BubblePoint>
		{
			new BubblePoint { R = 9, X = 5, Y = 10 },
			new BubblePoint { R = 4, X = 66, Y = 41 },
			new BubblePoint { R = 4, X = 33, Y = 4 }
		}, "Third Dataset")
	.CreateDataAndStartBuildingChart()
	.BuildChart();
```
