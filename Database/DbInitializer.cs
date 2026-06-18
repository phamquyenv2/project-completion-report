using Dapper;

namespace ProjectCompletionReport.Database
{
    /// <summary>
    /// Tạo database, bảng chuẩn hóa, VIEW tính tỷ lệ tự động, và seed dữ liệu mẫu.
    /// 
    /// Schema:
    ///   SAN_PHAM ──┐
    ///              ├── HOP_DONG ──┐
    ///   NHAN_VIEN ─┘              ├── PHAN_CONG_TASK (raw data)
    ///              ───────────────┘
    ///   
    ///   VIEW V_BAOCAO_TYLE_HOANTHANH_DUAN   ← tổng hợp theo dự án
    ///   VIEW V_BAOCAO_TYLE_HOANTHANH_NV     ← chi tiết theo nhân viên
    /// </summary>
    public static class DbInitializer
    {
        public static void Initialize()
        {
            // 1. Tạo database nếu chưa có (có thể lỗi nếu user không có quyền CREATE DATABASE)
            try
            {
                EnsureDatabase();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bỏ qua lỗi tạo database: " + ex.Message);
            }

            using var conn = DbConnectionFactory.Create();

            // 2. Tạo bảng master
            CreateTables(conn);

            // 3. Tạo VIEWs (tính tỷ lệ tự động)
            CreateViews(conn);

            // 4. Seed dữ liệu mẫu
            SeedData(conn);
        }

        // ══════════════════════════════════════════════
        // Tạo database
        // ══════════════════════════════════════════════
        private static void EnsureDatabase()
        {
            using var master = DbConnectionFactory.CreateMaster();
            master.Execute(@"
                IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'ProjectCompletionReport')
                BEGIN
                    CREATE DATABASE ProjectCompletionReport
                END
            ");
        }

