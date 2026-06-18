using Dapper;
using ProjectCompletionReport.Database;
using ProjectCompletionReport.Models;

namespace ProjectCompletionReport.Repositories
{
    public class BaoCaoDuAnRepository
    {
        public List<BaoCaoTyLeHoanThanhDuAn> GetBaoCaoDuAn()
        {
            using var conn = DbConnectionFactory.Create();

            string sql = """
                SELECT *
                FROM V_BAOCAO_TYLE_HOANTHANH_DUAN
                """;

            return conn.Query<BaoCaoTyLeHoanThanhDuAn>(sql).ToList();
        }
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
