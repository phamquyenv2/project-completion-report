using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using ProjectCompletionReport.Helpers;
using ProjectCompletionReport.Models;
using SkiaSharp;

namespace ProjectCompletionReport.ChartBuilders
{
    public static class StackedBarsChartBuilder
    {
        public static ISeries[] BuildSeries(List<BaoCaoTyLeHoanThanhNhanVien> data)
        {
            return new ISeries[]
            {
                new StackedColumnSeries<double>
                {
                    Name = "TY LE HT",
                    Values = data.Select(x => (double)x.TY_LE_HT).ToArray(),
                    Fill = new SolidColorPaint(ColorPalette.Primary),
                    DataLabelsPaint = null, 
                    MaxBarWidth = 40
                },
                new StackedColumnSeries<double>
                {
                    Name = "TY LE CHT",
                    Values = data.Select(x => (double)x.TY_LE_CHT).ToArray(),
                    Fill = new SolidColorPaint(ColorPalette.Accent),
                    DataLabelsPaint = null,
                    MaxBarWidth = 40
                }
            };
        }

        public static Axis[] BuildXAxes(List<BaoCaoTyLeHoanThanhNhanVien> data)
        {
            return new Axis[]
            {
                new Axis
                {
                    Labels = data.Select(x => $"{x.MA_NV}\n{x.MA_HD}").ToArray(), 
                    LabelsPaint = new SolidColorPaint(ColorPalette.TextDark),
                    TextSize = 10
                }
            };
        }

        public static Axis[] BuildYAxes()
        {
            return new Axis[]
            {
                new Axis
                {
                    MinLimit = 0,
                    MaxLimit = 100,
                    LabelsPaint = new SolidColorPaint(ColorPalette.TextDark),
                    TextSize = 11,
                    Labeler = value => $"{value}%"
                }
            };
        }
    }
}