        // ══════════════════════════════════════════════
        // Tạo bảng chuẩn hóa (normalized) + FK
        // ══════════════════════════════════════════════
        private static void CreateTables(System.Data.IDbConnection conn)
        {
            // ── Bảng SAN_PHAM ──
            conn.Execute(@"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SAN_PHAM')
                CREATE TABLE SAN_PHAM
                (
                    MA_SP   VARCHAR(20)   PRIMARY KEY,
                    TEN_SP  NVARCHAR(100) NOT NULL
                )
            ");

            // ── Bảng NHAN_VIEN ──
            conn.Execute(@"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'NHAN_VIEN')
                CREATE TABLE NHAN_VIEN
                (
                    MA_NV   VARCHAR(20)   PRIMARY KEY,
                    TEN_NV  NVARCHAR(100) NOT NULL
                )
            ");

            // ── Bảng HOP_DONG (FK → SAN_PHAM) ──
            conn.Execute(@"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'HOP_DONG')
                CREATE TABLE HOP_DONG
                (
                    MA_HD   VARCHAR(20)   PRIMARY KEY,
                    MA_SP   VARCHAR(20)   NOT NULL,
                    TEN_HD  NVARCHAR(200) NOT NULL,
                    CONSTRAINT FK_HopDong_SanPham
                        FOREIGN KEY (MA_SP) REFERENCES SAN_PHAM(MA_SP)
                )
            ");

            // ── Bảng PHAN_CONG_TASK (FK → HOP_DONG, NHAN_VIEN) ──
            // Chỉ lưu SL_TASK_HT và SL_TASK_CHT.
            // SL_TASK, TY_LE_HT, TY_LE_CHT sẽ tính tự động trong VIEW.
            conn.Execute(@"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'PHAN_CONG_TASK')
                CREATE TABLE PHAN_CONG_TASK
                (
                    ID          INT IDENTITY(1,1) PRIMARY KEY,
                    MA_HD       VARCHAR(20) NOT NULL,
                    MA_NV       VARCHAR(20) NOT NULL,
                    SL_TASK_HT  INT DEFAULT 0,
                    SL_TASK_CHT INT DEFAULT 0,
                    CONSTRAINT FK_PhanCong_HopDong
                        FOREIGN KEY (MA_HD) REFERENCES HOP_DONG(MA_HD),
                    CONSTRAINT FK_PhanCong_NhanVien
                        FOREIGN KEY (MA_NV) REFERENCES NHAN_VIEN(MA_NV)
                )
            ");
        }

        // ══════════════════════════════════════════════
        // Tạo VIEWs – tính TY_LE_HT, TY_LE_CHT, SL_TASK tự động
        // ══════════════════════════════════════════════
        private static void CreateViews(System.Data.IDbConnection conn)
        {
            // ── VIEW 1: Báo cáo theo nhân viên ──
            // TY_LE_HT = SL_TASK_HT / (SL_TASK_HT + SL_TASK_CHT) * 100
            conn.Execute(@"
                IF OBJECT_ID('V_BAOCAO_TYLE_HOANTHANH_NV', 'V') IS NOT NULL
                    DROP VIEW V_BAOCAO_TYLE_HOANTHANH_NV;
            ");
            conn.Execute(@"
                CREATE VIEW V_BAOCAO_TYLE_HOANTHANH_NV
                AS
                SELECT
                    p.ID,
                    p.MA_HD,
                    p.MA_NV,
                    p.SL_TASK_HT,
                    p.SL_TASK_CHT,
                    (p.SL_TASK_HT + p.SL_TASK_CHT)                                                           AS SL_TASK,
                    CAST(p.SL_TASK_HT  * 100.0 / NULLIF(p.SL_TASK_HT + p.SL_TASK_CHT, 0) AS DECIMAL(5,2))   AS TY_LE_HT,
                    CAST(p.SL_TASK_CHT * 100.0 / NULLIF(p.SL_TASK_HT + p.SL_TASK_CHT, 0) AS DECIMAL(5,2))   AS TY_LE_CHT,
                    h.MA_SP
                FROM PHAN_CONG_TASK p
                JOIN HOP_DONG h ON p.MA_HD = h.MA_HD
            ");

            // ── VIEW 2: Báo cáo tổng hợp theo dự án ──
            // Gom nhóm SUM từ PHAN_CONG_TASK theo MA_HD
            conn.Execute(@"
                IF OBJECT_ID('V_BAOCAO_TYLE_HOANTHANH_DUAN', 'V') IS NOT NULL
                    DROP VIEW V_BAOCAO_TYLE_HOANTHANH_DUAN;
            ");
            conn.Execute(@"
                CREATE VIEW V_BAOCAO_TYLE_HOANTHANH_DUAN
                AS
                SELECT
                    h.MA_HD,
                    ISNULL(SUM(p.SL_TASK_HT), 0)                                                                              AS SL_TASK_HT,
                    ISNULL(SUM(p.SL_TASK_CHT), 0)                                                                              AS SL_TASK_CHT,
                    ISNULL(SUM(p.SL_TASK_HT) + SUM(p.SL_TASK_CHT), 0)                                                         AS SL_TASK,
                    CAST(SUM(p.SL_TASK_HT)  * 100.0 / NULLIF(SUM(p.SL_TASK_HT) + SUM(p.SL_TASK_CHT), 0) AS DECIMAL(5,2))     AS TY_LE_HT,
                    CAST(SUM(p.SL_TASK_CHT) * 100.0 / NULLIF(SUM(p.SL_TASK_HT) + SUM(p.SL_TASK_CHT), 0) AS DECIMAL(5,2))     AS TY_LE_CHT,
                    h.MA_SP
                FROM HOP_DONG h
                LEFT JOIN PHAN_CONG_TASK p ON h.MA_HD = p.MA_HD
                GROUP BY h.MA_HD, h.MA_SP
            ");
        }

        // ══════════════════════════════════════════════
        // Seed dữ liệu mẫu (chỉ seed khi bảng rỗng)
        // ══════════════════════════════════════════════
        private static void SeedData(System.Data.IDbConnection conn)
        {
            var count = conn.ExecuteScalar<int>("SELECT COUNT(*) FROM SAN_PHAM");
            if (count > 0) return; // Đã có data rồi

            // ── Sản phẩm ──
            conn.Execute(@"
                INSERT INTO SAN_PHAM (MA_SP, TEN_SP) VALUES
                ('ACC', N'Accounting'),
                ('MRP', N'Material Resource Planning')
            ");

            // ── Nhân viên ──
            conn.Execute(@"
                INSERT INTO NHAN_VIEN (MA_NV, TEN_NV) VALUES
                ('LAMNV',   N'Nguyễn Văn Lâm'),
                ('THANGPT', N'Phan Thanh Thắng'),
                ('QUANGDV', N'Đặng Văn Quảng'),
                ('LUANPT',  N'Phan Thanh Luận')
            ");

            // ── Hợp đồng ──
            conn.Execute(@"
                INSERT INTO HOP_DONG (MA_HD, MA_SP, TEN_HD) VALUES
                ('HD001LQ-ITM', 'ACC', N'Hợp đồng triển khai ACC'),
                ('HD002LQ-GB',  'MRP', N'Hợp đồng triển khai MRP')
            ");

            // ── Phân công task ──
            // HD001LQ-ITM: Tổng HT=80, CHT=20, TASK=100 → TY_LE_HT=80%
            // HD002LQ-GB:  Tổng HT=50, CHT=0,  TASK=50  → TY_LE_HT=100%
            conn.Execute(@"
                INSERT INTO PHAN_CONG_TASK (MA_HD, MA_NV, SL_TASK_HT, SL_TASK_CHT) VALUES
                ('HD001LQ-ITM', 'LAMNV',   25,  5),   -- 30 task, 83.33% HT
                ('HD001LQ-ITM', 'THANGPT',  20, 10),   -- 30 task, 66.67% HT
                ('HD001LQ-ITM', 'QUANGDV',  18,  2),   -- 20 task, 90.00% HT
                ('HD001LQ-ITM', 'LUANPT',   17,  3),   -- 20 task, 85.00% HT

                ('HD002LQ-GB',  'LAMNV',   25,  0),   -- 25 task, 100% HT
                ('HD002LQ-GB',  'THANGPT',  25,  0)    -- 25 task, 100% HT
            ");
        }
    }
}
