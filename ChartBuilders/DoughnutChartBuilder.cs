using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using ProjectCompletionReport.Models;
using SkiaSharp;

namespace ProjectCompletionReport.ChartBuilders
{
    /// <summary>
    /// Doughnut Chart – Gallery: Pie → Doughnut
    /// Hiển thị SL_TASK_HT vs SL_TASK_CHT cho 1 dự án đang chọn.
    /// </summary>
    public static class DoughnutChartBuilder
    {
        public static IEnumerable<ISeries> Build(BaoCaoTyLeHoanThanhDuAn duAn)
        {
            return new ISeries[]
            {
                new PieSeries<double>
                {
                    Name = "Hoàn thành",
                    Values = new double[] { duAn.SL_TASK_HT },
                    InnerRadius = 60,
                    Fill = new SolidColorPaint(new SKColor(76, 175, 80)),   // Xanh lá
                    DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    DataLabelsSize = 14,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter = p => $"{p.Coordinate.PrimaryValue} ({p.StackedValue?.Share:P0})"
                },
                new PieSeries<double>
                {
                    Name = "Chưa hoàn thành",
                    Values = new double[] { duAn.SL_TASK_CHT },
                    InnerRadius = 60,
                    Fill = new SolidColorPaint(new SKColor(244, 67, 54)),   // Đỏ
                    DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    DataLabelsSize = 14,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter = p => $"{p.Coordinate.PrimaryValue} ({p.StackedValue?.Share:P0})"
                }
            };
        }
    }
}
