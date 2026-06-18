using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using ProjectCompletionReport.Models;
using SkiaSharp;

namespace ProjectCompletionReport.ChartBuilders
{
    /// <summary>
    /// Basic Bars Chart – Gallery: Bars → Basic Bars
    /// X-axis: Mã hợp đồng (HD001LQ-ITM, HD002LQ-GB, ...)
    /// Series: SL_TASK_HT và SL_TASK_CHT
    /// => Giống biểu đồ cột bên phải trong Excel.
    /// </summary>
    public static class BasicBarsChartBuilder
    {
        public static ISeries[] BuildSeries(List<BaoCaoTyLeHoanThanhDuAn> data)
        {
            return new ISeries[]
            {
                new ColumnSeries<int>
                {
                    Name = "SL TASK HT",
                    Values = data.Select(x => x.SL_TASK_HT).ToArray(),
                    Fill = new SolidColorPaint(new SKColor(33, 150, 243)),  // Xanh dương
                    DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    DataLabelsSize = 12,
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Middle,
                    MaxBarWidth = 35
                },
                new ColumnSeries<int>
                {
                    Name = "SL TASK CHT",
                    Values = data.Select(x => x.SL_TASK_CHT).ToArray(),
                    Fill = new SolidColorPaint(new SKColor(255, 152, 0)),   // Cam
                    DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    DataLabelsSize = 12,
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Middle,
                    MaxBarWidth = 35
                }
            };
        }

        public static Axis[] BuildXAxes(List<BaoCaoTyLeHoanThanhDuAn> data)
        {
            return new Axis[]
            {
                new Axis
                {
                    Labels = data.Select(x => x.MA_HD).ToArray(),
                    LabelsPaint = new SolidColorPaint(SKColors.White),
                    TextSize = 12
                }
            };
        }

        public static Axis[] BuildYAxes()
        {
            return new Axis[]
            {
                new Axis
                {
                    LabelsPaint = new SolidColorPaint(SKColors.White),
                    TextSize = 11
                }
            };
        }
    }
}
