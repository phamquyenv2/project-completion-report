using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView.Painting;
using ProjectCompletionReport.ChartBuilders;
using ProjectCompletionReport.Models;
using ProjectCompletionReport.Services;
using SkiaSharp;

namespace ProjectCompletionReport.Forms
{
    public partial class MainDashboard : Form
    {
        private readonly BaoCaoService _service = new();

        // LiveCharts2 controls
        private PieChart? _doughnutChart;
        private CartesianChart? _basicBarsChart;
        private CartesianChart? _stackedBarsChart;

        public MainDashboard()
        {
            InitializeComponent();
            InitializeCharts();
            LoadComboBox();

            this.cboMaHD.SelectedIndexChanged += CboMaHD_SelectedIndexChanged;
            this.Load += MainDashboard_Load;
        }

        // ══════════════════════════════════════════════
        // Khởi tạo Chart controls và gắn vào Panel
        // ══════════════════════════════════════════════
        private void InitializeCharts()
        {
            // ── Doughnut Chart ──
            _doughnutChart = new PieChart
            {
                Dock = DockStyle.Fill,
                BackColor = System.Drawing.Color.FromArgb(25, 30, 55),
                InitialRotation = -90,
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Bottom,
                LegendTextPaint = new SolidColorPaint(SKColors.White) { SKTypeface = SKTypeface.FromFamilyName("Segoe UI") },
                LegendTextSize = 13
            };
            pnlDoughnut.Controls.Add(_doughnutChart);
            _doughnutChart.BringToFront(); // đảm bảo nằm dưới label title

            // ── Basic Bars Chart ──
            _basicBarsChart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = System.Drawing.Color.FromArgb(25, 30, 55),
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Bottom,
                LegendTextPaint = new SolidColorPaint(SKColors.White) { SKTypeface = SKTypeface.FromFamilyName("Segoe UI") },
                LegendTextSize = 13
            };
            pnlBasicBars.Controls.Add(_basicBarsChart);
            _basicBarsChart.BringToFront();

            // ── Stacked Bars Chart ──
            _stackedBarsChart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = System.Drawing.Color.FromArgb(25, 30, 55),
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Bottom,
                LegendTextPaint = new SolidColorPaint(SKColors.White) { SKTypeface = SKTypeface.FromFamilyName("Segoe UI") },
                LegendTextSize = 13
            };
            pnlStackedBars.Controls.Add(_stackedBarsChart);
            _stackedBarsChart.BringToFront();
        }

        // ══════════════════════════════════════════════
        // Load ComboBox mã hợp đồng
        // ══════════════════════════════════════════════
        private void LoadComboBox()
        {
            var danhSach = _service.LayDanhSachMaHD();
            cboMaHD.Items.Clear();
            cboMaHD.Items.Add("-- Tất cả --");
            foreach (var ma in danhSach)
            {
                cboMaHD.Items.Add(ma);
            }
            cboMaHD.SelectedIndex = 0;
        }

        // ══════════════════════════════════════════════
        // Sự kiện
        // ══════════════════════════════════════════════
        private void MainDashboard_Load(object? sender, EventArgs e)
        {
            LoadAllCharts();
        }

        private void CboMaHD_SelectedIndexChanged(object? sender, EventArgs e)
        {
            LoadAllCharts();
        }

        // ══════════════════════════════════════════════
        // Load dữ liệu và cập nhật tất cả biểu đồ
        // ══════════════════════════════════════════════
        private void LoadAllCharts()
        {
            string selectedMaHD = cboMaHD.SelectedItem?.ToString() ?? "";
            bool isAll = selectedMaHD == "-- Tất cả --" || string.IsNullOrEmpty(selectedMaHD);

            // ── 1. Doughnut Chart ──
            LoadDoughnutChart(isAll ? null : selectedMaHD);

            // ── 2. Basic Bars Chart ──
            LoadBasicBarsChart();

            // ── 3. Stacked Bars Chart ──
            LoadStackedBarsChart(isAll ? null : selectedMaHD);
        }

        /// <summary>
        /// Doughnut: SL_TASK_HT vs SL_TASK_CHT cho 1 dự án.
        /// Nếu chọn "Tất cả" thì lấy dự án đầu tiên.
        /// </summary>
        private void LoadDoughnutChart(string? maHD)
        {
            if (_doughnutChart == null) return;

            BaoCaoTyLeHoanThanhDuAn? duAn;

            if (maHD != null)
            {
                duAn = _service.LayDuAnTheoMaHD(maHD);
            }
            else
            {
                var all = _service.LayTatCaDuAn();
                duAn = all.FirstOrDefault();
            }

            if (duAn == null) return;

            lblDoughnutTitle.Text = $"🍩 TỶ LỆ HOÀN THÀNH – {duAn.MA_HD}";
            _doughnutChart.Series = DoughnutChartBuilder.Build(duAn);
        }

        /// <summary>
        /// Basic Bars: Luôn hiển thị tất cả dự án để so sánh.
        /// </summary>
        private void LoadBasicBarsChart()
        {
            if (_basicBarsChart == null) return;

            var data = _service.LayTatCaDuAn();
            if (data.Count == 0) return;

            _basicBarsChart.Series = BasicBarsChartBuilder.BuildSeries(data);
            _basicBarsChart.XAxes = BasicBarsChartBuilder.BuildXAxes(data);
            _basicBarsChart.YAxes = BasicBarsChartBuilder.BuildYAxes();
        }

        /// <summary>
        /// Stacked Bars: TY_LE_HT + TY_LE_CHT theo nhân viên.
        /// Lọc theo mã hợp đồng đang chọn.
        /// </summary>
        private void LoadStackedBarsChart(string? maHD)
        {
            if (_stackedBarsChart == null) return;

            List<BaoCaoTyLeHoanThanhNhanVien> data;

            if (maHD != null)
            {
                data = _service.LayNhanVienTheoMaHD(maHD);
                lblStackedBarsTitle.Text = $"📈 TỶ LỆ HOÀN THÀNH THEO NHÂN VIÊN – {maHD}";
            }
            else
            {
                data = _service.LayTatCaNhanVien();
                lblStackedBarsTitle.Text = "📈 TỶ LỆ HOÀN THÀNH THEO NHÂN VIÊN (Stacked Bars)";
            }

            if (data.Count == 0)
            {
                _stackedBarsChart.Series = Array.Empty<LiveChartsCore.ISeries>();
                return;
            }

            _stackedBarsChart.Series = StackedBarsChartBuilder.BuildSeries(data);
            _stackedBarsChart.XAxes = StackedBarsChartBuilder.BuildXAxes(data);
            _stackedBarsChart.YAxes = StackedBarsChartBuilder.BuildYAxes();
        }
    }
}
