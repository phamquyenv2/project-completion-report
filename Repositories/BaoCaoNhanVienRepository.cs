using Dapper;
using ProjectCompletionReport.Database;
using ProjectCompletionReport.Models;

namespace ProjectCompletionReport.Repositories
{
    public class BaoCaoNhanVienRepository
    {
        public List<BaoCaoTyLeHoanThanhNhanVien> GetAll()
        {
            using var conn = DbConnectionFactory.Create();

            string sql = """
                SELECT *
                FROM V_BAOCAO_TYLE_HOANTHANH_NV
                """;

            return conn.Query<BaoCaoTyLeHoanThanhNhanVien>(sql).ToList();
        }
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
