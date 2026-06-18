using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using ProjectCompletionReport.Helpers;
using ProjectCompletionReport.Models;
using SkiaSharp;

namespace ProjectCompletionReport.ChartBuilders
{
    public static class DoughnutChartBuilder
    {
        public static IEnumerable<ISeries> Build(BaoCaoTyLeHoanThanhDuAn duAn)
        {
            return new ISeries[]
            {
                new PieSeries<double>
                {
                    Name = "TY LE HT",
                    Values = new double[] { duAn.SL_TASK_HT },
                    InnerRadius = 60,
                    Fill = new SolidColorPaint(ColorPalette.Primary),
                    DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    DataLabelsSize = 14,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter = p => $"{p.StackedValue?.Share:P0}"
                },
                new PieSeries<double>
                {
                    Name = "TY LE CHT",
                    Values = new double[] { duAn.SL_TASK_CHT },
                    InnerRadius = 60,
                    Fill = new SolidColorPaint(ColorPalette.Accent),
                    DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    DataLabelsSize = 14,
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Middle,
                    DataLabelsFormatter = p => $"{p.StackedValue?.Share:P0}"
                }
            };
        }
    }
}
