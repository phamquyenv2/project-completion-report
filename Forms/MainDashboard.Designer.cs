using System.Drawing;
using System.Windows.Forms;
using unvell.ReoGrid;

namespace ProjectCompletionReport.Forms
{
    partial class MainDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new Panel();
            
            this.pnlHeaderDuAn = new Panel();
            this.lblTitleDuAn = new Label();
            this.lblSub1DuAn = new Label();
            this.lblSub2DuAn = new Label();
            
            this.gridDuAn = new DataGridView();
            this.pnlChartsTop = new TableLayoutPanel();
            this.pnlDoughnut = new Panel();
            this.lblDoughnutTitle = new Label();
            this.pnlBasicBars = new Panel();
            this.lblBasicBarsTitle = new Label();

            this.pnlHeaderNhanVien = new Panel();
            this.lblTitleNhanVien = new Label();
            this.lblSub1NhanVien = new Label();
            this.lblSub2NhanVien = new Label();

            this.gridNhanVien = new DataGridView();
            this.pnlStackedBars = new Panel();
            this.lblStackedBarsTitle = new Label();

            this.pnlMain.SuspendLayout();
            this.pnlHeaderDuAn.SuspendLayout();
            this.pnlChartsTop.SuspendLayout();
            this.pnlDoughnut.SuspendLayout();
            this.pnlBasicBars.SuspendLayout();
            this.pnlHeaderNhanVien.SuspendLayout();
            this.pnlStackedBars.SuspendLayout();
            this.SuspendLayout();

            this.pnlMain.AutoScroll = true;
            this.pnlMain.BackColor = Color.White;
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Padding = new Padding(20);
            this.pnlMain.Controls.Add(this.pnlStackedBars);
            this.pnlMain.Controls.Add(this.gridNhanVien);
            this.pnlMain.Controls.Add(this.pnlHeaderNhanVien);
            this.pnlMain.Controls.Add(this.pnlChartsTop);
            this.pnlMain.Controls.Add(this.gridDuAn);
            this.pnlMain.Controls.Add(this.pnlHeaderDuAn);

            // pnlHeaderDuAn
            this.pnlHeaderDuAn.BackColor = Color.FromArgb(227, 239, 255);
            this.pnlHeaderDuAn.Dock = DockStyle.Top;
            this.pnlHeaderDuAn.Height = 80;
            this.pnlHeaderDuAn.Controls.Add(this.lblSub2DuAn);
            this.pnlHeaderDuAn.Controls.Add(this.lblSub1DuAn);
            this.pnlHeaderDuAn.Controls.Add(this.lblTitleDuAn);

            this.lblTitleDuAn.Dock = DockStyle.Top;
            this.lblTitleDuAn.Text = "BÁO CÁO TỶ LỆ HOÀN THÀNH DỰ ÁN";
            this.lblTitleDuAn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTitleDuAn.TextAlign = ContentAlignment.BottomCenter;
            this.lblTitleDuAn.Height = 30;

            this.lblSub1DuAn.Dock = DockStyle.Top;
            this.lblSub1DuAn.Text = "Từ ngày 01/01/2026 đến ngày 18/06/2026";
            this.lblSub1DuAn.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblSub1DuAn.TextAlign = ContentAlignment.MiddleCenter;
            this.lblSub1DuAn.Height = 20;

            this.lblSub2DuAn.Dock = DockStyle.Top;
            this.lblSub2DuAn.Text = "Tài khoản: Tất cả";
            this.lblSub2DuAn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblSub2DuAn.TextAlign = ContentAlignment.TopCenter;
            this.lblSub2DuAn.Height = 20;

            this.gridDuAn.Dock = DockStyle.Top;
            this.gridDuAn.Height = 200;
            this.gridDuAn.Margin = new Padding(0, 0, 0, 20);
            this.gridDuAn.BackColor = Color.White;

            this.pnlChartsTop.ColumnCount = 2;
            this.pnlChartsTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            this.pnlChartsTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            this.pnlChartsTop.RowCount = 1;
            this.pnlChartsTop.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            this.pnlChartsTop.Controls.Add(this.pnlDoughnut, 0, 0);
            this.pnlChartsTop.Controls.Add(this.pnlBasicBars, 1, 0);
            this.pnlChartsTop.Dock = DockStyle.Top;
            this.pnlChartsTop.Height = 320;
            this.pnlChartsTop.Margin = new Padding(0, 20, 0, 20);

            this.pnlDoughnut.Dock = DockStyle.Fill;
            this.pnlDoughnut.BorderStyle = BorderStyle.FixedSingle;
            this.pnlDoughnut.Margin = new Padding(0, 0, 10, 0);
            this.lblDoughnutTitle.Text = "HD001LQ-ITM";
            this.lblDoughnutTitle.Dock = DockStyle.Top;
            this.lblDoughnutTitle.Height = 40;
            this.lblDoughnutTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblDoughnutTitle.Font = new Font("Segoe UI", 12F);
            this.pnlDoughnut.Controls.Add(this.lblDoughnutTitle);

