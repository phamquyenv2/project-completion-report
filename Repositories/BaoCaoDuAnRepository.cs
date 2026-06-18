using Dapper;
using ProjectCompletionReport.Database;
using ProjectCompletionReport.Models;

namespace ProjectCompletionReport.Repositories
{
    public class BaoCaoDuAnRepository
    {
        /// <summary>
        /// Lấy toàn bộ báo cáo tỷ lệ hoàn thành dự án (từ VIEW).
        /// TY_LE_HT, TY_LE_CHT, SL_TASK được tính tự động.
        /// </summary>
        public List<BaoCaoTyLeHoanThanhDuAn> GetBaoCaoDuAn()
        {
            using var conn = DbConnectionFactory.Create();

            string sql = """
                SELECT *
                FROM V_BAOCAO_TYLE_HOANTHANH_DUAN
                """;

            return conn.Query<BaoCaoTyLeHoanThanhDuAn>(sql).ToList();
        }

        /// <summary>
        /// Lấy báo cáo theo mã hợp đồng (từ VIEW).
        /// </summary>
        public BaoCaoTyLeHoanThanhDuAn? GetByMaHD(string maHD)
        {
            using var conn = DbConnectionFactory.Create();

            string sql = """
                SELECT *
                FROM V_BAOCAO_TYLE_HOANTHANH_DUAN
                WHERE MA_HD = @MaHD
                """;

            return conn.QueryFirstOrDefault<BaoCaoTyLeHoanThanhDuAn>(sql, new { MaHD = maHD });
        }
    }
}
