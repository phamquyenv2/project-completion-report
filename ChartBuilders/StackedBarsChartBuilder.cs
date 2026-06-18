using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using ProjectCompletionReport.Models;
using SkiaSharp;

namespace ProjectCompletionReport.ChartBuilders
{
    /// <summary>
    /// Stacked Bars Chart – Gallery: Bars → Stacked Bars
    /// X-axis: Mã nhân viên (LAMNV, THANGPT, QUANGDV, LUANPT)
    /// Series: TY_LE_HT và TY_LE_CHT (xếp chồng lên nhau → 100%)
    /// => Giống biểu đồ phía dưới trong hình Excel.
    /// </summary>
    public static class StackedBarsChartBuilder
    {
        public static ISeries[] BuildSeries(List<BaoCaoTyLeHoanThanhNhanVien> data)
        {
            return new ISeries[]
            {
                new StackedColumnSeries<double>
                {
                    Name = "TỶ LỆ HT (%)",
                    Values = data.Select(x => x.TY_LE_HT).ToArray(),
                    Fill = new SolidColorPaint(new SKColor(76, 175, 80)),   // Xanh lá
                    DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    DataLabelsSize = 12,
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Middle,
                    DataLabelsFormatter = p => $"{p.Coordinate.PrimaryValue:0}%",
                    MaxBarWidth = 40
                },
                new StackedColumnSeries<double>
                {
                    Name = "TỶ LỆ CHT (%)",
                    Values = data.Select(x => x.TY_LE_CHT).ToArray(),
                    Fill = new SolidColorPaint(new SKColor(244, 67, 54)),   // Đỏ
                    DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    DataLabelsSize = 12,
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.Middle,
                    DataLabelsFormatter = p => $"{p.Coordinate.PrimaryValue:0}%",
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
                    Labels = data.Select(x => x.MA_NV).ToArray(),
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
                    MinLimit = 0,
                    MaxLimit = 100,
                    LabelsPaint = new SolidColorPaint(SKColors.White),
                    TextSize = 11
                }
            };
        }
    }
}
