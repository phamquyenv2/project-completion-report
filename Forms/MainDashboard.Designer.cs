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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // ── Panel chính ──
            this.pnlHeader = new Panel();
            this.lblTitle = new Label();
            this.pnlComboBox = new Panel();
            this.lblFilter = new Label();
            this.cboMaHD = new ComboBox();
            this.pnlCharts = new TableLayoutPanel();

            // ── Các chart panel ──
            this.pnlDoughnut = new Panel();
            this.lblDoughnutTitle = new Label();
            this.pnlBasicBars = new Panel();
            this.lblBasicBarsTitle = new Label();
            this.pnlStackedBars = new Panel();
            this.lblStackedBarsTitle = new Label();

            this.SuspendLayout();

            // ════════════════════════════════════════
            // pnlHeader
            // ════════════════════════════════════════
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(20, 25, 45);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Height = 70;
            this.pnlHeader.Padding = new Padding(20, 0, 20, 0);
            this.pnlHeader.Controls.Add(this.pnlComboBox);
            this.pnlHeader.Controls.Add(this.lblTitle);

            // ════════════════════════════════════════
            // lblTitle
            // ════════════════════════════════════════
            this.lblTitle.Text = "📊 BÁO CÁO TỶ LỆ HOÀN THÀNH DỰ ÁN";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(120, 200, 255);
            this.lblTitle.Dock = DockStyle.Left;
            this.lblTitle.AutoSize = true;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Padding = new Padding(10, 0, 0, 0);

            // ════════════════════════════════════════
            // pnlComboBox (chứa Label + ComboBox)
            // ════════════════════════════════════════
            this.pnlComboBox.Dock = DockStyle.Right;
            this.pnlComboBox.Width = 350;
            this.pnlComboBox.Padding = new Padding(10, 15, 20, 15);
            this.pnlComboBox.Controls.Add(this.cboMaHD);
            this.pnlComboBox.Controls.Add(this.lblFilter);

            // lblFilter
            this.lblFilter.Text = "Mã HĐ:";
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFilter.ForeColor = System.Drawing.Color.White;
            this.lblFilter.Dock = DockStyle.Left;
            this.lblFilter.AutoSize = true;
            this.lblFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFilter.Padding = new Padding(0, 5, 5, 0);

            // cboMaHD
            this.cboMaHD.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cboMaHD.Dock = DockStyle.Fill;
            this.cboMaHD.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cboMaHD.BackColor = System.Drawing.Color.FromArgb(30, 40, 65);
            this.cboMaHD.ForeColor = System.Drawing.Color.White;
            this.cboMaHD.FlatStyle = FlatStyle.Flat;

            // ════════════════════════════════════════
            // pnlCharts (TableLayoutPanel 2x2)
            // ════════════════════════════════════════
            this.pnlCharts.Dock = DockStyle.Fill;
            this.pnlCharts.BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            this.pnlCharts.Padding = new Padding(10);
            this.pnlCharts.ColumnCount = 2;
            this.pnlCharts.RowCount = 2;
            this.pnlCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
            this.pnlCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
            this.pnlCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            this.pnlCharts.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            // ── Panel Doughnut (trái trên) ──
            this.pnlDoughnut.BackColor = System.Drawing.Color.FromArgb(25, 30, 55);
            this.pnlDoughnut.Margin = new Padding(6);
            this.pnlDoughnut.Dock = DockStyle.Fill;

            this.lblDoughnutTitle.Text = "🍩 TỶ LỆ HOÀN THÀNH (Doughnut)";
            this.lblDoughnutTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDoughnutTitle.ForeColor = System.Drawing.Color.FromArgb(180, 220, 255);
            this.lblDoughnutTitle.Dock = DockStyle.Top;
            this.lblDoughnutTitle.Height = 35;
            this.lblDoughnutTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlDoughnut.Controls.Add(this.lblDoughnutTitle);

            this.pnlCharts.Controls.Add(this.pnlDoughnut, 0, 0);

            // ── Panel Basic Bars (phải trên) ──
            this.pnlBasicBars.BackColor = System.Drawing.Color.FromArgb(25, 30, 55);
            this.pnlBasicBars.Margin = new Padding(6);
            this.pnlBasicBars.Dock = DockStyle.Fill;

            this.lblBasicBarsTitle.Text = "📊 SO SÁNH TASK THEO DỰ ÁN (Basic Bars)";
            this.lblBasicBarsTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblBasicBarsTitle.ForeColor = System.Drawing.Color.FromArgb(180, 220, 255);
            this.lblBasicBarsTitle.Dock = DockStyle.Top;
            this.lblBasicBarsTitle.Height = 35;
            this.lblBasicBarsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlBasicBars.Controls.Add(this.lblBasicBarsTitle);

            this.pnlCharts.Controls.Add(this.pnlBasicBars, 1, 0);

            // ── Panel Stacked Bars (span cả dòng dưới) ──
            this.pnlStackedBars.BackColor = System.Drawing.Color.FromArgb(25, 30, 55);
            this.pnlStackedBars.Margin = new Padding(6);
            this.pnlStackedBars.Dock = DockStyle.Fill;

            this.lblStackedBarsTitle.Text = "📈 TỶ LỆ HOÀN THÀNH THEO NHÂN VIÊN (Stacked Bars)";
            this.lblStackedBarsTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStackedBarsTitle.ForeColor = System.Drawing.Color.FromArgb(180, 220, 255);
            this.lblStackedBarsTitle.Dock = DockStyle.Top;
            this.lblStackedBarsTitle.Height = 35;
            this.lblStackedBarsTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pnlStackedBars.Controls.Add(this.lblStackedBarsTitle);

            this.pnlCharts.Controls.Add(this.pnlStackedBars, 0, 1);
            this.pnlCharts.SetColumnSpan(this.pnlStackedBars, 2);

            // ════════════════════════════════════════
            // MainDashboard
            // ════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(15, 20, 40);
            this.ClientSize = new System.Drawing.Size(1280, 780);
            this.Controls.Add(this.pnlCharts);
            this.Controls.Add(this.pnlHeader);
            this.Name = "MainDashboard";
            this.Text = "Project Completion Report - Dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);

            this.ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Panel pnlComboBox;
        private Label lblFilter;
        private ComboBox cboMaHD;
        private TableLayoutPanel pnlCharts;

        private Panel pnlDoughnut;
        private Label lblDoughnutTitle;
        private Panel pnlBasicBars;
        private Label lblBasicBarsTitle;
        private Panel pnlStackedBars;
        private Label lblStackedBarsTitle;
    }
}
