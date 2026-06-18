using Dapper;

namespace ProjectCompletionReport.Database
{

    public static class DbInitializer
    {
        public static void Initialize()
        {
            try
            {
                EnsureDatabase();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bỏ qua lỗi tạo database: " + ex.Message);
            }

            using var conn = DbConnectionFactory.Create();
            CreateTables(conn);
            CreateViews(conn);
            SeedData(conn);
        }


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


        private static void CreateTables(System.Data.IDbConnection conn)
        {
            conn.Execute(@"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'SAN_PHAM')
                CREATE TABLE SAN_PHAM
                (
                    MA_SP   VARCHAR(20)   PRIMARY KEY,
                    TEN_SP  NVARCHAR(100) NOT NULL
                )
            ");
            conn.Execute(@"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'NHAN_VIEN')
                CREATE TABLE NHAN_VIEN
                (
                    MA_NV   VARCHAR(20)   PRIMARY KEY,
                    TEN_NV  NVARCHAR(100) NOT NULL
                )
            ");
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


        private static void CreateViews(System.Data.IDbConnection conn)
        {
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


        private static void SeedData(System.Data.IDbConnection conn)
        {
            var count = conn.ExecuteScalar<int>("SELECT COUNT(*) FROM SAN_PHAM");
            if (count > 0) return; 
            conn.Execute(@"
                INSERT INTO SAN_PHAM (MA_SP, TEN_SP) VALUES
                ('ACC', N'Accounting'),
                ('MRP', N'Material Resource Planning')
            ");
            conn.Execute(@"
                INSERT INTO NHAN_VIEN (MA_NV, TEN_NV) VALUES
                ('LAMNV',   N'Nguyễn Văn Lâm'),
                ('THANGPT', N'Phan Thanh Thắng'),
                ('QUANGDV', N'Đặng Văn Quảng'),
                ('LUANPT',  N'Phan Thanh Luận')
            ");
            conn.Execute(@"
                INSERT INTO HOP_DONG (MA_HD, MA_SP, TEN_HD) VALUES
                ('HD001LQ-ITM', 'ACC', N'Hợp đồng triển khai ACC'),
                ('HD002LQ-GB',  'MRP', N'Hợp đồng triển khai MRP')
            ");
            conn.Execute(@"
                INSERT INTO PHAN_CONG_TASK (MA_HD, MA_NV, SL_TASK_HT, SL_TASK_CHT) VALUES
                ('HD001LQ-ITM', 'LAMNV',   30, 25),
                ('HD001LQ-ITM', 'THANGPT', 30, 20),
                ('HD001LQ-ITM', 'QUANGDV', 20, 18),
                ('HD001LQ-ITM', 'LUANPT',  15, 15),

                ('HD002LQ-GB',  'LAMNV',   25,  0),
                ('HD002LQ-GB',  'THANGPT', 25,  0)
            ");
        }
    }
}
