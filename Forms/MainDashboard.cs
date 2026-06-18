using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView.Painting;
using ProjectCompletionReport.ChartBuilders;
using ProjectCompletionReport.Models;
using ProjectCompletionReport.Services;
using SkiaSharp;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
namespace ProjectCompletionReport.Forms
{
    public partial class MainDashboard : Form
    {
        private readonly BaoCaoService _service = new();
        private PieChart? _doughnutChart;
        private CartesianChart? _basicBarsChart;
        private CartesianChart? _stackedBarsChart;

        public MainDashboard()
        {
            InitializeComponent();
            InitializeCharts();
            this.Load += MainDashboard_Load;
        }

        private void InitializeCharts()
        {
            _doughnutChart = new PieChart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                InitialRotation = -90,
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Bottom,
                LegendTextPaint = new SolidColorPaint(new SKColor(51, 51, 51)) { SKTypeface = SKTypeface.FromFamilyName("Segoe UI") },
                LegendTextSize = 13
            };
            pnlDoughnut.Controls.Add(_doughnutChart);
            _doughnutChart.BringToFront();

            _basicBarsChart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Bottom,
                LegendTextPaint = new SolidColorPaint(new SKColor(51, 51, 51)) { SKTypeface = SKTypeface.FromFamilyName("Segoe UI") },
                LegendTextSize = 13
            };
            pnlBasicBars.Controls.Add(_basicBarsChart);
            _basicBarsChart.BringToFront();

