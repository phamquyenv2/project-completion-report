using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using ProjectCompletionReport.Helpers;
using ProjectCompletionReport.Models;
using SkiaSharp;

namespace ProjectCompletionReport.ChartBuilders
{
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
                    Fill = new SolidColorPaint(ColorPalette.Primary),
                    DataLabelsPaint = null,
                    MaxBarWidth = 35
                },
                new ColumnSeries<int>
                {
                    Name = "SL TASK CHT",
                    Values = data.Select(x => x.SL_TASK_CHT).ToArray(),
                    Fill = new SolidColorPaint(ColorPalette.Accent),
                    DataLabelsPaint = null,
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
                    LabelsPaint = new SolidColorPaint(ColorPalette.TextDark),
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
                    LabelsPaint = new SolidColorPaint(ColorPalette.TextDark),
                    TextSize = 11
                }
            };
        }
    }
}
