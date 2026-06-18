using Dapper;
using ProjectCompletionReport.Database;
using ProjectCompletionReport.Models;

namespace ProjectCompletionReport.Repositories
{
    public class BaoCaoNhanVienRepository
    {
        /// <summary>
        /// Lấy toàn bộ báo cáo tỷ lệ hoàn thành nhân viên (từ VIEW).
        /// TY_LE_HT, TY_LE_CHT, SL_TASK được tính tự động.
        /// </summary>
        public List<BaoCaoTyLeHoanThanhNhanVien> GetAll()
        {
            using var conn = DbConnectionFactory.Create();

            string sql = """
                SELECT *
                FROM V_BAOCAO_TYLE_HOANTHANH_NV
                """;

            return conn.Query<BaoCaoTyLeHoanThanhNhanVien>(sql).ToList();
        }

        /// <summary>
        /// Lấy báo cáo nhân viên theo mã hợp đồng (từ VIEW).
        /// </summary>
        public List<BaoCaoTyLeHoanThanhNhanVien> GetByMaHD(string maHD)
        {
            using var conn = DbConnectionFactory.Create();

            string sql = """
                SELECT *
                FROM V_BAOCAO_TYLE_HOANTHANH_NV
                WHERE MA_HD = @MaHD
                """;

            return conn.Query<BaoCaoTyLeHoanThanhNhanVien>(sql, new { MaHD = maHD }).ToList();
        }
    }
}