            _stackedBarsChart = new CartesianChart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                LegendPosition = LiveChartsCore.Measure.LegendPosition.Bottom,
                LegendTextPaint = new SolidColorPaint(new SKColor(51, 51, 51)) { SKTypeface = SKTypeface.FromFamilyName("Segoe UI") },
                LegendTextSize = 13
            };
            pnlStackedBars.Controls.Add(_stackedBarsChart);
            _stackedBarsChart.BringToFront();
        }

        private void MainDashboard_Load(object? sender, System.EventArgs e)
        {
            LoadData();
        }

                private void Grid_RowPostPaint(object? sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = (DataGridView)sender!;
            var rowIdx = (e.RowIndex + 1).ToString();
            var centerFormat = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics?.DrawString(rowIdx, grid.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void LoadData()
        {
            var duAnData = _service.LayTatCaDuAn();
            var nhanVienData = _service.LayTatCaNhanVien();

            var filteredNhanVien = nhanVienData.Where(x => x.MA_HD == "HD001LQ-ITM").ToList();

            void StyleGrid(DataGridView grid)
            {
                grid.AllowUserToAddRows = false;
                grid.AllowUserToDeleteRows = false;
                grid.ReadOnly = true;
                grid.BackgroundColor = Color.White;
                grid.BorderStyle = BorderStyle.None;
                grid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grid.GridColor = Color.FromArgb(200, 215, 240);
                grid.EnableHeadersVisualStyles = false;
                
                grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(220, 235, 255);
                grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
                grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
                grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                
                grid.DefaultCellStyle.SelectionBackColor = Color.White;
                grid.DefaultCellStyle.SelectionForeColor = Color.Black;
                
                grid.RowHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
                grid.RowHeadersWidth = 40;
                
                grid.ScrollBars = ScrollBars.None;
                grid.RowTemplate.Height = 22;
                grid.ColumnHeadersHeight = 25;
                grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                grid.RowPostPaint -= Grid_RowPostPaint;
                grid.RowPostPaint += Grid_RowPostPaint;
            }

            StyleGrid(gridDuAn);
            gridDuAn.DataSource = duAnData.Select(x => new {
                MaHD = x.MA_HD,
                SLTaskHT = x.SL_TASK_HT,
                SLTaskCHT = x.SL_TASK_CHT,
                TyLeHT = $"{x.TY_LE_HT:0.00}%",
                TyLeCHT = $"{x.TY_LE_CHT:0.00}%",
                MaSP = x.MA_SP,
                SLTask = x.SL_TASK
            }).ToList();
            
            gridDuAn.Columns["MaHD"].HeaderText = "Mã HĐ"; gridDuAn.Columns["MaHD"].Width = 150;
            gridDuAn.Columns["SLTaskHT"].HeaderText = "SL Task HT"; gridDuAn.Columns["SLTaskHT"].Width = 100; gridDuAn.Columns["SLTaskHT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridDuAn.Columns["SLTaskCHT"].HeaderText = "SL Task CHT"; gridDuAn.Columns["SLTaskCHT"].Width = 100; gridDuAn.Columns["SLTaskCHT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridDuAn.Columns["TyLeHT"].HeaderText = "Tỷ lệ HT"; gridDuAn.Columns["TyLeHT"].Width = 90; gridDuAn.Columns["TyLeHT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridDuAn.Columns["TyLeCHT"].HeaderText = "Tỷ lệ CHT"; gridDuAn.Columns["TyLeCHT"].Width = 90; gridDuAn.Columns["TyLeCHT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridDuAn.Columns["MaSP"].HeaderText = "Mã SP"; gridDuAn.Columns["MaSP"].Width = 80;
            gridDuAn.Columns["SLTask"].HeaderText = "SL Task"; gridDuAn.Columns["SLTask"].Width = 90; gridDuAn.Columns["SLTask"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            
            gridDuAn.Height = (duAnData.Count * 22) + 25 + 2; 

            StyleGrid(gridNhanVien);
            gridNhanVien.DataSource = filteredNhanVien.Select(x => new {
                MaHD = x.MA_HD,
                MaNV = x.MA_NV,
                SLTaskHT = x.SL_TASK_HT,
                SLTaskCHT = x.SL_TASK_CHT,
                TyLeHT = $"{x.TY_LE_HT:0.00}%",
                TyLeCHT = $"{x.TY_LE_CHT:0.00}%",
                MaSP = x.MA_SP,
                SLTask = x.SL_TASK
            }).ToList();

            gridNhanVien.Columns["MaHD"].HeaderText = "Mã HĐ"; gridNhanVien.Columns["MaHD"].Width = 120;
            gridNhanVien.Columns["MaNV"].HeaderText = "Mã NV"; gridNhanVien.Columns["MaNV"].Width = 100;
            gridNhanVien.Columns["SLTaskHT"].HeaderText = "SL Task HT"; gridNhanVien.Columns["SLTaskHT"].Width = 100; gridNhanVien.Columns["SLTaskHT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridNhanVien.Columns["SLTaskCHT"].HeaderText = "SL Task CHT"; gridNhanVien.Columns["SLTaskCHT"].Width = 100; gridNhanVien.Columns["SLTaskCHT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridNhanVien.Columns["TyLeHT"].HeaderText = "Tỷ lệ HT"; gridNhanVien.Columns["TyLeHT"].Width = 90; gridNhanVien.Columns["TyLeHT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridNhanVien.Columns["TyLeCHT"].HeaderText = "Tỷ lệ CHT"; gridNhanVien.Columns["TyLeCHT"].Width = 90; gridNhanVien.Columns["TyLeCHT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            gridNhanVien.Columns["MaSP"].HeaderText = "Mã SP"; gridNhanVien.Columns["MaSP"].Width = 80;
            gridNhanVien.Columns["SLTask"].HeaderText = "SL Task"; gridNhanVien.Columns["SLTask"].Width = 90; gridNhanVien.Columns["SLTask"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            gridNhanVien.Height = (filteredNhanVien.Count * 22) + 25 + 2;

            if (duAnData.Count > 0)
            {
                var firstDuAn = duAnData.First();
                lblDoughnutTitle.Text = firstDuAn.MA_HD;
                _doughnutChart!.Series = DoughnutChartBuilder.Build(firstDuAn);

                _basicBarsChart!.Series = BasicBarsChartBuilder.BuildSeries(duAnData);
                _basicBarsChart.XAxes = BasicBarsChartBuilder.BuildXAxes(duAnData);
                _basicBarsChart.YAxes = BasicBarsChartBuilder.BuildYAxes();
            }

            if (filteredNhanVien.Count > 0)
            {
                _stackedBarsChart!.Series = StackedBarsChartBuilder.BuildSeries(filteredNhanVien);
                _stackedBarsChart.XAxes = StackedBarsChartBuilder.BuildXAxes(filteredNhanVien);
                _stackedBarsChart.YAxes = StackedBarsChartBuilder.BuildYAxes();
            }
        }
    }
}