            this.pnlBasicBars.Dock = DockStyle.Fill;
            this.pnlBasicBars.BorderStyle = BorderStyle.FixedSingle;
            this.pnlBasicBars.Margin = new Padding(10, 0, 0, 0);
            this.lblBasicBarsTitle.Text = "Tỷ lệ hoàn thành theo dự án";
            this.lblBasicBarsTitle.Dock = DockStyle.Top;
            this.lblBasicBarsTitle.Height = 40;
            this.lblBasicBarsTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblBasicBarsTitle.Font = new Font("Segoe UI", 12F);
            this.pnlBasicBars.Controls.Add(this.lblBasicBarsTitle);

            // pnlHeaderNhanVien
            this.pnlHeaderNhanVien.BackColor = Color.FromArgb(227, 239, 255);
            this.pnlHeaderNhanVien.Dock = DockStyle.Top;
            this.pnlHeaderNhanVien.Height = 80;
            this.pnlHeaderNhanVien.Margin = new Padding(0, 20, 0, 0);
            this.pnlHeaderNhanVien.Controls.Add(this.lblSub2NhanVien);
            this.pnlHeaderNhanVien.Controls.Add(this.lblSub1NhanVien);
            this.pnlHeaderNhanVien.Controls.Add(this.lblTitleNhanVien);

            this.lblTitleNhanVien.Dock = DockStyle.Top;
            this.lblTitleNhanVien.Text = "BÁO CÁO TỶ LỆ HOÀN THÀNH CÔNG VIỆC CỦA TỪNG NHÂN VIÊN";
            this.lblTitleNhanVien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTitleNhanVien.TextAlign = ContentAlignment.BottomCenter;
            this.lblTitleNhanVien.Height = 30;

            this.lblSub1NhanVien.Dock = DockStyle.Top;
            this.lblSub1NhanVien.Text = "Từ ngày 01/01/2026 đến ngày 18/06/2026";
            this.lblSub1NhanVien.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            this.lblSub1NhanVien.TextAlign = ContentAlignment.MiddleCenter;
            this.lblSub1NhanVien.Height = 20;

            this.lblSub2NhanVien.Dock = DockStyle.Top;
            this.lblSub2NhanVien.Text = "Dự án: HD001LQ-ITM";
            this.lblSub2NhanVien.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblSub2NhanVien.TextAlign = ContentAlignment.TopCenter;
            this.lblSub2NhanVien.Height = 20;

            this.gridNhanVien.Dock = DockStyle.Top;
            this.gridNhanVien.Height = 200;
            this.gridNhanVien.Margin = new Padding(0, 0, 0, 20);
            this.gridNhanVien.BackColor = Color.White;

            this.pnlStackedBars.Dock = DockStyle.Top;
            this.pnlStackedBars.Height = 400;
            this.pnlStackedBars.BorderStyle = BorderStyle.FixedSingle;
            this.pnlStackedBars.Margin = new Padding(0, 20, 0, 20);
            this.lblStackedBarsTitle.Text = "Tỷ lệ hoàn thành theo nhân viên";
            this.lblStackedBarsTitle.Dock = DockStyle.Top;
            this.lblStackedBarsTitle.Height = 40;
            this.lblStackedBarsTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblStackedBarsTitle.Font = new Font("Segoe UI", 12F);
            this.pnlStackedBars.Controls.Add(this.lblStackedBarsTitle);

            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new Size(1280, 800);
            this.Controls.Add(this.pnlMain);
            this.Name = "MainDashboard";
            this.Text = "Báo cáo tiến độ dự án";
            this.WindowState = FormWindowState.Maximized;

            this.pnlHeaderDuAn.ResumeLayout(false);
            this.pnlChartsTop.ResumeLayout(false);
            this.pnlDoughnut.ResumeLayout(false);
            this.pnlBasicBars.ResumeLayout(false);
            this.pnlHeaderNhanVien.ResumeLayout(false);
            this.pnlStackedBars.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Panel pnlMain;
        
        private Panel pnlHeaderDuAn;
        private Label lblTitleDuAn;
        private Label lblSub1DuAn;
        private Label lblSub2DuAn;
        private DataGridView gridDuAn;
        
        private TableLayoutPanel pnlChartsTop;
        private Panel pnlDoughnut;
        private Label lblDoughnutTitle;
        private Panel pnlBasicBars;
        private Label lblBasicBarsTitle;

        private Panel pnlHeaderNhanVien;
        private Label lblTitleNhanVien;
        private Label lblSub1NhanVien;
        private Label lblSub2NhanVien;
        private DataGridView gridNhanVien;

        private Panel pnlStackedBars;
        private Label lblStackedBarsTitle;
    }
}
